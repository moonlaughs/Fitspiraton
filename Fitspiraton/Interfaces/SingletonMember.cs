using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitspiraton.Model;
using Fitspiraton.ViewModel;

namespace Fitspiraton.Interfaces
{
    public class SingletonMember
    {
        public static Member _member;

        private static SingletonMember Instance { get; set; }

        private SingletonMember()
        {
            _member = new Member();
        }

        public static SingletonMember GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SingletonMember();
            }
            return Instance;
        }

        public void SetPerson(Member member)
        {
            _member = member;
        }

        public string GetName()
        {
            return _member.Name;
        }

        public string GetID()
        {
            return _member.Id;
        }

        public string GetPhoto()
        {
            return _member.Photo;
        }

        public string GetPassword()
        {
            return _member.Password;
        }
    }
}
