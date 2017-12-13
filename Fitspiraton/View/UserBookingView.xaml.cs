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


        public UserBookingView()
        {

            this.InitializeComponent();

            log = new LoginVm();
            col = new Collector();
            _bookingHandler = new BookingHandler();
            savm = new SelectedActivityViewVM();
            selectedColor = new SolidColorBrush(Colors.Yellow);
            red = new SolidColorBrush(Windows.UI.Colors.Red);

            string name = log.CurrentUser.Name;
            //UserTestBox.Text = name;


            CalendarView.SelectedDates.Add(new DateTime(2017, 10, 29)); // Set selected date is "x date");  
            CalendarView.MinDate = new DateTime(2017, 11, 1); //Min date is "x date " 
            CalendarView.MaxDate = DateTime.Now.AddMonths(12); //Max date is "x" months from current date
            CalendarView.NumberOfWeeksInView = 5; //Month view show "x" weeks at a time 
            CalendarView.SelectedForeground = selectedColor;

            _eventListSingleton = EventListSingleton.GetInstance();
            _eventListSingleton.SetEvents(col.Events);

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
                _sortedEvents = _bookingHandler.Dance;
            }
            if (savm.Type != "Fitness" && savm.Type != "Dance" && savm.Type != "Yoga")
            {
                _sortedEvents = _bookingHandler.Unhandeled;
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
                        //else
                        //{
                        //    args.Item.IsBlackout = true;
                        //}
                    }
                }
            }
            catch (Exception Expection)
            {
                // Handle the exception <3   
            }

        }

        private IList<DateTimeOffset> dates;
        public DateTimeOffset chosenDate;

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //    try
        //    {
        //        dates =  CalendarView.SelectedDates;

        //        foreach (var date in dates)
        //        {
        //            chosenDate = date;
        //        }

        //        UserTestBox.Text = chosenDate.ToString();
        //    }
        //    catch (Exception exception)
        //    {

        //        string ne = exception.ToString();
        //       MessageDialog msg = new MessageDialog( ne,"");
        //        msg.ShowAsync();
        //    }
        //}
    }
}
