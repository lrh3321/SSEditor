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
    public enum Proficiency : int
    {
        None = 0,
        E = 1,
        D = 51,
        C = 101,
        B = 151,
        A = 201,
        S = 251,
        Star = short.MaxValue
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

    [Flags]
    public enum ItemType : int
    {
        /// <summary>消耗品</summary>
        Consumables = 0x010,
        /// <summary>饰品</summary>
        Accessory = 0x100,
        /// <summary>武器</summary>
        Weapon = 0x1000,
        /// <summary>剑</summary>
        Sword = 0x1001,
        /// <summary>斧</summary>
        Axe = 0x1002,
        /// <summary>枪</summary>
        Spear = 0x1003,
        /// <summary>弓</summary>
        Bowl = 0x2000,
        /// <summary>魔导书</summary>
        MagicBook = 0x4000,
        /// <summary>石</summary>
        Stone = 0x8000,
        /// <summary>魔杖</summary>
        Staff = 0x10000
    }
}
