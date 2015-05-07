/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 2015-5-7
 * 时间: 11:11
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace SSEditor.Object
{
	/// <summary>
	/// 装备熟练度
	/// </summary>
	public enum Proficiency:int{
		None=0,
		E=1,
		D=51,
		C=101,
		B=151,
		A=201,
		S=251,
		Star=short.MaxValue
	}
}
