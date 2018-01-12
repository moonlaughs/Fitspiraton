using System.Collections.ObjectModel;
using Fitspiraton.Model;
using Fitspiraton.ViewModel;

namespace Fitspiraton.Interfaces
{
    class BookingHandler
    {
        private Collector col;
        private ObservableCollection<Event> _fitness;
        private ObservableCollection<Event> _yoga;
        private ObservableCollection<Event> _salsa;
        private ObservableCollection<Event> _poledance;
        private ObservableCollection<Event> _ballet;
        private ObservableCollection<Event> _zumba;
        private ObservableCollection<Event> _karate;
        private EventListSingleton _eventListSingleton;

        public BookingHandler()
        {
            col = new Collector();
            _fitness = new ObservableCollection<Event>();
            _yoga = new ObservableCollection<Event>();
            _salsa = new ObservableCollection<Event>();
            _karate = new ObservableCollection<Event>();
            _zumba = new ObservableCollection<Event>();
            _ballet = new ObservableCollection<Event>();
            _poledance = new ObservableCollection<Event>();
            _eventListSingleton = EventListSingleton.GetInstance();
            _eventListSingleton.SetEvents(col.Events);

            foreach (var Event in _eventListSingleton.GetDates())
            {
                if (Event.Type == "Fitness")
                {
                    Fitness.Add(Event);
                }
                if (Event.Type == "Yoga")
                {
                    Yoga.Add(Event);
                }
                if (Event.Type == "Salsa")
                {
                    Salsa.Add(Event);
                }
                if (Event.Type == "Pole dance")
                {
                    Poledance.Add(Event);
                }
                if (Event.Type == "Ballet")
                {
                    Ballet.Add(Event);
                }
                if (Event.Type == "Zumba")
                {
                    Zumba.Add(Event);
                }
                if (Event.Type == "Karate")
                {
                    Karate.Add(Event);
                }

            }
        }

        public ObservableCollection<Event> Fitness { get => _fitness; set => _fitness = value; }
        public ObservableCollection<Event> Yoga { get => _yoga; set => _yoga = value; }
        public ObservableCollection<Event> Salsa { get => _salsa; set => _salsa = value; }
        public ObservableCollection<Event> Poledance { get => _poledance; set => _poledance = value; }
        public ObservableCollection<Event> Ballet { get => _ballet; set => _ballet = value; }
        public ObservableCollection<Event> Zumba { get => _zumba; set => _zumba = value; }
        public ObservableCollection<Event> Karate { get => _karate; set => _karate = value; }
    }
}
