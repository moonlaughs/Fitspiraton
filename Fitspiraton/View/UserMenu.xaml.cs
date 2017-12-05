using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class UserMenu : Page
    {
        SolidColorBrush scb = new SolidColorBrush(Colors.Blue);
        SolidColorBrush scb1 = new SolidColorBrush(Colors.Black);

        public UserMenu()
        {
            this.InitializeComponent();
        }

        private void ProfileBtn_OnClicked(object sender, RoutedEventArgs e)
        {
            LoginVm log = new LoginVm();
            UserMenuFrame.Navigate(typeof(ProfileView), log.CurrentUser);
        }

        private void RcentBtn_OnClicked(object sender, RoutedEventArgs e)
        {
            UserMenuFrame.Navigate(typeof(RecentBookingsView));
        }

        private void BackBtn_OnClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginVm log = new LoginVm();
            Frame.Navigate(typeof(ActivitySelectionPage),log.CurrentUser);
        }
    }
}
