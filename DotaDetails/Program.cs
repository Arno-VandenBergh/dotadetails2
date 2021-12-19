using DotaDetails.DAL;
using DotaDetails.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotaDetails
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Login am = new Login();
            Application.Run(am);
            am.Dispose();
            if (String.IsNullOrEmpty(Global.Player.Id))
            {
                return;
            }

            Application.Run(new Main());











            //DataBaseRepository db = new DataBaseRepository();
            //PlayerApiRepository api = new PlayerApiRepository();

            //Player player = api.GetPlayerById("73170230");
            //List<string> text = new List<string>();
            //text.Add(player.Id);
            //text.Add(player.Name);


            //File.WriteAllLines("test.txt",text);


            //Hero hero = new Hero("Axe", "Heroes/Axe.png");
            //Item item1 = new Item("Abyssal Blade", "Items/Abyssal_Blade.png");
            //Item item2 = new Item("Arcane Blink", "Items/Arcane_Blink.png");
            //List<Item> items = new List<Item>();
            //items.Add(item1);
            //items.Add(item2);
            //Player player = new Player("Arno Van den Bergh", "73170230", "test123");

            //Build build = new Build(hero, items, player, "Support");

            //db.Build.InsertBuild(build);

        }

       
    }
}
