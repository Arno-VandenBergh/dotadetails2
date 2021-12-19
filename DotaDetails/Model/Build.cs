using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaDetails.Model
{
    class Build : IEquatable<Build>, IComparable<Build>
    {
        public string Id { get; set; }
        public Hero Hero { get; set; }
        public List<Item> Items { get; set; }
        public Player Player { get; set; }
        public DateTime Date { get; set; }
        public string Position { get; set; } 
        public string Team { get; set; }

        public Build(Hero hero, List<Item> items, Player player,string position, string team = "",DateTime? date = null)
        {
            Hero = hero;
            Items = items;
            Player = player;
            Position = position;
            Team = team;
            Date = date ?? DateTime.Now;
        }

        public int CompareTo(Build other)
        {
            return Player.CompareTo(other.Player);
        }

        public bool Equals(Build other)
        {
            return Hero.Equals(other.Hero) & Player.Equals(other.Player);
        }
    }
}
