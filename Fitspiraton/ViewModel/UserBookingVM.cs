using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Fitspiraton.Interfaces;
using Fitspiraton.Model;
using Fitspiraton.Persistancy;
using Fitspiraton.View;

namespace Fitspiraton.ViewModel
{
    class UserBookingVM : NotifyPropertyClass
    {
        private LoginVm log;
        private ObservableCollection<Booking> _bookings;
        private DateTimeOffset _selectedDate;
        private ActivitySingleton _activitySingleton;
        private ObservableCollection<DateTimeOffset> _selectedDates;
        public RelayCommand RegisterCommand { get; set; }
        public readonly FrameNavigateClass Frame;
        private readonly BookingListSingleton _bookingSingleton;
        private CurrentDateSingleton cds;
        private readonly GetItem _getBooking;                                      //serialization
        private SingletonMember _userSingleton;

        public ObservableCollection<DateTimeOffset> SelectedDates
        {
            get => _selectedDates;
            set
            {
                _selectedDates = value;
                OnPropertyChanged((nameof(SelectedDates)));
            }
        }

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
            _userSingleton = SingletonMember.GetInstance();
            log = new LoginVm();
            Frame = new FrameNavigateClass();
            _activitySingleton = ActivitySingleton.GetInstance();
            RegisterCommand = new RelayCommand(RegisterBooking);
            _bookingSingleton = BookingListSingleton.GetInstance();
            SelectedDates = new ObservableCollection<DateTimeOffset>();
            cds = CurrentDateSingleton.GetInstance();
            
            Bookings = _bookingSingleton.GetBookings();

            _getBooking = new GetItem();                          //serialization
        }


        public async void RegisterBooking()
        {
            try
            {
                // SelectedDate returnes to default need to be fixed 
                await _getBooking.LoadFromJson();
                Bookings.Add(new Booking(_userSingleton.GetName(), cds.GetCurrentDate(), _activitySingleton.GetType(), _activitySingleton.GetImageSource(), _activitySingleton.GetNameOfTeacher()));
                _bookingSingleton.SetBooking(Bookings);
                await _getBooking.SaveBookingsToJson(Bookings);
                Frame.ActivateFrameNavigation(typeof(UserMenu), log.CurrentUser);
            }
            catch (Exception e)
            {
                string Exception = e.ToString();
                Frame.ActivateFrameNavigation(typeof(UserMenu), log.CurrentUser);
                MessageDialog msg = new MessageDialog(Exception, "ERROR");
            }
        }
    }
}
