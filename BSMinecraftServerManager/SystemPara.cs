/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 07/28/2015
 * 时间: 09:50
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace BSMinecraftServerManager
{
	internal static class SystemPara{
		static ServerProperties _current =new ServerProperties();
		public static ServerProperties CurrentProperties{
			get{
				return _current;
			}
		}
	}
}