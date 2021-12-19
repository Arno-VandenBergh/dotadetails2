using DotaDetails.Model;
using DotaDetails.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotaDetails.Presenter
{
    class RegisterPresenter
    {
        IRegister registerView;

        public RegisterPresenter(IRegister register)
        {
            this.registerView = register;
        }

        public void Register()
        {
            Player player = new Player();
            if (registerView.AccountID == "")
            {
                MessageBox.Show(String.Format("U hebt geen id meegegeven."), "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            player.Id = registerView.AccountID;
            player.GetPlayerNameById();
            if(registerView.Password == "")
            {
                MessageBox.Show(String.Format("U hebt geen wachtwoord meegegeven."), "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            player.Password = registerView.Password;
            
            if (player.Name != "") { 
                //nog in model plaatsen
                Global.Db.Player.InsertPlayer(player);
                registerView.Close();
            }
        }
    }
}
