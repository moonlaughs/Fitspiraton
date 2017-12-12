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
        private ObservableCollection<Event> _dance;
        private ObservableCollection<Event> _unhandeled;

        public BookingHandler()
        {
            col = new Collector();
            _fitness = new ObservableCollection<Event>();
            _dance = new ObservableCollection<Event>();
            _yoga = new ObservableCollection<Event>();
            _unhandeled = new ObservableCollection<Event>();

            foreach (var Event in col.Events)
            {
                if (Event.Type == "Fitness")
                {
                    Fitness.Add(Event);
                }
                if (Event.Type == "Yoga")
                {
                    Yoga.Add(Event);
                }
                if (Event.Type == "Dance")
                {
                    Dance.Add(Event);
                }
                if (Event.Type != "Fitness" && Event.Type != "Fitness" && Event.Type != "Dance")
                {
                    Unhandeled.Add(Event);
                }
            }
        }

        public ObservableCollection<Event> Fitness { get => _fitness; set => _fitness = value; }
        public ObservableCollection<Event> Yoga { get => _yoga; set => _yoga = value; }
        public ObservableCollection<Event> Dance { get => _dance; set => _dance = value; }
        public ObservableCollection<Event> Unhandeled { get => _unhandeled; set => _unhandeled = value; }
    }
}
