using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Fitspiraton.Model;
using Fitspiraton.ViewModel;

namespace Fitspiraton.ViewModel
{
    //Collect here all of the List<T>
    public class Collector: NotifyPropertyClass
    {
        private ObservableCollection<Member> _memberCollection;
        private ObservableCollection<Event> _eventCollection;

        public ObservableCollection<Member> MemberCollection
        {
            get => _memberCollection; 
            set => _memberCollection = value;
        }

        public ObservableCollection<Event> EventCollection
        {
            get => _eventCollection;
            set => _eventCollection = value;
        }

        public Collector()
        {
            MemberCollection = new ObservableCollection<Member>
            {
                new Member("Jon Snow", "Stark1", "youknownothing", "../Assets/UP/jon.jpg", 20),
                new Member("Arya Stark", "Stark2", "needle", "../Assets/UP/arya.jpg", 18)
            };

            EventCollection = new ObservableCollection<Event>
            {
                new Event(new DateTime(2017, 12, 8), "Salsa", "JuanCarlos", 20),
                new Event(new DateTime(2017, 12, 9), "Hip Hop", "DX James", 15),
                new Event(new DateTime(2017, 12, 10), "Aerobics", "Wilson", 20),
                new Event(new DateTime(2017, 12, 11), "Zumba", "Ze Joao", 14)
            };
        }
    }
}
