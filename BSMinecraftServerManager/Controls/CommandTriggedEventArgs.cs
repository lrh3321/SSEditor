using System;
using System.Linq;

namespace BSMinecraftServerManager.Controls
{
	public class CommandTriggedEventArgs : EventArgs
	{
		public string Command { get; set; }
		
		public CommandTriggedEventArgs()
		{
			
		}
		public CommandTriggedEventArgs(string command)
		{
			this.Command = command;
		}
	}
}
