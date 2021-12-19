using DotaDetails.Model;
using DotaDetails.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotaDetails.Presenter
{
    class PlayerPresenter
    {
        IPlayerId playerIdView;

        public PlayerPresenter(IPlayerId playerId)
        {
            playerIdView = playerId;
        }

        internal void FindGames()
        {
            Player player = new Player();
            if (playerIdView.AccountID == "")
            {
                MessageBox.Show(String.Format("U hebt geen id meegegeven."), "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            player.Id = playerIdView.AccountID;
            Global.Games = player.GetGamesById();

        }
    }
}
