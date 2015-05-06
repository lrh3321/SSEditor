using System;
using System.Xml;

namespace SSHelper
{
	/// <summary>
	/// Description of Utilty.
	/// </summary>
	public static class Utilty
	{
		const char C_separator=',';
		const string S_separator=",";
		public static string ArrayToString(this int[] arr,string sep=S_separator){
			return string.Join(sep,arr);
		}
		public static int[] StringToArray(this string str,char spe=C_separator){
			int[]val=new int[6];
			int t=0,i=0,j=0,c=str.Length;
			while (j<c) {
				if (str[j]==spe) {
					val[i++]=t;
					t=0;					
				}else{
					t=t*10+str[j]-0x30;
				}
				j++;
			}
			val[i]=t;
			return val;
		}
		static Utilty()
		{
		}
//		public static void Test(){
//			XmlDocument doc=new XmlDocument();
//			var root=doc.CreateElement("Root");
//			var text=doc.CreateTextNode("Hello\r\nWorld!");
//			root.AppendChild(text);
//			root.AppendChild(text);
//			doc.AppendChild(root);
//			doc.Save("D:\\s.txt");
//		}
//		public static void Test2(){
//			XmlDocument doc=new XmlDocument();
//			doc.Load("D:\\s.txt");
//			var root=doc.FirstChild;
//			System.Diagnostics.Debug.WriteLine(root.InnerText);
//		}
		#region "Formula"
		
		
		
		#endregion
	}
}
