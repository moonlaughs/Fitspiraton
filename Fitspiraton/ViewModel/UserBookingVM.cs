using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
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
        private readonly BookingListSingleton _bookingSingleton;

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
            _bookingSingleton = BookingListSingleton.GetInstance();

            Bookings = new ObservableCollection<Booking>(){};
            Bookings = _bookingSingleton.GetBookings();

        }
        
        public void RegisterBooking()
        {
            try
            {
                // SelectedDate returnes to default need to be fixed 
                Bookings.Add(new Booking(log.CurrentUser.Id, SelectedDate, _activitySingleton.GetType()));
               
                _bookingSingleton.SetBooking(Bookings);
                Frame.ActivateFrameNavigation(typeof(UserMenu),log.CurrentUser);
            }
            catch (Exception e)
            {
                string Exception = e.ToString();
                Frame.ActivateFrameNavigation(typeof(UserMenu), log.CurrentUser);
                MessageDialog msg = new MessageDialog(Exception,"ERROR");
            }
        }
    }
}
