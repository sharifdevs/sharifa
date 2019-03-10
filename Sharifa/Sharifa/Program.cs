using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;

namespace Sharifa
{
    
    static class Program
    {
        public static readonly TelegramBotClient thisBot = new TelegramBotClient("775773227:AAGuNFAD-od3jMD09-H_BOYdno5K87Ei7Ww");
        public static Form1 frm;
        [STAThread]
        static void Main()
        {
            // test
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frm = new Form1();
            Application.Run(frm);

            // receive
            thisBot.OnMessage += ThisBot_OnMessage;
            thisBot.StartReceiving();
        }

        private static void ThisBot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if(e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                frm.TextBoxStream_Update(e.Message.Text);
            }
        }
    }
}
