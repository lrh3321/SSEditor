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
	/// Interaction logic for SnakeWin.xaml
	/// </summary>
	public partial class SnakeWin : Window
	{
		DispatcherTimer timer;
//		VisualBrush bgBrush;
//		DrawingVisual drawingVisual;
		bool[,] chumks;
		List<Point> m_snake;
		Point bounus;
		Direction dest,last_dest;
		
		long m_spanTick;
		long m_lastTick;
		
		
		public SnakeWin()
		{
			InitializeComponent();
			
			timer=new DispatcherTimer(DispatcherPriority.Normal );
			timer.Interval=new TimeSpan(0,0,0,0,(int)50/3);
			
//			drawingVisual=new DrawingVisual();
//			
//			bgBrush=new VisualBrush( );
//			bgBrush.Visual=drawingVisual;
//			canvas.Background=bgBrush;
			chumks=new bool[20,20];
			m_snake=new List<Point>();
			m_snake.AddRange(new Point[]{new Point(2,0),new Point(1,0),new Point(1,0)});
			CreateBounus();
			dest=last_dest= Direction.Right;
			
			//var span=new TimeSpan(0,0,0,0,500);
			m_spanTick=5000000;// span.Ticks;
			
			this.Loaded+= form_Loaded;

			IntCombo();
			
			gcanvas.m_snake=this.m_snake;
		}

		void IntCombo()
		{
			cboTimespan.Focusable=false;
			var arr=FindResource("cboArr") as string[];
			int i=0;
			cboTimespan.Items.Add(
				new ComboBoxItem(){DataContext=1000000L
						,Content=arr[i++]}
			);
			cboTimespan.Items.Add(
				new ComboBoxItem(){DataContext=2000000L
						,Content=arr[i++]}
			);
			cboTimespan.Items.Add(
				new ComboBoxItem(){DataContext=5000000L
						,Content=arr[i++]}
			);
			cboTimespan.Items.Add(
				new ComboBoxItem(){DataContext=10000000L
						,Content=arr[i++]}
			);
			cboTimespan.Items.Add(
				new ComboBoxItem(){DataContext=12000000L
						,Content=arr[i++]}
			);
			cboTimespan.SelectedIndex = 2;
			cboTimespan.SelectionChanged += ComboBox_SelectionChanged;
		}
		
		void CreateBounus(){
			Point p;
			do{				
				int x=rand.Next(20);
				int y=rand.Next(20);
				p=new Point(x,y);
			}
			while (m_snake.Contains(p)|(bounus==p)) ;
			gcanvas.bounus=bounus=p;
			
		}
		
		void form_Loaded(object sender,RoutedEventArgs e){
			timer.Tick+= timer_Tick;
			timer.Start();
		}
		void timer_Tick(object sender, EventArgs e) {
			UpdateInput();			

			Update();

			Render();
			
		}

		
		void Render()
		{

//			var context = drawingVisual.RenderOpen();
//			
//			context.DrawRectangle(Brushes.Transparent,null, new Rect(0, 0, 400, 400));
//			
//			context.DrawRectangle(Brushes.White, new Pen(Brushes.Green, 3.0),
//			                      new Rect(20 * bounus.X+3, 20 * bounus.Y+3, 14, 14));
//			
//		
//			foreach (var element in m_snake) {
//				context.DrawRectangle(Brushes.White, new Pen(Brushes.Black, 1.0),
//				                      new Rect(20 * element.X, 20 * element.Y, 20, 20));
//				context.DrawRectangle(Brushes.Black, new Pen(Brushes.Black, 1.0),
//				                      new Rect(20 * element.X+5, 20 * element.Y+5, 10, 10));
//			}
//			
//			context.Close();
			gcanvas.InvalidateVisual();
			
		}

		void Update()			
		{
//			m_spanTick=100000;
			if ((DateTime.Now.Ticks - m_lastTick) > m_spanTick)
			{
				m_lastTick = DateTime.Now.Ticks;
				var s = m_snake[0];
				switch (dest) {
					case Direction.Up:
						s = s + new Vector(0, -1);
						break;
					case Direction.Right:
						s = s + new Vector(1, 0);

						break;
					case Direction.Down:
						s = s + new Vector(0, 1);

						break;
					case Direction.Left:

						s = s + new Vector(-1, 0);
						break;
				}

				last_dest = dest;
				if (bounds.Contains(s)) {
					if (m_snake.Contains(s)) {
						return ;
					}
					if (!HitTest(s)) {
						m_snake.RemoveAt(m_snake.Count - 1);
						
						
					}
					m_snake.Insert(0, s);
				}

			}
//			else{
//
//			System.Diagnostics.Debug.WriteLine(DateTime.Now.Ticks);
//			}
		}
		
		bool HitTest(Point p){
			if (bounus==p) {
				CreateBounus();
				return true;
			}
			return false;
		}
		Random rand=new Random();
//		static readonly Key[] s_controlKeys=new Key[]{Key.W,Key.D,Key.S,Key.A};
		static readonly Key[][] s_controlKeyPairs=new Key[][]{
			new Key[]{Key.W,Key.Up},
			new Key[]{Key.D,Key.Right},
			new Key[]{Key.S,Key.Down},
			new Key[]{Key.A,Key.Left}};
		static readonly Direction[] s_controlDirections=
			new Direction[]{Direction.Up,Direction.Right,Direction.Down,Direction.Left};
		
		static readonly Rect bounds=new Rect(0,0,19.9d,19.9d);
		
		void UpdateInput(){
			for (int i = 0; i < 4; i++) {
				CheckDirection(s_controlKeyPairs[i],s_controlDirections[i]);
			}
			
		}
		void CheckDirection(Key[] keys,Direction direct){
			if (last_dest==direct) {
				return ;
			}
			if (((int)(last_dest|direct)%5==0)) {
				return ;
			}
			foreach (var key in keys) {
				if (Keyboard.IsKeyDown(key)) {
					dest= direct;
					break;
				}
			}
			
//			var state= Keyboard.GetKeyStates(key);
//			if (state== KeyStates.Down) {
//				dest= direct;
//			}
		}
		
		void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			m_spanTick=((long)((e.AddedItems[0] as ComboBoxItem).DataContext) );
		}
		
		void Button_Click(object sender, RoutedEventArgs e)
		{
			timer.Stop();
			
			m_snake.Clear();
			m_snake.AddRange(new Point[]{new Point(2,0),new Point(1,0),new Point(1,0)});
			CreateBounus();
			dest=last_dest= Direction.Right;
			timer.Start();
			
		}
	}
}