/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 05/06/2015
 * 时间: 14:22
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace SSEditor.ViewModel
{
	/// <summary>
	/// Interaction logic for NumericPair.xaml
	/// </summary>
	public partial class NumericPair
	{
		public NumericPair()
		{
			InitializeComponent();
		}
		#region "DependencyProperties"
		
		public static readonly DependencyProperty PropertyPropertyValueProperty =
			DependencyProperty.Register("PropertyPropertyValue", typeof(int), typeof(NumericPair),
			                            new FrameworkPropertyMetadata());
		
		public int PropertyValue {
			get { return (int)GetValue(PropertyPropertyValueProperty); }
			set { SetValue(PropertyPropertyValueProperty, value); }
		}
		
		public static readonly DependencyProperty PropertyLimitProperty =
			DependencyProperty.Register("PropertyLimit", typeof(int), typeof(NumericPair),
			                            new FrameworkPropertyMetadata());
		
		public int PropertyLimit {
			get { return (int)GetValue(PropertyLimitProperty); }
			set { SetValue(PropertyLimitProperty, value); }
		}
		
		public static readonly DependencyProperty GrowthRateProperty =
			DependencyProperty.Register("GrowthRate", typeof(int), typeof(NumericPair),
			                            new FrameworkPropertyMetadata());
		
		public int GrowthRate {
			get { return (int)GetValue(GrowthRateProperty); }
			set { SetValue(GrowthRateProperty, value); }
		}
		#endregion
	}
}