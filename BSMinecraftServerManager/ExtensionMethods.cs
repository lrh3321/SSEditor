/*
 * 由SharpDevelop创建。
 * 用户： LRH3321
 * 日期: 2015-7-31
 * 时间: 8:45
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using System.Configuration;
using System.Xml.Linq;

namespace BSMinecraftServerManager
{
    /// <summary>
    /// Description of ExtensionMethods.
    /// </summary>
    internal static class ExtensionMethods
    {
        static ExtensionMethods()
        {
            LoadConfiguration();
        }
        const string JRE = @"SOFTWARE\JavaSoft\Java Runtime Environment";
        const string JRE64 = @"SOFTWARE\Wow6432Node\JavaSoft\Java Runtime Environment";
        const string CONFIG = "bs.config";

        public const string MaxMemoryKey = "MaxMemory";
        public const string MinMemoryKey = "MinMemory";
        public const string JrePathKey = "JrePath";
        public const string JarPathKey = "JarPath";
        public const string NoGUIKey = "NoGUI";

        public static string GetJavaHome()
        {
            string ret = string.Empty;
            try
            {
                var reg = Registry.LocalMachine.OpenSubKey(JRE, false);
                string key = reg.GetValue("CurrentVersion", string.Empty) as string;
                ret = reg.OpenSubKey(key, false).GetValue("JavaHome", string.Empty) as string;
                reg.Dispose();
            }
            catch (Exception)
            {

                return string.Empty;
            }
            return ret;
        }

        static string GetJavaHome64()
        {
            var jre = Registry.LocalMachine.OpenSubKey(JRE64, false);
            string CurrentVersion = jre.GetValue("CurrentVersion", string.Empty) as string;
            string path = jre.OpenSubKey(CurrentVersion, false).GetValue("JavaHome", string.Empty) as string;

            jre.Dispose();
            return path;
        }

        static Setting setting;

        static void LoadConfiguration()
        {
            if (File.Exists(CONFIG))
            {
                setting = new Setting(XElement.Load(CONFIG));
            }
            else
            {
                setting = new Setting();
                setting[MaxMemoryKey] = "1024";
                setting[MinMemoryKey] = "512";
                setting[JrePathKey] = Path.Combine(GetJavaHome(),"bin","java.exe");
                string jar = string.Empty;
                string[] arr = Directory.GetFiles(Environment.CurrentDirectory, "forge*.jar");
                if (arr.Length > 0)
                    jar = arr[0];
                else
                {
                    arr = Directory.GetFiles(Environment.CurrentDirectory, "*server*.jar");
                    if (arr.Length > 0)
                        jar = arr[0];
                    else
                    {
                        arr = Directory.GetFiles(Environment.CurrentDirectory, "*.jar");
                        if (arr.Length > 0)
                            jar = arr[0];
                    }
                }
                setting[JarPathKey] = jar;
                setting[NoGUIKey] = "true";

            }
        }

        public static void SaveConfiguration()
        {
            setting.Save(CONFIG);
        }

        public static Setting Settings
        {
            get
            {
                return setting;
            }
        }
    }

    internal class Setting
    {
        XElement Root;

        public Setting() : this(new XElement("configuration"))
        {
        }

        public Setting(XElement root)
        {
            this.Root = root;
        }

        public void Save(string filename)
        {
            this.Root.Save(filename);
        }

        public string this[string key]
        {
            get
            {
                var element = Root.Element(key);
                if (element != null)
                {
                    return element.Value;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                var element = Root.Element(key);
                if (element != null)
                {
                    element.Value = value;
                }
                else
                {
                    Root.Add(new XElement(key, value));
                }
            }
        }
                
    }
}
