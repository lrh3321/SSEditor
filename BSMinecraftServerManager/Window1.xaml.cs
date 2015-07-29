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

namespace BSMinecraftServerManager
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}
		
		void Window_Loaded(object sender, RoutedEventArgs e)
		{
			pg.SelectedObject = SystemPara.CurrentProperties;
			
			System.Diagnostics.Debug.WriteLine( SystemPara.CurrentProperties.Serialize());
		}
	}
}