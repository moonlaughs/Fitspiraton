using System;
using System.Collections.ObjectModel;
using Windows.Security.Cryptography.Core;
using Windows.UI.Popups;
using Fitspiraton.Interfaces;
using Fitspiraton.Model;

namespace Fitspiraton.ViewModel
{
    class RecentBookingsVM : NotifyPropertyClass
    {
        private BookingListSingleton _bookingListSingleton;
        private Booking _selectedBooking;
        private LoginVm lvm;
        private ObservableCollection<Booking> CurrentBookingList;

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
            lvm = new LoginVm();
            _bookingListSingleton = BookingListSingleton.GetInstance();
            DisplayCurrentUsersBookings();
            Bookings = CurrentBookingList;
           // ExistingBookingCheck();
            SelectedBooking = new Booking();
            DeleteBookingCommand = new RelayCommand(DoDeleteBooking);
        }

        public void DoDeleteBooking()
        { 
            _bookingListSingleton.GetBookings().Remove(SelectedBooking);
        }
        //Not working 
        private void ExistingBookingCheck()
        {
            if (Bookings.Count == 0)
            {
                MessageDialog msg = new MessageDialog("Your booking list is empty. Book your first event in the booking menu","NO BOOKINGS");
                
            }   
        }

        private void DisplayCurrentUsersBookings()
        {
            try
            {
                foreach (var booking in _bookingListSingleton.GetBookings())
                {
                    if (booking.Membername == lvm.CurrentUser.Id)
                    {
                        
                        CurrentBookingList = new ObservableCollection<Booking>();
                        CurrentBookingList.Add(booking);
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.ToString();
                MessageDialog msg = new MessageDialog(error,"ERROR");
            }
        }

    }
}
