using System;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Fitspiraton.Interfaces;
using Fitspiraton.Model;
using Fitspiraton.Persistancy;

namespace Fitspiraton.ViewModel
{
    class RecentBookingsVM : NotifyPropertyClass
    {
        private BookingListSingleton _bookingListSingleton;
        private Booking _selectedBooking;
        private LoginVm lvm;
        private ObservableCollection<Booking> CurrentBookingList;
        private Booking doubleDeleteBooking;
        private ObservableCollection<Booking> _allBookings;
        private SingletonMember _userSingleton;

        private readonly GetItem _getBooking;                             //serialization

        public ObservableCollection<Booking> Bookings { get; set; }

        public RelayCommand DeleteBookingCommand { get; set; }


        public Booking SelectedBooking
        {
            get => _selectedBooking;
            set
            {
                _selectedBooking = value;
                OnPropertyChanged(nameof(SelectedBooking));
            }
        }

        public ObservableCollection<Booking> AllBookings { get => _allBookings; set => _allBookings = value; }

        public RecentBookingsVM()
        {
            _userSingleton = SingletonMember.GetInstance();
            lvm = new LoginVm();
            CurrentBookingList = new ObservableCollection<Booking>();
            _bookingListSingleton = BookingListSingleton.GetInstance();
            DisplayCurrentUsersBookings();
            Bookings = CurrentBookingList;
            ExistingBookingCheck();
            AllBookings = _bookingListSingleton.GetBookings();
            SelectedBooking = new Booking();
            DeleteBookingCommand = new RelayCommand(DoDeleteBooking);

            _getBooking = new GetItem();                                     //serialization
            Load();
        }

        public async void DoDeleteBooking()
        {
            ;
            doubleDeleteBooking = SelectedBooking;
            CurrentBookingList.Remove(doubleDeleteBooking);
            _bookingListSingleton.GetBookings().Remove(doubleDeleteBooking);
            await _getBooking.SaveBookingsToJson(_bookingListSingleton.GetBookings());

        }

        private async void ExistingBookingCheck()
        {
            if (Bookings.Count == 0 && _bookingListSingleton.GetBookings().Count == 0)
            {
                MessageDialog msg = new MessageDialog("Your booking list is empty. Book your first event in the booking menu", "NO BOOKINGS");
                msg.ShowAsync();

            }
        }

        private async void DisplayCurrentUsersBookings()
        {
            try
            {
                foreach (var booking in _bookingListSingleton.GetBookings())
                {
                    if (booking.Membername == _userSingleton.GetName())
                    {
                        CurrentBookingList.Add(booking);
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.ToString();
                MessageDialog msg = new MessageDialog(error, "ERROR");
                msg.ShowAsync();
            }
        }
        
        private async void Load()
        {
            try
            {
                await _getBooking.LoadFromJson();
            }
            catch (Exception e)
            {
                string error = e.ToString();
                MessageDialog msg = new MessageDialog(error, "ERROR");
                msg.ShowAsync();
            }
        }

    }
}
