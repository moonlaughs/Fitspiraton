using Fitspiraton.Model;

namespace Fitspiraton.Interfaces
{
    class BookingSingleton
    {
        public static Booking _booking;
        public static BookingSingleton Istance { get; set; }

        private BookingSingleton()
        {
            _booking = new Booking();
        }

        public static BookingSingleton GetInstance()
        {
            if (Istance == null)
            {
                Istance = new BookingSingleton();
            }
            return Istance;
        }

        public void SetBooking(Booking booking)
        {
            _booking = booking;
        }

        public Booking GetBooking()
        {
            return _booking;
        }

    }
}
