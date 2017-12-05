using System;
using System.Collections.Generic;
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

        public ManagerCalendarView()
        {
            this.InitializeComponent();
            
        }

        private void CalendarView_OnCalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        {
            SolidColorBrush red = new SolidColorBrush(Windows.UI.Colors.Red);
            _collectionEventSingleton = CollectionEventSingleton.GetInstance();    
            foreach (var eventDates in _collectionEventSingleton.GetEvents())
            {
                if (args.Item.Date.Equals(eventDates.Date))
                {
                    args.Item.Background = red;
                }
            }
        }
    }
}
