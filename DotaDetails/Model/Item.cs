using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaDetails.Model
{
    class Item : IEquatable<Item>, IComparable<Item>
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public Item(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public Item(long id, string name, string url)
        {
            Id = id;
            Name = name;
            Url = url;
        }

        public bool Equals(Item other)
        {
            return Name.Equals(other.Name);
        }

        public int CompareTo(Item other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
