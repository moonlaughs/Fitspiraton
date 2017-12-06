using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
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
    public sealed partial class ProfileView : Page
    {

        public ProfileView()
        {
            this.InitializeComponent();
        }

        private void countBtn_Click(object sender, RoutedEventArgs e)
        {


            if ((WeightBox.Text !="0")&&(HeightBox.Text != "0"))
            {
                double weight = Convert.ToDouble(WeightBox.Text);
                double height = Convert.ToDouble(HeightBox.Text);

                double bmi = weight / (height * height);

                var bmi2 = String.Format("{0:00}", bmi);

                ResultBlock.Text = $"Result: {bmi2}";
            }
            else
            {
                ResultBlock.Text = "Wrong values";
            }
           
        }
    }
}
