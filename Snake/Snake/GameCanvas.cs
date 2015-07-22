using System;

using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake
{
	/// <summary>
	/// A Canvas
	/// </summary>
	public class GameCanvas:Panel
	{
		public GameCanvas()
		{
		}
		internal Point bounus;
		
		internal List<Point> m_snake;
		
		
		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
			
//			drawingContext.DrawRectangle(Brushes.Transparent,null, new Rect(0, 0, 400, 400));
			
			drawingContext.DrawRectangle(Brushes.White, new Pen(Brushes.Green, 3.0),
			                             new Rect(20 * bounus.X+3, 20 * bounus.Y+3, 14, 14));
			
			
			foreach (var element in m_snake) {
				drawingContext.DrawRectangle(Brushes.White, new Pen(Brushes.Black, 1.0),
				                             new Rect(20 * element.X, 20 * element.Y, 20, 20));
				drawingContext.DrawRectangle(Brushes.Black, new Pen(Brushes.Black, 1.0),
				                             new Rect(20 * element.X+5, 20 * element.Y+5, 10, 10));
			}
		}
		
		
	}
}
