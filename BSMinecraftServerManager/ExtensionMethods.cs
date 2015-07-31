/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 2015-7-31
 * 时间: 8:45
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using Microsoft.Win32;

namespace BSMinecraftServerManager
{
	/// <summary>
	/// Description of ExtensionMethods.
	/// </summary>
	internal static class ExtensionMethods
	{
		static ExtensionMethods()
		{
		}
		const string JRE =@"SOFTWARE\JavaSoft\Java Runtime Environment";
		const string JRE64 =@"SOFTWARE\wow6432node\JavaSoft\Java Runtime Environment";
		
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
	}
}
