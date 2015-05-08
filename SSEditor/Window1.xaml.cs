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
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using SSEditor.ViewModel;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using Microsoft.Win32;

namespace SSEditor
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		ObservableCollection<Object.Class> m_classList;
		NumericPair[] pairs;
		ComboBox[] cbos;
		public string FileNmae{get;set;}
		
		public Window1()
		{
			InitializeComponent();
			
			string []arr = new string[] { "剑", "枪", "斧", "弓", "魔", "杖", "石" };
			cbos = new ComboBox[arr.Length];
			for (int i = 0; i < arr.Length; i++)
			{
				var b = new BulletDecorator();
				b.Bullet = new TextBlock() { Text = arr [i]};
				b.Child =cbos[i]= new ComboBox();
				proficContainer.Children.Add(b);
			}

			pairs = new NumericPair[9];

			for (int i = 0; i < 9; i++)
			{
				pairs[i] = (NumericPair)this.FindName("np" + i.ToString());
			}

			this.Loaded += Window1_Loaded;
		}

		protected override void OnClosing(CancelEventArgs e)
		{

			SaveScript();
			
			base.OnClosing(e);
		}

		private void Window1_Loaded(object sender, RoutedEventArgs e)
		{
			m_classList = new ObservableCollection<Object.Class>();
			
			LoadScript();
			lstClass.ItemsSource = m_classList;
			lstClass.SelectionChanged += LstClass_SelectionChanged;
		}

		void SaveScript()
		{
			var temp = Path.GetTempFileName();
			string dest = string.Empty;
			if (string.IsNullOrEmpty(this.FileNmae)) {
				SaveFileDialog sfd = new SaveFileDialog();
				if (sfd.ShowDialog().Value) {
					this.FileNmae=sfd.FileName;
				}else{
					return;
				}
			}
			if (File.Exists(dest)) {
				File.Delete(dest);
			}
			XmlDocument doc = new XmlDocument();
			var root = doc.CreateElement("Root");
			XmlElement t;
			Utility.UpdateDict(m_classList);
			foreach (var element in m_classList) {
				t = doc.CreateElement(Utility.CLASS_DEFINE);
				t.SetAttribute("ID", element.ID);
				t.SetAttribute("Basic", element.propertyBasic.ArrayToString());
				t.SetAttribute("Limit", element.propertyLimit.ArrayToString());
				t.SetAttribute("Growth", element.growRate.ArrayToString());
				root.AppendChild(t);
			}
			doc.AppendChild(root);
			doc.Save(dest);
			
//			File.Move(temp, dest);
		}

		void LoadScript()
		{
			OpenFileDialog ofd = new OpenFileDialog { CheckFileExists = true };
			if ((bool)ofd.ShowDialog()) {
				XmlDocument doc = new XmlDocument();
				doc.Load(ofd.FileName);
				var root = doc.DocumentElement;
				XmlNode t = root.FirstChild;
				Object.Class tc;
				while (t != null) {
					switch (t.Name) {
						case Utility.CLASS_DEFINE:
							m_classList.Add(tc = new Object.Class());
							tc.ID = t.Attributes["ID"].Value;
							tc.propertyBasic = t.GetArray("Basic");
							tc.propertyLimit = t.GetArray("Limit");
							tc.growRate = t.GetArray("Growth");
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
			}
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
			//System.Diagnostics.Debug.WriteLine("{0:x},{1:x},{2:x}",(int)Object.ItemType.Sword,(int)Object.ItemType.Axe,(int)Object.ItemType.Spear);
		}
		private void LoadObjectClass(Object.Class cls)
		{
			for (int i = 0; i < 9; i++)
			{
				pairs[i].PropertyValue = cls.propertyBasic[i];
				pairs[i].PropertyLimit = cls.propertyLimit[i];
				pairs[i].GrowthRate = cls.growRate[i];
			}
			txtName.Text = cls.Name;
			txtDescription.Text = cls.Description;
		}
		private void SaveObjectClass(Object.Class cls)
		{
			for (int i = 0; i < 9; i++)
			{
				cls.propertyBasic[i] = pairs[i].PropertyValue;
				cls.propertyLimit[i] = pairs[i].PropertyLimit;
				cls.growRate[i] = pairs[i].GrowthRate;
			}
			cls.Name = txtName.Text;
			cls.Description = txtDescription.Text;
		}
	}
}