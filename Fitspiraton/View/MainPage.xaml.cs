using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Fitspiraton.View;
using Windows.UI.Core;
using Fitspiraton.Persistancy;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Fitspiraton
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private GetItem get;
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;


            Load();

        }

        public async Task Load()
        {
            try
            {
                await get.LoadFromJson();
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int change = 1;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += (o, a) =>
            {
                // If we'd go out of bounds then reverse
                int newIndex = FlipView.SelectedIndex + change;
                if (newIndex >= FlipView.Items.Count || newIndex < 0)
                {
                    change *= -1;
                }

                FlipView.SelectedIndex += change;
            };
            timer.Start();
        }

        private void ItsLoading(FrameworkElement sender, object args)
        {
            LoadingBG.Visibility = Visibility.Visible;
            LoadingIMG.Visibility = Visibility.Visible;

        }

        private async void ItsLoaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(3000);
            LoadingBG.Visibility = Visibility.Collapsed;
            LoadingIMG.Visibility = Visibility.Collapsed;
        }
    }
}
