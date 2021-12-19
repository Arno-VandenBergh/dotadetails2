using DotaDetails.DAL;
using DotaDetails.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaDetails
{
    static class Global
    {
        private static Player _player = new Player();
        private static SortedList<string, Build> _builds = new SortedList<string, Build>();
        private static List<Game> _games = new List<Game>();
        private static DataBaseRepository _db = new DataBaseRepository();

        public static Player Player {
            get { return _player; }
            set {_player = value; } 
        }

        public static SortedList<string, Build> Builds
        {
            get { return _builds; }
            set { _builds = value; }
        }



        public static DataBaseRepository Db
        {
            get { return _db; }
            set { _db = value; }
        }

        public static List<Game> Games 
        { 
            get { return _games; }
            set { _games = value; }
        }
    }
}
