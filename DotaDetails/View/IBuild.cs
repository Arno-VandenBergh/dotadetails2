using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaDetails.View
{
    interface IBuild
    {
        string Hero { get; set; }
        string Item { get; set; }
    }
}
