using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitspiraton.Interfaces;

namespace Fitspiraton.ViewModel
{
    public class UserMenuVm : NotifyPropertyClass
    {
        //instane field
        private SingletonMember _singleton;

        //autoproperties
        public string Name { get; set; }
        public string Id { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }

        //constructor
        public UserMenuVm()
        {
            _singleton = SingletonMember.GetInstance();
            Name = _singleton.GetName();
            Id = _singleton.GetID();
            Image = _singleton.GetPhoto();
            Password = _singleton.GetPassword();
        }
    }
}
