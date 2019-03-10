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
        public static TelegramBotClient thisBot = new TelegramBotClient("775773227:AAGuNFAD-od3jMD09-H_BOYdno5K87Ei7Ww");
        [STAThread]
        static void Main()
        {
            // test
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
