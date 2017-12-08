using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitspiraton.Interfaces;
using Fitspiraton.Model;

namespace Fitspiraton.ViewModel
{
    class RecentBookingsVM
    {
        private BookingSingleton _bookingSingleton;
        public ObservableCollection<Booking> Bookings { get; set; }


        public RecentBookingsVM()
        {
            _bookingSingleton = BookingSingleton.GetInstance();
            Bookings = _bookingSingleton.GetBookings();
        }
    }
}
