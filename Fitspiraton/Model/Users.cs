using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitspiraton.Model
{
    public class Users
    {
        public string name { get; set; }
        public string id { get; set; }
        public string password { get; set; }
        public string photo { get; set; }

        public Users(string Name, string Id, string Password, string Photo)
        {
            name = Name;
            id = Id;
            password = Password;
            photo = Photo;
        }


        public Users()
        {

        }
        public override string ToString()
        {
            return $"{name}{id}{password}{photo}";
        }
    }
}
