using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaDetails.View
{
    interface ILogin
    {
        string Username { get; set; }
        string Password { get; set; }
        string AccountID { get; set; }

        void Close();
    }
}
