using System.Collections.ObjectModel;
using Fitspiraton.Model;

namespace Fitspiraton.Interfaces
{
    class EventListSingleton
    {
        private ObservableCollection<Event> _events;
        public static EventListSingleton Instance { get; set; }

        private EventListSingleton()
        {
            _events = new ObservableCollection<Event>();
        }

        public static EventListSingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new EventListSingleton();
            }
            return Instance;
        }

        public void SetEvents(ObservableCollection<Event> events)
        {
            _events = events;
        }

        public ObservableCollection<Event> GetDates()
        {
            return _events;
        }
    }
}
