using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Fitspiraton.ViewModel
{
    public class NotifyPropertyClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    internal class NotifyPropertyChangedInvocatorAttribute : Attribute
    {
    }
}
