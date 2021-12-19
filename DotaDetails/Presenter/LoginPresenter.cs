using DotaDetails.Model;
using DotaDetails.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaDetails.Controller
{
    class LoginPresenter
    {
        ILogin loginView;

        public LoginPresenter(ILogin login)
        {
            this.loginView = login;
        }

        public void Login()
        {
            Player player = new Player();
            player.Name = loginView.Username;
            player.Password = loginView.Password;

            Global.Player = Global.Db.Player.GetPlayer(player);
            if(Global.Player.Id != "") { 
                loginView.Close();
            }
        }

    }
}
