using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaDetails.Model
{
    class Game
    {
        public DateTime Date { get; set; }
        public SortedSet<Build> RadiantTeam { get; set; }
        public SortedSet<Build> DireTeam { get; set; }

        public Game()
        {
            Date = DateTime.Now;
            RadiantTeam = new SortedSet<Build>();
            DireTeam = new SortedSet<Build>();
        }
    }
}
