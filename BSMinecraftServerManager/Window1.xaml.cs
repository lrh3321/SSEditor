/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 2015-7-28
 * 时间: 9:48
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
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

using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;

namespace BSMinecraftServerManager
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		Process javaProcess;
		
		public Window1()
		{
			InitializeComponent();
		}
		
		void Window_Loaded(object sender, RoutedEventArgs e)
		{
//			pg.SelectedObject = SystemPara.CurrentProperties;
			
//			System.Diagnostics.Debug.WriteLine( SystemPara.CurrentProperties.Serialize());
			
//			mLan.ItemsSource =Enum.GetNames(typeof(Langue));
			txtJre.Text = ExtensionMethods.GetJavaHome();
			var lan = (App.Current as App).Langueage;
			MenuItem mi = null;
			foreach (Langue element in Enum.GetValues(typeof(Langue))) {
				menuChangeLangue.Items.Add(
					mi=new MenuItem(){
						Header = element.ToString(),
						DataContext = element,
						IsCheckable = false
					}
				);
				if (element == lan) {
					mi.IsChecked =true;
				}
			}
			
			XshdSyntaxDefinition xshd;
			
			using (Stream s = BSMinecraftServerManager.Resources.OpenStream("JavaLog.xshd")) {
				using (XmlTextReader reader = new XmlTextReader(s)) {
					xshd = HighlightingLoader.LoadXshd(reader);
				}
//			HighlightingManager.Instance.RegisterHighlighting("",null,
				txtEditor.SyntaxHighlighting = HighlightingLoader.Load(xshd,HighlightingManager.Instance);
			}
		}
		
		void BtnStart_Click(object sender, RoutedEventArgs e)
		{
			if (javaProcess==null) {
				javaProcess=new Process();
				var info=new ProcessStartInfo(@"java","-Xms512M -Xmx1024M -jar minecraft_server.1.8.jar nogui");
				info.WorkingDirectory =@"D:\我的文档\Downloads\MC";
				info.UseShellExecute =false;
				info.RedirectStandardInput =true;
				info.RedirectStandardOutput =true;
				info.RedirectStandardError =true;
				string path = info.EnvironmentVariables["PATH"];
				if (!path.Contains("jre"))
					info.EnvironmentVariables["PATH"]=path+@";C:\Program Files\Java\jre7\bin\java";
				#if !DEBUG
				info.CreateNoWindow=true;
				#endif
				javaProcess.StartInfo = info;
				javaProcess.OutputDataReceived+= new DataReceivedEventHandler(javaProcess_OutputDataReceived);
				javaProcess.Start();
				javaProcess.BeginOutputReadLine();

			}else{
				
			}
			
		}
		
		void BtnStop_Click(object sender, RoutedEventArgs e)
		{
			if (javaProcess!=null) {
				javaProcess.StandardInput.WriteLine("stop");
				javaProcess.WaitForExit();
				javaProcess = null;
//				for (int i = 1; i < 10; i++) {
//					javaProcess.StandardInput.WriteLine("help "+i.ToString());
//				}
			}
			
		}

		void javaProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			if (string.IsNullOrEmpty(e.Data)) {
				return;
			}
			Debug.WriteLine(e.Data);
			Dispatcher.Invoke(DispatcherPriority.Normal,
			                  new Action(()=>{
			                             	txtEditor.AppendText(e.Data+"\r\n");
			                             }
			                            ));
		}
		
		bool VerifySettings(){
			return true;
		}
		
		protected override void OnClosed(EventArgs e)
		{
			if (javaProcess!=null) {
				javaProcess.StandardInput.WriteLine("stop");
				javaProcess.WaitForExit();
			}

			base.OnClosed(e);
		}
		
		void MenuChangeLangue_Click(object sender, RoutedEventArgs e)
		{
			MenuItem mi = e.OriginalSource as MenuItem;
			var val = (Langue)mi.DataContext;
			var oldVal = (App.Current as App).Langueage;
			if (val == oldVal) {
				return;
			}
			(App.Current as App).ChangeLanguage( val);
			foreach (MenuItem element in menuChangeLangue.Items) {
				if (element.IsChecked) {
					element.IsChecked = false;
					break;
				}
			}
			mi.IsChecked = true;
//			Debug.WriteLine(sender);
		}
		
		void TabItem_GotFocus(object sender, RoutedEventArgs e)
		{
			if (pg.SelectedObject == null) {
				pg.SelectedObject = SystemPara.CurrentProperties;
			}
		}
		
	}
	

}