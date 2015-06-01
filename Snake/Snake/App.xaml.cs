using System;
using System.Windows;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Globalization;

namespace Snake
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		Langue m_lan;
		public Langue Langueage{get{return m_lan;}}
		
		protected override void OnStartup(StartupEventArgs e)
		{
			m_lan=Langue.ENU;
			string lan=CultureInfo.CurrentCulture.ThreeLetterWindowsLanguageName;
			//lan ="ENU";
			Langue l=Langue.ENU;
			Enum.TryParse<Langue>(lan,out l);
			if (l!=m_lan) {
				ChangeLanguage(l);
			}
			//var dict=(ResourceDictionary)this.
			base.OnStartup(e);
		}
		
		public void ChangeLanguage(Langue lan)
		{
			this.Resources.BeginInit();
			//if (Enum.IsDefined(typeof(Langue),lan))
			{
				if (this.Resources.MergedDictionaries.Count > 0)
				{
					this.Resources.MergedDictionaries.RemoveAt(0);
				}
				this.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/Snake;component/Translations/"+lan.ToString()+".xaml") });
			}

			this.Resources.EndInit();
		}
	}
	public enum Langue:int {
		ENU=0,
		CHS,
		CHT
	}
}