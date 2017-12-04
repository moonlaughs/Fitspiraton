﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Fitspiraton.Interfaces
{
    class FrameNavigateClass
    {
        public void ActivateFrameNavigation(Type type)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(type);
            Window.Current.Content = frame;
            Window.Current.Activate();
        }
    }
}