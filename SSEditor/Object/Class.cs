/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 2015-5-6
 * 时间: 11:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace SSEditor.Object
{
	/// <summary>
	/// Description of Class.
	/// </summary>
	public class Class
	{
		public Class()
		{
			this.propertyBasic=new int[PROPERTY_COUNT];
			this.propertyLimit=new int[PROPERTY_COUNT];
			this.growRate=new int[PROPERTY_COUNT];
		}
		
		public const int PROPERTY_COUNT=9;
		public string ID{get;set;}
		
		public int[] propertyBasic;
		public int[] propertyLimit;
		public int[] growRate;
	}
	
	public enum PropertyType:int{
		Health,
		Strength,
		MagicPower,
		Techique,
		Agility,
		Lucky,
		Defence,
		MagicDefence,
		Move
	}
}
