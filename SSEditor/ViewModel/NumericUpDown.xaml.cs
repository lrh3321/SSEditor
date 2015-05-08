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
using System.Windows.Markup;

namespace SSEditor.ViewModel
{
	[ContentProperty("Value")]
	public partial class NumericUpDown //:ContentControl,INotifyPropertyChanged
	{
		public NumericUpDown()
		{
			this.InitializeComponent();
		}
        //public int Value
        //{
        //	get { return numericValue; }
        //	set
        //	{
        //		numericValue = value;
        //		NotifyPropertyChanged("Value");
        //	}
        //}
        #region DependencyProperties
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown), new FrameworkPropertyMetadata(0));

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty IncrementProperty =
			DependencyProperty.Register("Increment", typeof(int), typeof(NumericUpDown),
			                            new FrameworkPropertyMetadata(1));
		
		public int Increment {
			get { return (int)GetValue(IncrementProperty); }
			set { SetValue(IncrementProperty, value); }
		}
		public static readonly DependencyProperty MaxValueProperty =
			DependencyProperty.Register("MaxValue", typeof(int), typeof(NumericUpDown),
			                            new FrameworkPropertyMetadata(int.MaxValue));

		public int MaxValue {
			get { return (int)GetValue(MaxValueProperty); }
			set { SetValue(MaxValueProperty, value); }
		}

		public static readonly DependencyProperty MinValueProperty =
			DependencyProperty.Register("MinValue", typeof(int), typeof(NumericUpDown),
			                            new FrameworkPropertyMetadata(0));

		public int MinValue {
			get { return (int)GetValue(MinValueProperty); }
			set { SetValue(MinValueProperty, value); }
		}
        #endregion

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            Increase();
        }
        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            Decrease();
        }
        private void Increase()
        {
				int newValue = (Value + Increment);
				Value=Math.Min(newValue,MaxValue);
        }
        private void Decrease()
        {
            int newValue = (Value - Increment);
            Value = Math.Max(newValue, MinValue);
        }

        //private void UpButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    Increase();
        //}

        //private void DownButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    Decrease();
        //}
		private void ValueText_LostFocus(object sender, RoutedEventArgs e)
		{
			int numericValue=0;
			int.TryParse(ValueText.Text,out numericValue);
			Value=numericValue;
		}
		
		private void ValueText_PreViewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key== Key.Up) {
                Increase();
                e.Handled=true;
			}else if (e.Key==Key.Down) {
                Decrease();
				e.Handled=true;
			}
		}


        //#region INotifyPropertyChanged Members
        //public event PropertyChangedEventHandler PropertyChanged;
        //public void NotifyPropertyChanged(string propertyName)
        //{
        //	if (PropertyChanged != null)
        //	{
        //		PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //	}
        //}		
        //#endregion

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
			return value.ToString();
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