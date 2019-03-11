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
    public partial class FormMain : Form
    {

        public FormMain()
        {
            RichTextBox.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            // wait for sql server to be loaded

            // get users data from sql server (intialization after system restart)

            //while (program.user == null) ; // XD
            //for(int i=0; i<usersIndex; i++) // i < number of users on sql server + change user to user-id from server
            //{
            //    comboboxstream.items.add(program.user.message.contact.firstname + program.user.message.contact.lastname + " : " + program.user.message.contact.phonenumber + " : " + program.user.message.contact.userid);
            //    comboboxstream.items[i] = program.user.message.chat.id;
            //}
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            // gui changes -reponsive design
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
                if (comboBoxStream.SelectedText != "all-user")
                {
                    await Program.thisBot.SendTextMessageAsync((long)comboBoxStream.SelectedValue, richTextBoxReply.Text);
                }
                else // send-to-all = newspaper
                {
                    // use for-loop to send to each user
                }
            }
        }

        private void timerSync_Tick(object sender, EventArgs e)
        {
            // sync comboBox with users list on sql server -users data
        }
    }
}
