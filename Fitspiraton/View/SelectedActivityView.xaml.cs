using Windows.ApplicationModel.Store;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Fitspiraton.Interfaces;
using Fitspiraton.ViewModel;

namespace Fitspiraton.View
{
    public sealed partial class SelectedActivityView : Page
    {
        private SelectedActivityViewVM savm;
        public SelectedActivityView()
        {
            this.InitializeComponent();
            savm = new SelectedActivityViewVM();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UserBookingView));
        }
    }
}
