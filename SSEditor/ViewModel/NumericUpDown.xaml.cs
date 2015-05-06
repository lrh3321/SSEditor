/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 05/06/2015
 * 时间: 11:16
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace SSEditor.ViewModel
{
	public partial class NumericUpDown : INotifyPropertyChanged
	{
		private int numericValue = 0;
		public NumericUpDown()
		{
			this.InitializeComponent();
		}
		public int Value
		{
			get { return numericValue; }
			set
			{
				numericValue = value;
				NotifyPropertyChanged("Value");
			}
		}

		public int Increment { get; set; }

		public int MaxValue { get; set; }

		public int MinValue { get; set; }

		private void UpButton_Click(object sender, RoutedEventArgs e)
		{
			int newValue = (Value + Increment);
			if (newValue > MaxValue)
			{
				Value = MaxValue;
			}
			else
			{
				Value = newValue;
			}
		}
		private void DownButton_Click(object sender, RoutedEventArgs e)
		{
			int newValue = (Value - Increment);
			if (newValue < MinValue)
			{
				Value = MinValue;
			}
			else
			{
				Value = newValue;
			}
		}
		private void ValueText_LostFocus(object sender, RoutedEventArgs e)
		{
			Value=0;
			int.TryParse(ValueText.Text,out Value);
		}
		#region INotifyPropertyChanged Members
		public event PropertyChangedEventHandler PropertyChanged;
		public void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion

	}

	[ValueConversion(typeof(int), typeof(string))]
	public class IntegerValueConverter : IValueConverter
	{
		#region IValueConverter Members
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value==null) {
				return "0";
			}
			return (string)value;
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			int r=0;
			int.TryParse((string)value,out r);
			return r;
		}
		#endregion
	}
}