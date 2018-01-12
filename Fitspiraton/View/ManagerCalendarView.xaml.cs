using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp;
using Fitspiraton.Model;
using Fitspiraton.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Fitspiraton.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ManagerCalendarView : Page
    {
        private CollectionEventSingleton _collectionEventSingleton;
        private Collector CalendarViewCollector = new Collector();

        public ManagerCalendarView()
        {
            this.InitializeComponent();
            ManagerEventCalendarView.MinDate = new DateTime(2017,11,25);
            ManagerEventCalendarView.MaxDate = DateTime.Now.AddMonths(3); 
            ManagerDatePicker.Date = DateTime.Now;
            _collectionEventSingleton = CollectionEventSingleton.GetInstance();
            _collectionEventSingleton.SetEvent(CalendarViewCollector.Events);
        }

       private void CalendarView_OnCalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
       {
            SolidColorBrush red = new SolidColorBrush(Windows.UI.Colors.Red);

             foreach (var eventDates in _collectionEventSingleton.GetEvents())
             {
                 if (args.Item != null && args.Item.Date.Equals(eventDates.Date))
                 {
                     args.Item.Background = red;
                 }
             }
       }

        private void DatePicker_OnDateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            DateTimeOffset addedDate = ManagerDatePicker.Date;
            Event aD = new Event(addedDate);
            _collectionEventSingleton.AddEventDate(aD);
        }


       
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ManagerEventCalendarView.CalendarViewDayItemChanging += CalendarView_OnCalendarViewDayItemChanging;
        }
    }
    
}
