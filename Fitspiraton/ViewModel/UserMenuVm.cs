using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitspiraton.Interfaces;

namespace Fitspiraton.ViewModel
{
    class UserMenuVm : NotifyPropertyClass
    {

        private SingletonMember _singleton;

        public string Name { get; set; }

        public string Id { get; set; }

        public string Image { get; set; }
        
        public string Password { get; set; }

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
