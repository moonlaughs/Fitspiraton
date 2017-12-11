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
using Windows.UI.Xaml.Documents;
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
            try
            {
                if ((WeightBox != null) && (HeightBox != null))
                {
                    if ((WeightBox.Text != "0") && (HeightBox.Text != "0"))
                    {

                        double weight = Convert.ToDouble(WeightBox.Text);
                        double height = Convert.ToDouble(HeightBox.Text);

                        double bmi = weight / (height * height);

                        var bmi2 = String.Format("{0:00}", bmi);
                        if (bmi < 1)
                        {
                            ResultBlock.Foreground = new SolidColorBrush(Colors.DarkBlue);
                            CommentBlock.Visibility = Visibility.Visible;
                            ResultBlock.Text = "Wrong input, \nmake sure that you typed height in \nMETERS \nand weight in \nKILOGRAMS ;)";
                            SmallFrame.Visibility = Visibility.Collapsed;
                        }
                        else if (bmi < 18.6)
                        {

                            ResultBlock.Foreground = new SolidColorBrush(Colors.Yellow);
                            ResultBlock.Text = $"Result: {bmi2}";
                            CommentBlock.Visibility = Visibility.Visible;
                            CommentBlock.Text = "You are way too skinny, \nhere is our solution for you ;) \ngo ahead and check here:";
                            SmallFrame.Visibility = Visibility.Visible;
                            SmallFrame.Navigate(typeof(McDonalds));
                        }
                        else if (bmi < 25)
                        {

                            ResultBlock.Foreground = new SolidColorBrush(Colors.Green);
                            ResultBlock.Text = $"Result: {bmi2}";
                            CommentBlock.Visibility = Visibility.Visible;
                            CommentBlock.Text = "Your BMI is perfect, \ntry keep it up \nby picking your favouirite activity \nin our fitness center \nand keep your diet healthy! \nWe believe in you ♥";
                            SmallFrame.Visibility = Visibility.Collapsed;
                        }
                        else if (bmi < 30)
                        {

                            ResultBlock.Foreground = new SolidColorBrush(Colors.Orange);
                            ResultBlock.Text = $"Result: {bmi2}";
                            CommentBlock.Visibility = Visibility.Visible;
                            CommentBlock.Text = "Your BMI is above the average. \nPick your favourite activity in Fitspiration \nand come back to your PERFECT shape ;)";
                            SmallFrame.Visibility = Visibility.Collapsed;
                        }
                        else if (bmi > 29.9)
                        {

                            ResultBlock.Foreground = new SolidColorBrush(Colors.Red);
                            ResultBlock.Text = $"Result: {bmi2}";
                            CommentBlock.Visibility = Visibility.Visible;
                            CommentBlock.Text =
                                "Your BMI is not in a good level.\nYou have to practise more. \nContact one of our consultants at Fitspiration \nso they can help you with making\nyour own, unique plan for exercises and will guide you with a healthy diet.\nDo not worry,\nFitspiration is here for you to help You";
                            SmallFrame.Visibility = Visibility.Collapsed;
                        }
                        
                    }
                    else
                    {
                        ResultBlock.Foreground = new SolidColorBrush(Colors.DarkBlue);
                        ResultBlock.Text = "Wrong values";
                        SmallFrame.Visibility = Visibility.Collapsed;
                        CommentBlock.Visibility = Visibility.Collapsed;
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                ResultBlock.Foreground = new SolidColorBrush(Colors.Red);
                ResultBlock.Text = "Enter the values";
                SmallFrame.Visibility = Visibility.Collapsed;
                CommentBlock.Visibility = Visibility.Collapsed;
            }
        } 
    }
}

