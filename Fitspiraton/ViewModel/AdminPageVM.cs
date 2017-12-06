using System.Collections.ObjectModel;
using Fitspiraton.Model;

namespace Fitspiraton.ViewModel
{
    class AdminPageVM : NotifyPropertyClass
    {
        private CollectionEventSingleton _collectionEventSingleton;
        private Collector CT = new Collector();

        private Member _selectedItem;
        private Event _selectedEvent;
        
        public ObservableCollection<Member> Members { get; set; }
        public ObservableCollection<Event> Events { get; set; }
        public Collector Col;

        public Member AddNewMember { get; set; }
        public Event AddNewEvent { get; set; }

        public RelayCommand AddItemCommand { get; set; }
        public RelayCommand DeleteItemCommand { get; set; }
        public RelayCommand UpdateItemCommand { get; set; }

        public RelayCommand AddEventCommand { get; set; }
        public RelayCommand DeleteEventCommand { get; set; }
        public RelayCommand UpdateEventCommand { get; set; }

        public Event SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                OnPropertyChanged(nameof(SelectedEvent));
            }
        }

    public Member SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public AdminPageVM()
        {

            Col = new Collector();
            Members = Col.MemberCollection; 
            Events = Col.EventCollection;

            DeleteItemCommand = new RelayCommand(DoDeleteItem);
            AddItemCommand = new RelayCommand(DoAddItem);
            UpdateItemCommand = new RelayCommand(DoUpdateItem);

            DeleteEventCommand = new RelayCommand(DoDeleteEvent);
            AddEventCommand = new RelayCommand(DoAddEvent);
            UpdateEventCommand = new RelayCommand(DoUpdateEvent);

            AddNewMember = new Member();
            AddNewEvent = new Event();
            SelectedItem = new Member(); 
            SelectedEvent = new Event();
        }

        // Delete/Add Event

        public void DoDeleteItem()
        {
            Members.Remove(SelectedItem);
        }
        public void DoAddItem()
        {
            Members.Add(AddNewMember);
        }

        public void DoUpdateItem()
        {
            Members = new ObservableCollection<Member>
            {
                new Member(SelectedItem.Id, SelectedItem.Name , SelectedItem.Password, SelectedItem.Photo, SelectedItem.BmiResult)
            };
        }

        public void DoDeleteEvent()
        {
            Events.Remove(SelectedEvent);
        }
        public void DoAddEvent()
        {
            Events.Add(AddNewEvent);
        }

        public void DoUpdateEvent()
        {
            Events = new ObservableCollection<Event>
            {
                new Event(SelectedEvent.Date, SelectedEvent.Type, SelectedEvent.NameOfTeacher, SelectedEvent.MaxNumOfMembers)
            };
        }
    }
}
