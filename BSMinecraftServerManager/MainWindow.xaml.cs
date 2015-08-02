/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 2015-7-28
 * 时间: 9:48
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using Microsoft.Win32;

using System;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.Globalization;
using System.Xml;
using System.IO;
using System.Threading;
using System.Configuration;

using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;

namespace BSMinecraftServerManager
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Process javaProcess;

        public MainWindow()
        {
            InitializeComponent();
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //txtJre.Text = ExtensionMethods.GetJavaHome();
            this.LoadConfiguration();

            InitMenuItem();

            InitHighlighting();
        }

        void InitHighlighting()
        {
            XshdSyntaxDefinition xshd;

            using (Stream s = BSMinecraftServerManager.Resources.OpenStream("JavaLog.xshd"))
            {
                using (XmlTextReader reader = new XmlTextReader(s))
                {
                    xshd = HighlightingLoader.LoadXshd(reader);
                }
                txtEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd, HighlightingManager.Instance);
            }
        }

        void InitMenuItem()
        {
            var lan = (App.Current as App).Langueage;
            MenuItem mi = null;
            foreach (Langue element in Enum.GetValues(typeof(Langue)))
            {
                menuChangeLangue.Items.Add(mi = new MenuItem
                {
                    Header = element.ToString(),
                    DataContext = element,
                    IsCheckable = false
                });
                if (element == lan)
                {
                    mi.IsChecked = true;
                }
            }
        }

        void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            StartServer();
            (logView.Parent as TabControl).SelectedItem = logView;
        }

        void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            this.CloseJavaProcess();

        }


        void StartServer()
        {
            if (!this.VerifySettings())
                return;
            if (javaProcess == null)
            {
                javaProcess = new Process();
                JavaArgument jarg = new JavaArgument((int)maxMem.Value,
                    (int)minMem.Value,
                    txtJar.Text,
                    (bool)chkNogui.IsChecked ? "nogui" : string.Empty);
                var info = new ProcessStartInfo("java", jarg.ToString());//"-Xms512M -Xmx1024M -jar minecraft_server.1.8.jar nogui"
                info.WorkingDirectory = Path.GetDirectoryName(txtJar.Text);// "D:\\我的文档\\Downloads\\MC";
                info.UseShellExecute = false;
                info.RedirectStandardInput = true;
                info.RedirectStandardOutput = true;
                info.RedirectStandardError = true;
                string path = info.EnvironmentVariables["PATH"];
                string jre =txtJre.Text.Trim();// Path.GetDirectoryName()
                if (!path.Contains(jre))
                    info.EnvironmentVariables["PATH"] = path + ";" + jre;//C:\\Program Files\\Java\\jre7\\bin\\java
#if !DEBUG
				info.CreateNoWindow = true;
#endif
                javaProcess.StartInfo = info;
                javaProcess.OutputDataReceived += new DataReceivedEventHandler(javaProcess_OutputDataReceived);
                javaProcess.Start();
                javaProcess.BeginOutputReadLine();

            }
            else
            {

            }
        }

        bool closingJavaProcess = false;

        void CloseJavaProcess()
        {
            if (javaProcess != null && !closingJavaProcess)
            {
                javaProcess.StandardInput.WriteLine("stop");
                Thread t = new Thread(new ParameterizedThreadStart(KillJavaProcess));
                t.Start(javaProcess);
            }
        }

        void KillJavaProcess(object obj)
        {
            closingJavaProcess = true;
            Thread.Sleep(3000);
            if ((javaProcess != null) && !javaProcess.HasExited)
            {
                javaProcess.Kill();
                javaProcess.Dispose();
                javaProcess = null;
            }
            closingJavaProcess = false;
        }

        void javaProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data))
            {
                return;
            }
            Debug.WriteLine(e.Data);
            Dispatcher.Invoke(DispatcherPriority.Normal,
                              new Action(() =>
                              {
                                  txtEditor.AppendText(e.Data + "\r\n");
                              }
                                        ));
        }

        bool VerifySettings()
        {
            return true;
        }

        protected override void OnClosed(EventArgs e)
        {
            this.CloseJavaProcess();
            this.SaveConfiguration();
            base.OnClosed(e);
        }

        void LoadConfiguration()
        {
            maxMem.Value = short.Parse(ExtensionMethods.Settings[ExtensionMethods.MaxMemoryKey]);
            minMem.Value = short.Parse(ExtensionMethods.Settings[ExtensionMethods.MinMemoryKey]);

            txtJre.Text = ExtensionMethods.Settings[ExtensionMethods.JrePathKey];
            txtJar.Text = ExtensionMethods.Settings[ExtensionMethods.JarPathKey];

            chkNogui.IsChecked = bool.Parse(ExtensionMethods.Settings[ExtensionMethods.NoGUIKey]);
        }

        void SaveConfiguration()
        {

            ExtensionMethods.SaveConfiguration();
        }

        void MenuChangeLangue_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = e.OriginalSource as MenuItem;
            var val = (Langue)mi.DataContext;
            var oldVal = (App.Current as App).Langueage;
            if (val == oldVal)
            {
                return;
            }
            (App.Current as App).ChangeLanguage(val);
            foreach (MenuItem element in menuChangeLangue.Items)
            {
                if (element.IsChecked)
                {
                    element.IsChecked = false;
                    break;
                }
            }
            mi.IsChecked = true;
            //			Debug.WriteLine(sender);
        }

        void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            if (pg.SelectedObject == null)
            {
                pg.SelectedObject = SystemPara.CurrentProperties;
            }
        }

        private void SelectFileCommond_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string para = (e.Parameter as string);
            TextBox txtbox = null;

            if (string.IsNullOrEmpty(para))
            {
                para = "Launcher";
                txtbox = txtJar;
            }
            else if (para == "JrePath")
            {
                txtbox = txtJre;
            }
            else
            {
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = TryFindResource(para + "Filter") as string;// "Java控制台|java.exe";
            ofd.Title = TryFindResource(para + "Title") as string;
            if ((bool)ofd.ShowDialog())
            {
                txtbox.Text = ofd.FileName;
            };
        }

    }


}