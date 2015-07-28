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
	/// <summary>
	/// 为Minecraft服务端用于配置多人游戏所有参数的文件。
	/// </summary>
	public class ServerProperties:ITextSerializable
	{
		
		
		public ServerProperties()
		{
//			PropertyInfo[] propertyInfos = typeof(ServerProperties).GetProperties();
//			Attribute.GetCustomAttribute(null,typeof(DisplayNameAttribute),false);
		}
		
		#region Properties
		
		bool allow_flight=false;
		bool allow_nether=true;
		bool announce_player_achievements = true;
		Difficulty difficulty= Difficulty.Easy;
		bool enable_query = false;
		bool enable_rcon = false;
		bool enable_command_block = false;
		GameMode gamemode = GameMode.Survival;
		bool generate_structures=true;
		string generator_settings=string.Empty;
		bool hardcore =false;
		string level_name ="world";
		string level_seed=string.Empty;
		LevelType level_type=LevelType.DEFAULT;
		int max_build_height=256;
		int max_players =20;
		int max_tick_time=60000;
		int max_world_size=29999984;
		string motd="A Minecraft Server";
		bool online_mode =true;
		int op_permission_level=4;
		int player_idle_timeout=0;
		string texture_pack	=string.Empty;
		string resource_pack_hash=string.Empty;
		bool pvp =true;
		ushort query_port =25565;
		string rcon_password=string.Empty;
		ushort rcon_port=25575;
		string server_ip=string.Empty;
		ushort server_port=25565;
		
		/// <summary>
		/// 允许玩家在安装添加飞行功能的 mod 前提下在生存模式下飞行。
		///	允许飞行可能会使作弊者更加常见，因为此设定会使他们更容易达成目的。在创造模式下本属性不会有任何作用。
		/// </summary>
		/// <returns>
		/// false - 不允许飞行。悬空超过5秒的玩家会被踢出服务器。
		///	true - 允许飞行。玩家得以使用飞行MOD飞行。
		///</returns>
		[Category("Information")]
		[DisplayName("allow-flight")]
		[Description("允许玩家在安装添加飞行功能的 mod 前提下在生存模式下飞行。")]
		[Editor(typeof(CheckBoxEditor), typeof(CheckBoxEditor))]
		public bool AllowFlight {
			get{return this.allow_flight;}
			set{allow_flight = value;}
		}
		
		/// <summary>
		/// 允许玩家进入下界
		/// </summary>
		/// <returns>
		/// false - 下界传送门不会生效。
		///	true - 玩家可以通过下界传送门前往下界。
		///</returns>
		[Category("Information")]
		[DisplayName("allow-nether")]
		[Description("允许玩家进入下界")]
		[Editor(typeof(CheckBoxEditor), typeof(CheckBoxEditor))]
		public bool AllowNether {
			get{return this.allow_nether;}
			set{allow_nether = value;}
		}
		
		/// <summary>
		/// 玩家获得成就时是否在服务器中进行显示。
		/// </summary>
		/// <returns>
		/// false - 玩家获得成就时的提示仅自己可见，不会向其他玩家进行显示。
		///	true - 玩家获得成就时将在其他在线玩家的聊天栏进行提示。
		///</returns>
		[Category("Information")]
		[DisplayName("announce-player-achievements")]
		[Description("玩家获得成就时是否在服务器中进行显示。")]
		[Editor(typeof(CheckBoxEditor), typeof(CheckBoxEditor))]
		public bool AnnouncePlayerAchievements {
			get{return this.announce_player_achievements;}
			set{announce_player_achievements = value;}
		}
		
		/// <summary>
		/// 定义服务器的游戏难度（例如生物对玩家造成的伤害，饥饿与中毒对玩家的影响方式等）。
		/// </summary>
		/// <returns>
		/// 0 - 和平
		/// 1 - 简单
		/// 2 - 普通
		/// 3 - 困难
		///</returns>
		[EnumGen()]
		[Category("Information")]
		[DisplayName("difficulty")]
		[Description("定义服务器的游戏难度（例如生物对玩家造成的伤害，饥饿与中毒对玩家的影响方式等）。0 - 和平,1 - 简单,2 - 普通,3 - 困难")]
		[Editor(typeof(EnumComboBoxEditor), typeof(EnumComboBoxEditor))]
		public Difficulty Difficulty {
			get{return this.difficulty;}
			set{difficulty = value;}
		}
		
		/// <summary>
		/// 允许使用GameSpy4协议的服务器监听器。用于收集服务器信息。
		/// </summary>
		[Category("Information")]
		[DisplayName("enable-query")]
		[Description("允许使用GameSpy4协议的服务器监听器。用于收集服务器信息。")]
		[Editor(typeof(CheckBoxEditor), typeof(CheckBoxEditor))]
		public bool EnableQuery {
			get{return this.enable_query;}
			set{enable_query = value;}
		}
		
		/// <summary>
		/// 是否允许远程访问服务器控制台。
		/// </summary>
		[Category("Information")]
		[DisplayName("enable-rcon")]
		[Description("是否允许远程访问服务器控制台。")]
		[Editor(typeof(CheckBoxEditor), typeof(CheckBoxEditor))]
		public bool EnableRcon {
			get{return this.enable_rcon;}
			set{enable_rcon = value;}
		}
		
		/// <summary>
		/// 当启用时地图中的命令方块可以被红石所激活
		/// </summary>
		/// <remarks>只有在创造模式的OP才可以正常输入命令方块指令</remarks>
		[Category("Information")]
		[DisplayName("enable-command-block")]
		[Description("当启用时地图中的命令方块可以被红石所激活。只有在创造模式的OP才可以正常输入命令方块指令")]
		[Editor(typeof(CheckBoxEditor), typeof(CheckBoxEditor))]
		public bool EnableCommandBlock {
			get{return this.enable_command_block;}
			set{enable_command_block = value;}
		}
		
		/// <summary>
		/// 定义默认游戏模式
		/// </summary>
		/// <returns>
		/// 0 - 生存模式
		/// 1 - 创造模式
		/// 2 - 冒险模式（仅在12w22a之后，或正式版1.3之后可用）
		/// 3 - 旁观模式（仅在14w05a之后，或正式版1.8之后可用）
		[EnumGen()]
		[Category("Information")]
		[DisplayName("gamemode")]
		[Description("定义默认游戏模式。0 - 生存模式,1 - 创造模式,2 - 冒险模式（仅在12w22a之后，或正式版1.3之后可用）,3 - 旁观模式（仅在14w05a之后，或正式版1.8之后可用）")]
		[Editor(typeof(EnumComboBoxEditor), typeof(EnumComboBoxEditor))]
		public GameMode GameMode {
			get{return this.gamemode;}
			set{gamemode = value;}
		}
		
		/// <summary>
		/// 定义是否在生成世界时生成结构（例如NPC村庄）
		/// </summary>
		/// <returns>
		/// false - 新生成的区块中将不包含结构。
		/// true - 新生成的区块中将包含结构。
		/// 注： 即使设为 false，地牢和下界要塞仍然会生成
		///</returns>
		[Category("Information")]
		[DisplayName("generate-structures")]
		[Description("定义是否在生成世界时生成结构（例如NPC村庄）" +
		             "false - 新生成的区块中将不包含结构。" +
		             "true - 新生成的区块中将包含结构。" +
		             "注： 即使设为 false，地牢和下界要塞仍然会生成")]
		[Editor(typeof(CheckBoxEditor), typeof(CheckBoxEditor))]
		public bool GenerateStructures {
			get{return this.generate_structures;}
			set{generate_structures = value;}
		}
		
		/// <summary>
		/// 本属性质用于自定义超平坦世界的生成。详见超平坦世界了解正确的设定及例子。
		/// </summary>
		[Category("Unnecessary")]
		[DisplayName("generator-settings")]
		[Description("本属性质用于自定义超平坦世界的生成。详见超平坦世界了解正确的设定及例子。")]
		[Editor(typeof(TextBoxEditor), typeof(TextBoxEditor))]
		public string GeneratorSettings{
			get{return this.generator_settings;}
			set{generator_settings=value;}
		}
		
		/// <summary>
		/// 一旦启用，玩家在死后会自动被服务器封禁（即开启极限模式）。
		/// </summary>
		[Category("Information")]
		[DisplayName("hardcore")]
		[Description("一旦启用，玩家在死后会自动被服务器封禁（即开启极限模式）。")]
		[Editor(typeof(CheckBoxEditor), typeof(CheckBoxEditor))]
		public bool HardCore {
			get{return this.hardcore;}
			set{hardcore = value;}
		}
		
		/// <summary>
		/// “level-name”的值将作为世界名称及其文件夹名。
		/// 你也可以把你已生成的世界存档复制过来，然后让这个值与那个文件夹的名字保持一致，服务器就可以载入该存档。
		/// 部分字符，例如'（单引号）可能需要在前面加反斜杠号 \ 才能正确应用。
		/// </summary>
		[Category("Information")]
		[DisplayName("level-name")]
		[Description("“level-name”的值将作为世界名称及其文件夹名。" +
		             "你也可以把你已生成的世界存档复制过来，然后让这个值与那个文件夹的名字保持一致，服务器就可以载入该存档。" +
		             "部分字符，例如'（单引号）可能需要在前面加反斜杠号\\才能正确应用。")]
		[Editor(typeof(TextBoxEditor), typeof(TextBoxEditor))]
		public string LevelName{
			get{return this.level_name;}
			set{level_name=value;}
		}

		/// <summary>
		/// 与单人游戏类似，为你的世界定义一个种子。
		/// </summary>
		[Category("Information")]
		[DisplayName("level-seed")]
		[Description("与单人游戏类似，为你的世界定义一个种子。")]
		[Editor(typeof(TextBoxEditor), typeof(TextBoxEditor))]
		public string LevelSeed{
			get{return this.level_seed;}
			set{level_seed=value;}
		}
		
		/// <summary>
		/// 确定地图所生成的类型
		/// </summary>
		/// <returns>
		/// DEFAULT - 标准的世界带有丘陵，河谷，海洋等
		///	FLAT - 一个没有特色的平坦世界，适合用于建设
		///	LARGEBIOMES - 如同预设世界，但所有生态系都更大（仅快照12w19a，或正式版1.3之后可用）
		///	AMPLIFIED - 如同预设世界，但世界生成高度提高（仅快照13w36a，或正式版1.7.2之后可用）
		///	CUSTOMIZED - 自快照14w21b以来，服务器也支持自定义地形。使用方法是在generator-settings贴上代码。
		///</returns>
		[Category("Information")]
		[DisplayName("level-type")]
		[Description("确定地图所生成的类型。DEFAULT - 标准的世界带有丘陵，河谷，海洋等," +
		             "FLAT - 一个没有特色的平坦世界，适合用于建设，" +
		             "LARGEBIOMES - 如同预设世界，但所有生态系都更大（仅快照12w19a，或正式版1.3之后可用）," +
		             "如同预设世界，但世界生成高度提高（仅快照13w36a，或正式版1.7.2之后可用）," +
		             "CUSTOMIZED - 自快照14w21b以来，服务器也支持自定义地形。使用方法是在generator-settings贴上代码。")]
		[Editor(typeof(CheckBoxEditor), typeof(CheckBoxEditor))]
		public LevelType LevelType {
			get{return this.level_type;}
			set{level_type = value;}
		}
		
		/// <summary>
		/// 玩家在游戏中能够建造的最大高度。然而地形生成算法并不会受这个值的影响。
		/// </summary>
		[Category("Information")]
		[DisplayName("max-build-height")]
		[Description("玩家在游戏中能够建造的最大高度。然而地形生成算法并不会受这个值的影响。")]
		[Editor(typeof(IntegerUpDownEditor), typeof(IntegerUpDownEditor))]
		public int MaxBuildHeight{
			get{return this.max_build_height;}
			set{this.max_build_height=value;}
		}
		
		/// <summary>
		/// 服务器同时能容纳的最大玩家数量。
		/// 但请注意在线玩家越多，对服务器造成的负担也越大，而且服务器OP也不具有在人满的情况下强行进入服务器的权力。
		/// 所以请慎重设置本属性，过大的数值会使客户端显示的玩家列表崩坏。
		/// </summary>
		[Category("Information")]
		[DisplayName("max-players")]
		[Description("服务器同时能容纳的最大玩家数量。但请注意在线玩家越多，对服务器造成的负担也越大，而且服务器OP也不具有在人满的情况下强行进入服务器的权力。" +
		             "所以请慎重设置本属性，过大的数值会使客户端显示的玩家列表崩坏。")]
		[Editor(typeof(IntegerUpDownEditor), typeof(IntegerUpDownEditor))]
		public int MaxPlayers{
			get{return this.max_players;}
			set{this.max_players=value;}
		}
		
		[Category("Information")]
		[DisplayName("max-tick-time")]
		[Description("The maximum number of milliseconds a single tick may take before the server watchdog stops the server with the message," +
		             "A single server tick took 60.00 seconds (should be max 0.05); Considering it to be crashed, server will forcibly shutdown. " +
		             "Once this criteria is met, it calls System.exit(1).")]
		[Editor(typeof(IntegerUpDownEditor), typeof(IntegerUpDownEditor))]
		public int MaxTickTime{
			get{return this.max_tick_time;}
			set{this.max_tick_time=value;}
		}
		
		/// <summary>
		/// 本属性值是设置地图的最大边长
		/// </summary>
		[Category("Information")]
		[DisplayName("max-world-size")]
		[Description("本属性值是设置地图的最大边长。例如：" +
		             "设置 max-world-size 为 1000 ，地图边界将是 2000x2000 尺寸。" +
		             "设置 max-world-size 为 4000 ，地图边界将是 8000x8000 尺寸。")]
		[Editor(typeof(IntegerUpDownEditor), typeof(IntegerUpDownEditor))]
		public int MaxWorldSize{
			get{return this.max_world_size;}
			set{ if (value<=29999984) this.max_world_size=value;}
		}
		
		/// <summary>
		/// 本属性值是玩家客户端的多人游戏服务器列表中显示的服务器讯息，显示于名称下方。
		/// 请注意，motd 不支持彩色样式代码。如果 motd 超过59字符，服务器列表很可能会返回“通讯错误”。
		/// </summary>
		[Category("Information")]
		[DisplayName("motd")]
		[Description("本属性值是玩家客户端的多人游戏服务器列表中显示的服务器讯息，显示于名称下方。" +
		             "请注意，motd 不支持彩色样式代码。如果 motd 超过59字符，服务器列表很可能会返回“通讯错误”。")]
		[Editor(typeof(TextBoxEditor), typeof(TextBoxEditor))]
		public string Motd{
			get{return this.motd;}
			set{motd=value;}
		}
		
		/// <summary>
		/// 是否允许在线验证。
		/// 服务器会与 Minecraft 的账户数据库对比检查连入玩家。
		/// 如果你的服务器并未与Internet连接，则将这个值设为false，然而这样的话破坏者也能够使用任意假账户登录服务器。
		/// 如果 Minecraft.net服务器下线，那么开启在线验证的服务器会因为无法验证玩家身份而拒绝所有玩家加入。
		/// 通常，这个值设为 true 的服务器被称为“正版服务器”，设为 false 的被称为“离线服务器”或“盗版服务器”。
		/// </summary>
		[Category("Information")]
		[DisplayName("online-mode")]
		[Description("是否允许在线验证。" +
		             "服务器会与 Minecraft 的账户数据库对比检查连入玩家。" +
		             "如果你的服务器并未与 Internet 连接，则将这个值设为 false ，然而这样的话破坏者也能够使用任意假账户登录服务器。" +
		             "如果 Minecraft.net 服务器下线，那么开启在线验证的服务器会因为无法验证玩家身份而拒绝所有玩家加入。通常，这个值设为 true 的服务器被称为“正版服务器”，设为 false 的被称为“离线服务器”或“盗版服务器”。")]
		[Editor(typeof(CheckBoxEditor), typeof(CheckBoxEditor))]
		public bool OnlineMode {
			get{return this.online_mode;}
			set{online_mode = value;}
		}
		/// <summary>
		/// 设定OP的权限等级。
		/// 1 - OP可以无视重生点保护。
		/// 2 - OP可以使用 /clear、/difficulty、/effect、/gamemode、/gamerule、/give 以及 /tp 指令，可以编辑指令方块。
		/// 3 - OP可以使用 /ban、/deop、/kick 以及 /op 指令。
		/// 4 - OP可以使用 /stop 指令
		/// </summary>
		[Category("Information")]
		[DisplayName("op-permission-level")]
		[Description("设定OP的权限等级。" +
		             "1 - OP可以无视重生点保护。" +
		             "2 - OP可以使用 /clear、/difficulty、/effect、/gamemode、/gamerule、/give 以及 /tp 指令，可以编辑指令方块。" +
		             "3 - OP可以使用 /ban、/deop、/kick 以及 /op 指令。" +
		             "4 - OP可以使用 /stop 指令")]
		[Editor(typeof(IntegerUpDownEditor),typeof(IntegerUpDownEditor))]
		public int OpPermissionLevel{
			get{return this.op_permission_level;}
			set{if (value<5&&value>-1)op_permission_level=value;}
		}
		
		/// <summary>
		/// 玩家空闲超时的时间，设置为0表示无超时限制。
		/// </summary>
		[Category("Information")]
		[DisplayName("player-idle-timeout")]
		[Description("玩家空闲超时的时间，设置为0表示无超时限制。")]
		[Editor(typeof(IntegerUpDownEditor),typeof(IntegerUpDownEditor))]
		public int PlayerIdleTimeout{
			get{return this.player_idle_timeout;}
			set{player_idle_timeout=value;}
		}
		
		/// <summary>
		/// 客户端加入服务器后是否会自动下载资源包。
		/// 请在这里填入完整的资源包URL。
		/// 注意：这个链接必须直接连到事实的资源包ZIP文件，而且虽然资源包可以是高清的，服务器并不会对玩家服务端进行自动高清修补。
		/// 所以如果你想让大多数玩家都能够使用该资源包的话，请使用标准16x16清晰度。
		/// </summary>
		[Category("Information")]
		[DisplayName("texture-pack")]
		[Description("客户端加入服务器后是否会自动下载资源包。请在这里填入完整的资源包URL。" +
		             "注意：这个链接必须直接连到事实的资源包ZIP文件，而且虽然资源包可以是高清的，服务器并不会对玩家服务端进行自动高清修补。" +
		             "所以如果你想让大多数玩家都能够使用该资源包的话，请使用标准16x16清晰度。")]
		[Editor(typeof(TextBoxEditor), typeof(TextBoxEditor))]
		public string TexturePack{
			get{return this.texture_pack;}
			set{texture_pack=value;}
		}
		
		/// <summary>
		/// 资源包的SHA-1值，必须为小写十六进制，虽然不是必填选项，但可减少每次进入服务器时重复下载资源包的情况。
		/// 注：下载到的服务器资源包将保存在.minecraft\server-resource-packs下。
		/// </summary>
		[Category("Unnecessary")]
		[DisplayName("resource-pack-hash")]
		[Description("资源包的SHA-1值，必须为小写十六进制，虽然不是必填选项，但可减少每次进入服务器时重复下载资源包的情况。" +
		             "注：下载到的服务器资源包将保存在.minecraft\\server-resource-packs下。")]
		[Editor(typeof(TextBoxEditor), typeof(TextBoxEditor))]
		public string ResourcePackHash{
			get{return this.resource_pack_hash;}
			set{resource_pack_hash=value;}
		}
		
		/// <summary>
		/// 是否允许PvP。玩家自己的箭也只有在允许PvP时才可能伤害到自己。
		/// 注：来源于玩家的间接伤害，例如岩浆，火，TNT等，还是会造成伤害。
		/// true - 玩家可以互相残杀。
		/// false - 玩家无法互相造成伤害。
		/// </summary>
		[Category("Information")]
		[DisplayName("pvp")]
		[Description("是否允许PvP。" +
		             "玩家自己的箭也只有在允许PvP时才可能伤害到自己。" +
		             "注：来源于玩家的间接伤害，例如岩浆，火，TNT等，还是会造成伤害。" +
		             "true - 玩家可以互相残杀。" +
		             "false - 玩家无法互相造成伤害。")]
		[Editor(typeof(CheckBoxEditor), typeof(CheckBoxEditor))]
		public bool PvP {
			get{return this.pvp;}
			set{pvp = value;}
		}
		
		/// <summary>
		/// 设置监听服务器的端口号（详见enable-query）。
		/// </summary>
		[Category("Information")]
		[DisplayName("query.port")]
		[Description("设置监听服务器的端口号（详见enable-query）。")]
		[Editor(typeof(IntegerUpDownEditor), typeof(IntegerUpDownEditor))]
		public ushort QueryPort{
			get{return this.query_port;}
			set{query_port = value;}
		}
		
		/// <summary>
		/// 设置远程访问的密码（详见enable-rcon）。
		/// </summary>
		[Category("Unnecessary")]
		[DisplayName("rcon.password")]
		[Description("设置远程访问的密码（详见enable-rcon）。")]
		[Editor(typeof(TextBoxEditor), typeof(TextBoxEditor))]
		public string RconPassword{
			get{return this.rcon_password;}
			set{rcon_password=value;}
		}
		
		/// <summary>
		/// 设置远程访问的端口号（详见enable-rcon）。
		/// </summary>
		[Category("Information")]
		[DisplayName("rcon.port")]
		[Description("设置远程访问的端口号（详见enable-rcon）。")]
		[Editor(typeof(IntegerUpDownEditor), typeof(IntegerUpDownEditor))]
		public ushort RconPort{
			get{return this.rcon_port;}
			set{rcon_port = value;}
		}
		
		/// <summary>
		/// 将服务器与一个特定IP绑定。强烈建议你留空本属性值！
		/// 留空，或是填入你想让服务器绑定的IP。
		/// </summary>
		[Category("Information")]
		[DisplayName("server-ip")]
		[Description("将服务器与一个特定IP绑定。强烈建议你留空本属性值！" +
		             "留空，或是填入你想让服务器绑定的IP。")]
		[Editor(typeof(TextBoxEditor), typeof(TextBoxEditor))]
		public string ServerIp{
			get{return this.server_ip;}
			set{server_ip=value;}
		}
		
		/// <summary>
		/// 改变服务器端口号。如果服务器通过路由器与外界连接的话，该端口必须也能够通过路由器。
		/// </summary>
		[Category("Information")]
		[DisplayName("server-port")]
		[Description("设置远程访问的端口号（详见enable-rcon）。")]
		[Editor(typeof(IntegerUpDownEditor), typeof(IntegerUpDownEditor))]
		public ushort ServerPort{
			get{return this.server_port;}
			set{server_port = value;}
		}
		
		#endregion
		
		#region Serialization
		public string GetObjectData()
		{
			StringBuilder strBuilder=new StringBuilder(2048);
			PropertyInfo[] propertyInfos = typeof(ServerProperties).GetProperties();
			var b =typeof(bool);
			foreach (var property in propertyInfos) {

				var dis =(DisplayNameAttribute)Attribute.GetCustomAttribute(property,typeof(DisplayNameAttribute),false);

				if (property.PropertyType == b) {
					if (Convert.ToBoolean(property.GetValue(this,null)))
						strBuilder.AppendFormat("{0}=true\r\n",
						                        dis.DisplayName);
					
					
					else
						strBuilder.AppendFormat("{0}=false\r\n",
						                        dis.DisplayName);
				}else if (Attribute.GetCustomAttribute(property,typeof(EnumGenAttribute),false)!=null) {
					strBuilder.AppendFormat("{0}={1}\r\n",
					                        dis.DisplayName,
					                        (int)property.GetValue(this,null));
				}else{
					strBuilder.AppendFormat("{0}={1}\r\n",
					                        dis.DisplayName,
					                        property.GetValue(this,null));
				}
			}
			
			return strBuilder.ToString();
		}

		#endregion
				
	}
}

/*
snooper-enabled	布尔值	TRUE	自1.3正式版之后，一旦启用，将允许服务端定期发送统计数据到http://snoop.minecraft.net.
			false - 禁用数据采集
			true - 启用数据采集
spawn-animals	布尔值	TRUE	决定动物是否可以生成。
			true - 动物可以生成。
			false - 动物生成后会立即消失。
spawn-monsters	布尔值	TRUE	决定攻击型生物（怪兽）是否可以生成。
			true - 可以。只要满足条件的话怪物就会生成。
			false - 禁用。不会有任何怪物。
			如果difficulty = 0（和平）的话，本属性值不会有任何影响。
spawn-npcs	布尔值	TRUE	决定是否生成村民。
			true - 生成村民
			false - 不会有村民。
spawn-protection	整数	16	Determines the radius of the spawn protection. Setting this to 0 will not disable spawn protection. 0 will protect the single block at the spawn point. 1 will protect a 3x3 area centered on the spawn point. 2 will protect 5x5, 3 will protect 7x7, etc. This option is not generated on the first server start and appears when the first player joins. If there are no ops set on the server, the spawn protection will be disabled automatically.
use-native-transport	布尔值	TRUE	是否使用针对Linux平台的数据包收发优化，此选项仅会在Linux平台下生成。
			true - 启用
			false - 禁用
view-distance	整数（3-15）	10	设置服务端传送给客户端的数据量。用每一个方向上的区块数量衡量。这个值也是客户端视野距离的上限。当视野为“远”时，实际的值为9，所以默认推荐值为 10 。
white-list	布尔值	FALSE	允许服务器白名单
			当启用时，只有白名单上的用户才能连接服务器。白名单主要用于私人服务器，例如相识的朋友等。
			注 - OP会自动被视为在白名单上。所以无需再将OP加入白名单。
			false - 不使用白名单。
			true - 从 whitelist.json 文件加载白名单。
 */