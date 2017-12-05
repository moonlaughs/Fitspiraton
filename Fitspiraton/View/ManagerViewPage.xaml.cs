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
    public sealed partial class ManagerViewPage : Page
    {
        public ManagerViewPage()
        {
            this.InitializeComponent();
            BackButton.Visibility = Visibility.Collapsed;
            ManagerFrame.Navigate(typeof(ManagerUsersPage));
            TitleTextBlock.Text = "Welcome, Admin !";
            Users.IsSelected = true;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerSplitView.IsPaneOpen = !ManagerSplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (ManagerFrame.CanGoBack)
            {
                ManagerFrame.GoBack();
                Users.IsSelected = true;
            }
        }

        private void ItemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Users.IsSelected)
            {
                BackButton.Visibility = Visibility.Collapsed;
                ManagerFrame.Navigate(typeof(ManagerUsersPage));
                TitleTextBlock.Text = "Edit the users";
            }
            else if (Calendar.IsSelected)
            {
                BackButton.Visibility = Visibility.Visible;
                ManagerFrame.Navigate(typeof(ManagerCalendarView));
                TitleTextBlock.Text = "Edit the calendar with classes";
            }
        }
    }
}
