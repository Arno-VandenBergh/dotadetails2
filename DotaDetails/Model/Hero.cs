using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaDetails.Model
{
    class Hero : IEquatable<Hero>, IComparable<Hero>
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public Hero(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public Hero(Int64 id, string name, string url)
        {
            Id = id;
            Name = name;
            Url = url;
        }

        public bool Equals(Hero other)
        {
            return Name.Equals(other.Name);
        }

        public int CompareTo(Hero other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
