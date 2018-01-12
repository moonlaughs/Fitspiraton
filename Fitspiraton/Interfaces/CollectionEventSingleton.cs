using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitspiraton.Model;

namespace Fitspiraton.ViewModel
{
    class CollectionEventSingleton:NotifyPropertyClass
    {
        private ObservableCollection<Event> _events;

        public static CollectionEventSingleton Instance
        {
            get; set;
        }


        private CollectionEventSingleton()
        {
            _events = new ObservableCollection<Event>();
        }

        public static CollectionEventSingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new CollectionEventSingleton();
              
            }
            return Instance;

        }

        public void SetEvent(ObservableCollection<Event> events)
        {
            _events = events;
        }

        public ObservableCollection<Event> GetEvents()
        {
            return _events;
        }

        public void AddEventDate(Event addedEventDate)
        {
            this._events.Add(addedEventDate);
        }

    }
}
