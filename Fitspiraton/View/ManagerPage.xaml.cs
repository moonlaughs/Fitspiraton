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

namespace Fitspiraton.View
{
    public sealed partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void Hambugerbutton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Customer_Btn_Click(object sender, RoutedEventArgs e)
        {
            ManagerFrame.Navigate(typeof(ManagerUsersPage));
        }

        private void Event_Btn_Click(object sender, RoutedEventArgs e)
        {
            ManagerFrame.Navigate(typeof(ManagerCalendarView));
        }

        private void Bookings_Btn_Click(object sender, RoutedEventArgs e)
        {
            ManagerFrame.Navigate(typeof(ManagerBookingsPage));
        }

        private void LogOut_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ManagerPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            ManagerFrame.Navigate(typeof(ManagerCalendarView));
        }
    }

    
}
