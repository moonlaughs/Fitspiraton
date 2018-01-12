using System.Collections.ObjectModel;
using Fitspiraton.Model;

namespace Fitspiraton.Interfaces
{
    public class BookingListSingleton
    {
        public static ObservableCollection<Booking> _bookings;

        private static BookingListSingleton Instance { get; set; }

        private BookingListSingleton()
        {
            _bookings = new ObservableCollection<Booking>();
        }

        public static BookingListSingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new BookingListSingleton();
            }
            return Instance;
        }

        public void SetBooking(ObservableCollection<Booking> bookings)
        {
            _bookings =  bookings;
        }

        public ObservableCollection<Booking> GetBookings()
        {
            return _bookings;
        }
    }
}

