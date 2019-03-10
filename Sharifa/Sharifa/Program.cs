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
        public static FormMain frm;
        public static readonly TelegramBotClient thisBot = new TelegramBotClient("775773227:AAGuNFAD-od3jMD09-H_BOYdno5K87Ei7Ww");
        public static Telegram.Bot.Args.MessageEventArgs user;

        [STAThread]
        static void Main(string[] args)
        {
            // test
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frm = new FormMain();
            Application.Run(frm);

            // receive
            thisBot.OnMessage += ThisBot_OnMessage;
            thisBot.StartReceiving();
        }

        public static void ThisBot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e != null && e!=user)
            {
                //add user to sql server -users database
                AddUser(e);
                user = e;
            }

            if(e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                ReplyCommands(e.Message.Text);
            }
        }

        public static void AddUser(Telegram.Bot.Args.MessageEventArgs newUser)
        {
            // add this new users data to server ... if there was same datas return err to this function
            // err will display msg "user aleady exists"
        }

        public async static void ReplyCommands(string msg)
        {
            // remove this +instead load reply list from sql server ->reply table

            switch (msg)
            {
                case "/start":
                    await Program.thisBot.SendTextMessageAsync(user.Message.Chat.Id, "به کانال تلگرام شریف خوش اومدی!");
                    break;
                default:
                    await Program.thisBot.SendTextMessageAsync(user.Message.Chat.Id, "متوجه نشدم!");
                    break;

            }
        }
    }
}
