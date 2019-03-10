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
        public static Form1 frm;
        public static readonly TelegramBotClient thisBot = new TelegramBotClient("775773227:AAGuNFAD-od3jMD09-H_BOYdno5K87Ei7Ww");
        public static Telegram.Bot.Args.MessageEventArgs user;

        [STAThread]
        static void Main(string[] args)
        {
            // receive
            thisBot.OnMessage += ThisBot_OnMessage;
            thisBot.StartReceiving();

            // test
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frm = new Form1();
            Application.Run(frm);
        }

        public static void ThisBot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if(e != null) user = e;
            if(e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                frm.RichTextBoxStream_Update(e);
            }
        }
    }
}
