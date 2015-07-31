/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 2015-7-28
 * 时间: 9:48
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace BSMinecraftServerManager
{
	public struct JavaArgument{
		public int MaxMemorySize;
		public int MinMemorySize;		
		public string JarFile;
		public string Extras;
		
		public JavaArgument(int maxMemorySize, int minMemorySize, string extras, string jarFile)
		{
			this.MaxMemorySize = maxMemorySize;
			this.MinMemorySize = minMemorySize;
			this.Extras = extras;
			this.JarFile = jarFile;
		}
		
		public override string ToString()
		{
			//-Xms512M -Xmx1024M -jar minecraft_server.1.8.jar nogui
			return string.Format("-Xmx{0}M -Xms{1}M -jar \"{2}\" {3}", MaxMemorySize, MinMemorySize, JarFile, Extras);
		}

	}
}
