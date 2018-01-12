using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Fitspiraton.Interfaces;
using Fitspiraton.Model;
using Fitspiraton.ViewModel;


namespace Fitspiraton.View
{
    public sealed partial class UserBookingView : Page
    {
        private readonly EventListSingleton _eventListSingleton;
        private Collector col;
        private SolidColorBrush selectedColor;
        private SolidColorBrush red;
        private SelectedActivityViewVM savm;
        private BookingHandler _bookingHandler;
        private ObservableCollection<Event> _sortedEvents;
        private LoginVm log;
        private CurrentDateSingleton cds;
        private IList<DateTimeOffset> dates;

        public UserBookingView()
        {

            this.InitializeComponent();

            log = new LoginVm();
            col = new Collector();
            _bookingHandler = new BookingHandler();
            savm = new SelectedActivityViewVM();
            selectedColor = new SolidColorBrush(Colors.Yellow);
            red = new SolidColorBrush(Windows.UI.Colors.Red);
            cds = CurrentDateSingleton.GetInstance();

            CalendarView.SelectedDates.Add(new DateTime(2017, 10, 29)); // Set selected date is "x date");  
            CalendarView.MinDate = new DateTime(2017, 11, 1); //Min date is "x date " 
            CalendarView.MaxDate = DateTime.Now.AddMonths(12); //Max date is "x" months from current date
            CalendarView.NumberOfWeeksInView = 5; //Month view show "x" weeks at a time 
            CalendarView.SelectedForeground = selectedColor;

            _eventListSingleton = EventListSingleton.GetInstance();
            _eventListSingleton.SetEvents(col.Events);
            cds = CurrentDateSingleton.GetInstance();

            ChooseEventList();
            dates = new List<DateTimeOffset>();
        }

        public ObservableCollection<Event> ChooseEventList()
        {
            if (savm.Type == "Fitness")
            {
                _sortedEvents = _bookingHandler.Fitness;
            }
            if (savm.Type == "Yoga")
            {
                _sortedEvents = _bookingHandler.Yoga;
            }
            if (savm.Type == "Dance")
            {
                _sortedEvents = _bookingHandler.Salsa;
            }
            if (savm.Type == "Karate")
            {
                _sortedEvents = _bookingHandler.Karate;
            }
            if (savm.Type == "Pole dance")
            {
                _sortedEvents = _bookingHandler.Poledance;
            }
            if (savm.Type == "Ballet")
            {
                _sortedEvents = _bookingHandler.Ballet;
            }
            if (savm.Type == "Zumba")
            {
                _sortedEvents = _bookingHandler.Zumba;
            }
            return _sortedEvents;
        }


        private void CalendarDatePicker_DateChanged(CalendarDatePicker sender,
            CalendarDatePickerDateChangedEventArgs args)
        {
            //Checking selected date is null  
            if (args.NewDate != null)
            {
                /* Getting selected new date value*/
                DisplayDate(args.NewDate.Value.ToString());
            }
        }

        private async void DisplayDate(string selectedDate)
        {
            ContentDialog noWifiDialog = new ContentDialog()
            {
                Title = "Windows 10 Calendar Control",
                Content = "Selected date is: " + selectedDate,
                PrimaryButtonText = "Ok"
            };
            noWifiDialog.Margin = new Thickness(0, 100, 0, 0);
            await noWifiDialog.ShowAsync();
        }

        private void CalendarView_CalendarViewDayItemChanging(CalendarView sender,
            CalendarViewDayItemChangingEventArgs args)
        {
            try
            {
                // Render basic day items.
                if (args.Phase == 0)
                {
                    // Register callback for next phase.
                    args.RegisterUpdateCallback(CalendarView_CalendarViewDayItemChanging);
                }
                // Set blackout dates.
                else if (args.Phase == 1)
                {
                    // Blackout dates in the past, Sundays, and dates that are fully booked.
                    if (args.Item.Date < DateTimeOffset.Now ||
                        args.Item.Date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        args.Item.IsBlackout = true;
                    }
                    // Register callback for next phase.
                    args.RegisterUpdateCallback(CalendarView_CalendarViewDayItemChanging);
                }
                // Set density bars.
                else if (args.Phase == 2)
                {
                    foreach (var Event in _sortedEvents)
                    {
                        if (args.Item.Date.Equals(Event.Date))
                        {
                            args.Item.Background = red;
                        }
                    }
                }
            }
            catch (Exception Expection)
            {
                // Handle the exception <3   
            }

        }

        private void CalendarView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            dates = CalendarView.SelectedDates;
            try
            {
                foreach (var date in dates)
                {
                    cds.SetCurrentDate(date);
                }
            }
            catch (Exception exception)
            {

                string ne = exception.ToString();
                MessageDialog msg = new MessageDialog(ne, "");
                msg.ShowAsync();
            }
        }
    }
}
