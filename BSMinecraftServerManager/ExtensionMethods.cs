/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 2015-7-31
 * 时间: 8:45
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using System.Configuration;
using System.Xml.Linq;

namespace BSMinecraftServerManager
{
	/// <summary>
	/// Description of ExtensionMethods.
	/// </summary>
	internal static class ExtensionMethods
	{
		static ExtensionMethods()
		{
			LoadConfiguration();
		}
		const string JRE =@"SOFTWARE\JavaSoft\Java Runtime Environment";
		const string JRE64 =@"SOFTWARE\wow6432node\JavaSoft\Java Runtime Environment";
		const string CONFIG = "bs.config";
		
		public static string GetJavaHome(){
			string ret = string.Empty;
			try {
				if (Environment.Is64BitOperatingSystem) {
					ret = GetJavaHome64();
					return ret;
				}
				var reg = Registry.LocalMachine.OpenSubKey(JRE,false);
				string key = reg.GetValue("CurrentVersion",string.Empty) as string;
				ret = reg.OpenSubKey(key,false).GetValue("JavaHome",string.Empty) as string;
				reg.Dispose();
			} catch (Exception) {
				
				return string.Empty;
			}
			return ret;
		}
		
		static string GetJavaHome64(){
			var jre = Registry.LocalMachine.OpenSubKey(JRE64,false);
			string CurrentVersion = jre.GetValue("CurrentVersion",string.Empty) as string;
			string path = jre.OpenSubKey(CurrentVersion,false).GetValue("JavaHome",string.Empty) as string;
			
			jre.Dispose();
			return path;
		}
		
		static Setting setting;
		static void LoadConfiguration(){
			if (File.Exists(CONFIG)) {
				setting = new Setting(XElement.Load(CONFIG));
			}else{
				setting =new Setting();
			}
		}
		
		public static void SaveConfiguration(){
			setting.Save(CONFIG);
		}

		public static Setting Settings{
			get{
				return setting;
			}
		}
	}

	internal class Setting{
		XElement Root;
		
		public Setting():this(new XElement("configuration"))
		{			
		}
		
		public Setting(XElement root)
		{
			this.Root = root;
		}
		
		public void Save(string filename){
			this.Root.Save(filename);
		}
		
		public string this[string name]{
			get{
				var element = Root.Element(name);
				if (element!=null) {
					return element.Value;
				}else{
					return string.Empty;
				}
			}
			set{
				var element = Root.Element(name);
				if (element!=null) {
					element.Value = value;
				}else{
					Root.Add(new XElement(name,value));
				}
			}
		}
	}
}
