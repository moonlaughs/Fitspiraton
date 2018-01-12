using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Fitspiraton.Interfaces;
using Fitspiraton.Model;
using Fitspiraton.Persistancy;


// Not used ... Should be deleted 
namespace Fitspiraton.ViewModel
{
    class ManagerBookingsPageVm : NotifyPropertyClass
    {
        private BookingListSingleton _bookingListSingleton;
        private ObservableCollection<Booking> _bookings;
        private UserBookingVM _userBookingVm;

        private GetItem _getBooking;

        public ObservableCollection<Booking> Bookings
        {
            get => _bookings;
            set
            {
                _bookings = value;
            }
           
            
        }


        public ManagerBookingsPageVm()
        {
            _userBookingVm = new UserBookingVM();
            _bookingListSingleton = BookingListSingleton.GetInstance();

            Load();
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
