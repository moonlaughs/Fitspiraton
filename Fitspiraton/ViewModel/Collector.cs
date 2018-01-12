using System;
using System.Collections.ObjectModel;
using Fitspiraton.Interfaces;
using Fitspiraton.Model;

namespace Fitspiraton.ViewModel
{
    //Collect here all of the List<T>
    public class Collector
    {
        private ObservableCollection<Event> _events;

        internal ObservableCollection<Event> Events { get => _events; set => _events = value; }

        public Collector()
        {
            Events = new ObservableCollection<Event>()
            {
                new Event(new DateTime(2017,12,20),"Fitness","John", 20),
                new Event(new DateTime(2017,12,21),"Fitness","John", 20),
                new Event(new DateTime(2017,12,22),"Fitness","John", 20),
                new Event(new DateTime(2017,12,23),"Fitness","John", 20),
                new Event(new DateTime(2017,12,24),"Yoga","John", 20),
                new Event(new DateTime(2017,12,25),"Yoga","John", 20),
                new Event(new DateTime(2017,12,26),"Salsa","John", 20),
                new Event(new DateTime(2017,12,27),"Salsa","John", 20),
                new Event(new DateTime(2017,12,12),"Karate","John", 20),
                new Event(new DateTime(2017,12,14),"Ballet","John", 20),
                new Event(new DateTime(2017,12,25),"Karate","John", 20),
                new Event(new DateTime(2017,12,23),"Zumba","John", 20),
                new Event(new DateTime(2017,12,18),"Zumba","John", 20),
                new Event(new DateTime(2017,12,19),"Karate","John", 20),
                new Event(new DateTime(2017,12,7),"Karate","John", 20),
                new Event(new DateTime(2017,12,9),"Pole dance","John", 20),
            };
        }
    }
}
