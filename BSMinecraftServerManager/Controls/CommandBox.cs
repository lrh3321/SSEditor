using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Input;

namespace BSMinecraftServerManager.Controls
{
	[TemplatePart(Name = "PART_ComboBox", Type = typeof(ComboBox))]
	[TemplatePart(Name = "PART_SubComboBox", Type = typeof(ComboBox))]
	[TemplatePart(Name = "PART_TextBox", Type = typeof(TextBox))]
	[TemplatePart(Name = "PART_Button", Type = typeof(Button))]
	public class CommandBox : ItemsControl
	{
		ComboBox m_ComboBox,m_SubComboBox;
		TextBox m_TextBox;
		Button m_Button;

		static CommandBox(){

			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CommandBox), new FrameworkPropertyMetadata(typeof(CommandBox)));
		}

		public event EventHandler<CommandTriggedEventArgs> SendCommand;
		
		protected virtual void OnSendCommand(){
			StringBuilder builder =new StringBuilder();
			builder.Append(m_ComboBox.SelectedValue);
			if (builder.Length > 0){
				builder.Append(' ');
				builder.Append(m_SubComboBox.SelectedValue);
			}
			builder.Append(m_TextBox.Text.Trim());
			string temp =builder.ToString();
			if (temp.Length>0) {
				if (SendCommand!=null) {
					this.SendCommand.Invoke(this,new CommandTriggedEventArgs(temp));
				}
			}
		}
		
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			this.m_ComboBox = (ComboBox)base.GetTemplateChild("PART_ComboBox");
			this.m_SubComboBox = (ComboBox)base.GetTemplateChild("PART_SubComboBox");

			this.m_TextBox = (TextBox)base.GetTemplateChild("PART_TextBox");

			if (m_TextBox!=null) {
				this.m_TextBox.KeyDown+= new KeyEventHandler(CommandBox_KeyDown);
			}
			
			this.m_Button = (Button)base.GetTemplateChild("PART_Button");
			if (m_Button!=null) {
				this.m_Button.Click+= new RoutedEventHandler(CommandBox_Click);
			}
		}

		void CommandBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter) {
				this.OnSendCommand();
			}
		}

		void CommandBox_Click(object sender, RoutedEventArgs e)
		{
			this.OnSendCommand();
		}
	}

}