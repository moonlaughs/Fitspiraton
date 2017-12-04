using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitspiraton.Model
{
    class Admin : User
    {
        public Admin(string name, string id, string password, string photo) : base(name, id, password, photo)
        {

        }
    }
}
