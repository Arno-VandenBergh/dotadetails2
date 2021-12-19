using DotaDetails.DAL;
using DotaDetails.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotaDetails.Model
{
    class Player : IEquatable<Player>, IComparable<Player>
    {
        private string _name;
        public string Name {
            get {return _name.ToLower(); }
            set { _name = value; }
        }
        public string Id { get; set; }
        public string Password { get; set; }

        public Player( string id = "", string name = "", string password = "")
        {
            Name = name;
            Id = id;
            Password = password;
        }

        public int CompareTo(Player other)
        {
            return Id.CompareTo(other.Id);
        }

        public bool Equals(Player other)
        {
            return Id.Equals(other.Id);
        }

        public void GetPlayerNameById()
        {
            PlayerApiRepository api = new PlayerApiRepository();
            try
            {
                Name = api.GetPlayerNameById(Id);
            }
            catch (KeyNotFoundException er)
            {
                MessageBox.Show(String.Format("De Id die u heeft ingevoerd is ongeldig.\nKijk na of uw account is vrijgesteld aan OpenDota."), "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Name = "";
                return;
            }
        }

        public List<Game> GetGamesById()
        {
            PlayerApiRepository api = new PlayerApiRepository();
            List<Game> games;
            try
            {
                games = api.GetGamesByPlayerId(Id,Global.Player.Id);
            }
            catch (KeyNotFoundException er)
            {
                MessageBox.Show(String.Format("De Id die u heeft ingevoerd is ongeldig.\nKijk na of uw account is vrijgesteld aan OpenDota."), "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                games = null;
                return games;
            }
            return games;
        }
    }
}
