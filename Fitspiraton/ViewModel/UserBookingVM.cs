using System;
using System.Collections.ObjectModel;
using Fitspiraton.Interfaces;
using Fitspiraton.Model;
using Fitspiraton.View;

namespace Fitspiraton.ViewModel
{
    class UserBookingVM : NotifyPropertyClass 
    {
        private LoginVm log;
        private ObservableCollection<Booking> _bookings;
        private DateTimeOffset _selectedDate;
        private ActivitySingleton _activitySingleton;
        public RelayCommand RegisterCommand { get; set; }
        public readonly FrameNavigateClass Frame;

        public DateTimeOffset SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }

        }
 
        public ObservableCollection<Booking> Bookings { get => _bookings; set => _bookings = value; }

        public UserBookingVM()
        {
            log = new LoginVm();
            Frame = new FrameNavigateClass();
            _activitySingleton = ActivitySingleton.GetInstance();
            RegisterCommand = new RelayCommand(RegisterBooking);
            Bookings = new ObservableCollection<Booking>()
            {
                new Booking("Jobn",DateTimeOffset.Now,"Fitness")
            };
        }
        
        public void RegisterBooking()
        {
            try
            {
                SelectedDate = new DateTimeOffset(DateTime.Now);
                Bookings.Add(new Booking(log.CurrentUser.Id, SelectedDate, _activitySingleton.GetType()));
                Frame.ActivateFrameNavigation(typeof(UserMenu),log.CurrentUser);
                

                //CurrentUser.NAme = Null + SelectedDate binding not wokrking
            }
            catch (Exception e)
            {
                Frame.ActivateFrameNavigation(typeof(UserMenu), log.CurrentUser);
            }
        }
    }
}
