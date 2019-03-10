using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;

namespace Sharifa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            for(int i=0; i<numberofclients; i++)
            {
                comboBoxStream.Items.Add(Program.user.Message.Contact.FirstName + Program.user.Message.Contact.LastName + " : " + Program.user.Message.Contact.PhoneNumber + " : " + Program.user.Message.Contact.UserId);
                comboBoxStream.Items[i] = Program.user.Message.Contact.UserId;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            
        }

        public void RichTextBoxStream_Update(Telegram.Bot.Args.MessageEventArgs e)
        {

            if(comboBoxStream.SelectedIndex == 0)
            {
                richTextBoxStream.Text += e.Message.Text + Environment.NewLine;
            }
        }

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            if (comboBoxStream.TabIndex != 0 && comboBoxStream.SelectedItem != null)
            {
                await Program.thisBot.SendTextMessageAsync((long)comboBoxStream.SelectedValue, richTextBoxReply.Text);
            }
        }

        private void timerSync_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
