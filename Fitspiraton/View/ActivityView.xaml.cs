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
using Fitspiraton.Interfaces;
using Fitspiraton.Model;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Fitspiraton.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ActivityView : Page
    {
        private ActivitySingleton _activitySingleton;
        public ActivityView()
        {
            this.InitializeComponent();
            _activitySingleton = ActivitySingleton.GetInstance();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                this.Frame.Navigate(typeof(UserBookingView));
        }

        private void List_OnItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var item = (Activity)e.ClickedItem;
                _activitySingleton.SetActivity(item);
            }
            catch (Exception exception)
            {
                //EXCEPTION HANDLING
            }
        }
    }
}
