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
		public Class():this("新建职业")
		{
		}

        public Class(string name)
        {
            Name = name;
			this.propertyBasic=new int[PROPERTY_COUNT];
			this.propertyLimit=new int[PROPERTY_COUNT];
            for (int i = 0; i < PROPERTY_COUNT; i++)
            {
                propertyLimit[i] = 20;
            }
			this.growRate=new int[PROPERTY_COUNT];
        }

		public const int PROPERTY_COUNT=9;
		public string ID{get;set;}
		
        public string Name { get; set; }
        public string Description { get; set; }

        public int[] propertyBasic;
		public int[] propertyLimit;
		public int[] growRate;
        public override string ToString()
        {
            return this.Name;
        }
    }

    public enum PropertyType : int
    {
        /// <summary>HP</summary>
        Health,
        /// <summary>力量</summary>
        Strength,
        /// <summary>魔力</summary>
        MagicPower,
        /// <summary>技术</summary>
        Techique,
        /// <summary>速度</summary>
        Agility,
        /// <summary>幸运</summary>
        Lucky,
        /// <summary>守备</summary>
        Defence,
        /// <summary>魔防</summary>
        MagicDefence,
        /// <summary>移动</summary>
        Move,
        /// <summary>最大HP</summary>
        MaxHP
    }

    public enum ItemType : int
    {
        /// <summary>消耗品</summary>
        Consumables = 0x0100,
        /// <summary>武器</summary>
        Weapon = 0x1000,
        /// <summary>剑</summary>
        Sword,
        /// <summary>斧</summary>
        Axe,
        /// <summary>枪</summary>
        Spear,
        /// <summary>魔导书</summary>
        MagicBook = 0x2000,
        /// <summary>石</summary>
        Stone = 0x4000,
        /// <summary>魔杖</summary>
        Staff = 0x8000,
        /// <summary>饰品</summary>
        Accessory = 0x10000
    }
}
