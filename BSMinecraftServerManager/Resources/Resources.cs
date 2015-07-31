using System;
using System.IO;

namespace BSMinecraftServerManager
{
	static class Resources
	{
		static readonly string Prefix = typeof(Resources).FullName + ".";
		
		public static Stream OpenStream(string name)
		{
			Stream s = typeof(Resources).Assembly.GetManifestResourceStream(Prefix + name);
			if (s == null)
				throw new FileNotFoundException("The resource file '" + name + "' was not found.");
			return s;
		}
		
	}
}
