using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Fitspiraton.ViewModel;

namespace Fitspiraton.View
{
    public sealed partial class UserMenu : Page
    {
        private LoginVm log;

        public UserMenu()
        {
            this.InitializeComponent();
        }

        private void ProfileBtn_OnClicked(object sender, RoutedEventArgs e)
        {
            log = new LoginVm();
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
            log = new LoginVm();
            Frame.Navigate(typeof(ActivitySelectionPage),log.CurrentUser);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            log = new LoginVm();
            UserMenuFrame.Navigate(typeof(ProfileView),log.CurrentUser);
        }
    }
}
