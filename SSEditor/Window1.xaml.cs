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
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using SSEditor.ViewModel;

namespace SSEditor
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ObservableCollection<Object.Class> m_classList;
        NumericPair[] pairs;

        public Window1()
        {
            InitializeComponent();

            pairs = new NumericPair[9];

            for (int i = 0; i < 9; i++)
            {
                pairs[i] = (NumericPair)this.FindName("np" + i.ToString());
            }

            this.Loaded += Window1_Loaded;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            m_classList = new ObservableCollection<Object.Class>();
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