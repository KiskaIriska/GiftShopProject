using GiftShopBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace GiftShopClientView
{
    static class Program
    {
        public static ClientViewModel Client { get; set; }
        static void Main()
        {
            ClientApi.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new FormEnter();
            form.ShowDialog();

            if (Client != null)
            {
                Application.Run(new FormMain());
            }
        }
    }
}
