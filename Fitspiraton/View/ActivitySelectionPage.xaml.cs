using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using Fitspiraton.Interfaces;
using Fitspiraton.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Fitspiraton.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ActivitySelectionPage : Page
    {
        private ActivitySingleton _activitySingleton;
        public ActivitySelectionPage()
        {
           _activitySingleton = ActivitySingleton.GetInstance();
            this.InitializeComponent();
     
 
            ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            DescriptionFrame.Navigate(typeof(SampleActivityPage));
        }

        private void StackPanel_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(UserMenu));
        }

        private void ListViewBase_OnItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var item = (Activity)e.ClickedItem;
                _activitySingleton.SetActivity(item);
                this.Frame.Navigate(typeof(SelectedActivityView));
            }
            catch (Exception exception)
            {
                //EXCEPTION HANDLING
            }
        }
    }
}
