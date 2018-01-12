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
using System.Net;
using Windows.Security.Authentication.Web.Provider;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Fitspiraton.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class McDonalds : Page
    {
        public McDonalds()
        {
            this.InitializeComponent();
            Wb.Navigate(new Uri("https://www.google.dk/maps/search/nearest+Mcdonalds/@55.5893805,9.6126911,11z/data=!3m1!4b1"));
        }
    }
}
