using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitspiraton.Model
{
    public class Member : User
    {
        private int _bmiResult;

        public Member(string name, string id, string password, string photo , int bmiResult) : base(name, id, password, photo)
        {
            BmiResult = bmiResult;
        }

        public Member(string name, string id, string password, string photo)
        {
            Name = name;
            Id = id;
            Password = password;
            Photo = photo;
        }

        public ObservableCollection<Member> _persons;
        public ObservableCollection<Member> Persons { get { return _persons; } set { _persons = value; OnPropertyChanged(nameof(Persons)); } }

        public Member()
        {
            Persons = new ObservableCollection<Member>()
            {
                new Member("Jon", "stark01", "youknownothing",  "../Assets/UP/jon.jpg"),
                new Member("Arya", "stark02", "needle", "../Assets/UP/arya.jpg"),
                new Member("Patrik<3", "pat", "xxx", "../Assets/UP/sansa.jpg"),
                new Member("Iza", "moon", "ooo", "../Assets/UP/arya.jpg")
            };

        }

        public int BmiResult { get => _bmiResult; set => _bmiResult = value; }
    }
}
