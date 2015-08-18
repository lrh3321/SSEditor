using Microsoft.Win32;
using SSEditor.ViewModel;
/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 2015-5-5
 * 时间: 15:56
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using System.Xml.Serialization;

namespace SSEditor
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Object.ClassCollection m_classList;
        NumericPair[] pairs;
        ComboBox[] cbos;
        ToggleButton[] chks;

        public string FileNmae { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Init();
        }

        private void Init()
        {
            string[] arr = new string[] { "剑", "枪", "斧", "弓", "魔", "杖", "石" };
            cbos = new ComboBox[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                var b = new BulletDecorator();
                b.Bullet = new TextBlock() { Text = arr[i] };
                b.Child = cbos[i] = new ComboBox();
                proficContainer.Children.Add(b);
            }
            
            arr = new string[] { "HP", "力量", "魔力", "技术", "速度", "守备", "魔防", "幸运", "移动" };
            pairs = new NumericPair[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                pairs[i] = new NumericPair() { Header = arr[i] };
                Grid.SetColumn(pairs[i], i % 3 + 2);
                Grid.SetRow(pairs[i], i / 3 + 1);
                layoutRoot.Children.Add(pairs[i]);
            }

            arr = new string[] { "步兵", "骑兵", "飞兵", "重甲", "法师", "龙系", "魔物" };
            chks = new ToggleButton[arr.Length];
            for (int i = 0; i < 3; i++)
            {
                chks[i] = new RadioButton();
                chks[i].DataContext = (Object.ClassTypes)(i + 1);
                chks[i].Content = arr[i];
                clstype.Children.Add(chks[i]);
            }
            chks[0].IsChecked = true;
            clstype.Children.Add(new CheckBox() { Visibility = Visibility.Hidden, Content = "空白" });
            for (int i = 3; i < arr.Length; i++)
            {
                chks[i] = new CheckBox();
                chks[i].DataContext = (Object.ClassTypes)(1 << i);
                chks[i].Content = arr[i];
                clstype.Children.Add(chks[i]);
            }

            this.Loaded += MainWindow_Loaded;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            m_classList = new Object.ClassCollection();

            //LoadScript();
            lstClass.ItemsSource = m_classList;
            lstClass.SelectionChanged += LstClass_SelectionChanged;
        }

        private void LstClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstClass.SelectedItem != null && lstClass.SelectedItem is Object.Class)
            {
                LoadObjectClass((Object.Class)lstClass.SelectedItem);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            m_classList.Add(new Object.Class());
            lstClass.SelectedIndex = m_classList.Count - 1;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            m_classList.Remove((Object.Class)lstClass.SelectedItem);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (lstClass.SelectedItem != null && lstClass.SelectedItem is Object.Class)
            {
                SaveObjectClass((Object.Class)lstClass.SelectedItem);
            }
        }
        const string FILTER = "XML文件(*.xml)|*.xml|文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
        void LoadScript()
        {
            OpenFileDialog ofd = new OpenFileDialog { CheckFileExists = true, Filter = FILTER };
            if ((bool)ofd.ShowDialog())
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(ofd.FileName);
                    var root = doc.DocumentElement;
                    XmlNode t = root.FirstChild;
                    Object.Class tc;
                    while (t != null)
                    {
                        switch (t.Name)
                        {
                            case Utility.CLASS_DEFINE:
                                m_classList.Add(tc = new Object.Class());
                                tc.ID = t.Attributes["ID"].Value;
                                tc.propertyBasic = t.GetArray("Basic");
                                tc.propertyLimit = t.GetArray("Limit");
                                tc.growRate = t.GetArray("Growth");
                                tc.Proficiencies = t.GetArray("Proficiencies", Utility.PROFICIENCY_COUNT);
                                tc.Type = (Object.ClassTypes)Enum.Parse(typeof(Object.ClassTypes), t.Attributes["Type"].Value);
                                break;
                            case Utility.UNIT_DEFINE:

                                break;
                            case Utility.NAME_DEFINE:

                                break;
                            case Utility.DESCR_DEFINE:

                                break;
                            default:

                                break;
                        }
                        t = t.NextSibling;
                    }
                    this.FileNmae = ofd.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void LoadObjectClass(Object.Class cls)
        {
            for (int i = 0; i < 9; i++)
            {
                pairs[i].PropertyValue = cls.propertyBasic[i];
                pairs[i].PropertyLimit = cls.propertyLimit[i];
                pairs[i].GrowthRate = cls.growRate[i];
            }

            for (int i = 0; i < cbos.Length; i++)
            {
                cbos[i].SelectedItem = (Object.Proficiency)cls.Proficiencies[i];
            }

            for (int i = 0; i < 3; i++)
            {
                chks[i].IsChecked = ((cls.Type & Object.ClassTypes.AirForce) == (Object.ClassTypes)chks[i].DataContext);
            }
            for (int i = 3; i < chks.Length; i++)
            {
                chks[i].IsChecked = ((cls.Type & (Object.ClassTypes)chks[i].DataContext) != Object.ClassTypes.None);
            }

            txtName.Text = cls.Name;
            txtDescription.Text = cls.Description;
        }
        void SaveScript()
        {
            string dest = string.Empty;
            if (string.IsNullOrEmpty(this.FileNmae))
            {
                SaveFileDialog sfd = new SaveFileDialog() { Filter = FILTER };
                if ((bool)sfd.ShowDialog())
                    this.FileNmae = sfd.FileName;
                else
                    return;
            }
            dest = this.FileNmae;
            XmlDocument doc = new XmlDocument();
            var root = doc.CreateElement("Root");
            XmlElement t;
            Utility.UpdateDict(m_classList);
            foreach (var element in m_classList)
            {
                t = doc.CreateElement(Utility.CLASS_DEFINE);
                t.SetAttribute("ID", element.ID);
                t.SetAttribute("Basic", element.propertyBasic.ArrayToString());
                t.SetAttribute("Limit", element.propertyLimit.ArrayToString());
                t.SetAttribute("Growth", element.growRate.ArrayToString());
                t.SetAttribute("Proficiencies", element.Proficiencies.ArrayToString());
                t.SetAttribute("Type", ((int)element.Type).ToString());
                root.AppendChild(t);
            }
            doc.AppendChild(root);
            doc.Save(dest);
        }
        private void SaveObjectClass(Object.Class cls)
        {
            for (int i = 0; i < 9; i++)
            {
                cls.propertyBasic[i] = pairs[i].PropertyValue;
                cls.propertyLimit[i] = pairs[i].PropertyLimit;
                cls.growRate[i] = pairs[i].GrowthRate;
            }

            for (int i = 0; i < cbos.Length; i++)
            {
                cls.Proficiencies[i] = (int)(Enum.Parse(typeof(Object.Proficiency), (string)cbos[i].SelectedItem));
            }

            Object.ClassTypes ct = Object.ClassTypes.None;
            for (int i = 0; i < 3; i++)
            {
                if ((bool)chks[i].IsChecked) ct = (Object.ClassTypes)chks[i].DataContext;
            }

            for (int i = 3; i < chks.Length; i++)
            {
                if ((bool)chks[i].IsChecked) ct |= (Object.ClassTypes)chks[i].DataContext;
            }
            cls.Type = ct;
            cls.Name = txtName.Text;
            cls.Description = txtDescription.Text;
            
            var s =new XmlSerializer(typeof(Object.ClassCollection));
            StringWriter writer =new StringWriter();
            
            
            s.Serialize(writer, m_classList);
            
            StringReader reader =new StringReader(writer.ToString());
            System.Diagnostics.Debug.WriteLine(writer.ToString());
            
//            var c2 = s.Deserialize(reader);
//            System.Diagnostics.Debug.WriteLine(c2);
            
        }


        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtComLine.Text))
            {
                return;
            }
            var arr = Utility.StringToArray(txtComLine.Text, ' ');
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i < arr.Length; i++)
                    {
                        pairs[i].PropertyValue = arr[i];
                    }
                    break;
                case 1:
                    for (int i = 0; i < arr.Length - 2; i++)
                    {
                        pairs[i].PropertyLimit = arr[i];
                    }
                    break;
                case 2:
                    for (int i = 0; i < arr.Length - 2; i++)
                    {
                        pairs[i].GrowthRate = arr[i];
                    }
                    break;
                default:
                    return;
            }
        }
    
        #region "CommandBindings"
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.FileNmae))
            {
                switch (MessageBox.Show("是否保存当前脚本？", "警告", MessageBoxButton.YesNoCancel, MessageBoxImage.Asterisk, MessageBoxResult.Cancel))
                {
                    case MessageBoxResult.Cancel:
                        return;
                    case MessageBoxResult.Yes:
                        SaveScript();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            LoadScript();
        }
        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveScript();
        }
        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog().Value)
            {
                this.FileNmae = sfd.FileName;
                SaveScript();
            }
        }
        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void UndoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void RedoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        #endregion
    }
}