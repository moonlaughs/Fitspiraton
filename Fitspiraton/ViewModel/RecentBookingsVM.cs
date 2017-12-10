using System.Collections.ObjectModel;
using Fitspiraton.Interfaces;
using Fitspiraton.Model;

namespace Fitspiraton.ViewModel
{
    class RecentBookingsVM : NotifyPropertyClass
    {
        private BookingListSingleton _bookingListSingleton;
        private Booking _selectedBooking;
        //public RelayCommand DeleteBookingCommand;
        
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

        public RecentBookingsVM()
        {
            _bookingListSingleton = BookingListSingleton.GetInstance();
            Bookings = _bookingListSingleton.GetBookings();
            SelectedBooking = new Booking();
            DeleteBookingCommand = new RelayCommand(DoDeleteBooking);
        }

        public void DoDeleteBooking()
        {
            //Bookings.Remove(SelectedBooking);
            _bookingListSingleton.GetBookings().Remove(SelectedBooking);
        }

    }
}
