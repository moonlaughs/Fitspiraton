using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using Fitspiraton.Interfaces;
using Fitspiraton.Model;
using Fitspiraton.Persistancy;
using Fitspiraton.ViewModel;

namespace Fitspiraton.ViewModel 
{
    class ManagerEventPageVm : NotifyPropertyClass
    {
        private Collector _collector;
        private ObservableCollection<Event> _events;
        private Event _selectedEvent;
        private EventListSingleton _eventListSingleton;
        private readonly GetItem _getEvents;

        public Event AddNewEvent { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public ObservableCollection<Event> Events { get => _events; set => _events = value; }

        public Event SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                OnPropertyChanged(nameof(SelectedEvent));
            }
        }

        public ManagerEventPageVm()
        {
            _collector = new Collector();
            _eventListSingleton = EventListSingleton.GetInstance();
            _eventListSingleton.SetEvents(_collector.Events);
            Events = _eventListSingleton.GetDates();

            SelectedEvent = new Event();
            AddNewEvent = new Event();

            AddCommand = new RelayCommand(DoAddItem);
            DeleteCommand = new RelayCommand(DoDeleteItem);
            UpdateCommand = new RelayCommand(DoUpdateItem);

            _getEvents = new GetItem();
        }

        public async void DoDeleteItem()
        {
            _collector.Events.Remove(SelectedEvent);
            _eventListSingleton.GetDates().Remove(SelectedEvent);
            await _getEvents.SaveEventsToJson(Events);
        }
        public async void DoAddItem()
        {
            _collector.Events.Add(AddNewEvent);
            await _getEvents.SaveEventsToJson(Events);
        }

        public void DoUpdateItem()
        {
            _collector.Events = new ObservableCollection<Event>
            {
                new Event(  SelectedEvent.Date, SelectedEvent.Type , SelectedEvent.NameOfTeacher, SelectedEvent.MaxNumOfMembers)
            };
        }


    }
}
