/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 2015-7-28
 * 时间: 11:30
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace BSMinecraftServerManager
{

	
	/// <summary>
	/// 定义服务器的游戏难度（例如生物对玩家造成的伤害，饥饿与中毒对玩家的影响方式等）。
	/// </summary>
	public enum Difficulty:int{
		/// <summary>
		/// 和平
		/// </summary>
		Peaceful=0,
		/// <summary>
		/// 简单
		/// </summary>
		Easy=1,
		/// <summary>
		/// 普通
		/// </summary>
		Normal=2,
		/// <summary>
		/// 困难
		/// </summary>
		Hard=3
	}
	
	/// <summary>
	/// 定义默认游戏模式
	/// </summary>
	public enum GameMode:int{
		/// <summary>
		/// 生存模式
		/// </summary>
		Survival=0,
		/// <summary>
		/// 创造模式
		/// </summary>
		Creative=1,
		/// <summary>
		/// 冒险模式（仅在12w22a之后，或正式版1.3之后可用）
		/// </summary>
		Adventure=2,
		/// <summary>
		/// 旁观模式（仅在14w05a之后，或正式版1.8之后可用）
		/// </summary>
		Spectator=3
	}
	
	public enum LevelType{
		/// <summary>
		/// 标准的世界带有丘陵，河谷，海洋等
		/// </summary>
		DEFAULT,
		/// <summary>
		/// 一个没有特色的平坦世界，适合用于建设
		/// </summary>
		FLAT,
		/// <summary>
		/// 如同预设世界，但所有生态系都更大（仅快照12w19a，或正式版1.3之后可用）
		/// </summary>
		LARGEBIOMES,
		/// <summary>
		/// 如同预设世界，但世界生成高度提高（仅快照13w36a，或正式版1.7.2之后可用）
		/// </summary>
		AMPLIFIED,
		/// <summary>
		/// 自快照14w21b以来，服务器也支持自定义地形。使用方法是在generator-settings贴上代码。
		/// </summary>
		CUSTOMIZED
	}
	
}
