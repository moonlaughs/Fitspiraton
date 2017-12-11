using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Fitspiraton.Interfaces
{
    public class FrameNavigateClass
    {
        public void ActivateFrameNavigation(Type type, Object currentUser)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(type , currentUser);
            Window.Current.Content = frame;
            Window.Current.Activate();
        }
    }
}
