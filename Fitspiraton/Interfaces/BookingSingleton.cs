using System.Collections.ObjectModel;
using Fitspiraton.Model;

namespace Fitspiraton.Interfaces
{
    class BookingSingleton
    {
        public static ObservableCollection<Booking> _bookings;

        private static BookingSingleton Instance { get; set; }

        private BookingSingleton()
        {
            _bookings = new ObservableCollection<Booking>();
        }

        public static BookingSingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new BookingSingleton();
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

