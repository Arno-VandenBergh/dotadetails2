using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaDetails.View
{
    interface IRegister
    {
        string AccountID { get; set; }
        string Password { get; set; }

        void Close();
    }
}
