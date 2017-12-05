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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Fitspiraton.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserMenu : Page
    {
        public UserMenu()
        {
            this.InitializeComponent();
        }

        private void ProfileBtn_OnClicked(object sender, RoutedEventArgs e)
        {
            UserMenuFrame.Navigate(typeof(ProfileView));
        }

        private void RcentBtn_OnClicked(object sender, RoutedEventArgs e)
        {
            UserMenuFrame.Navigate(typeof(RecentBookingsView));
        }

        private void BackBtn_OnClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
