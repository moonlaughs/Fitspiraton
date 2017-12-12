using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Fitspiraton.Interfaces;
using Fitspiraton.Model;

namespace Fitspiraton.ViewModel
{
    class ActivityVm : NotifyPropertyClass
    {
        //instance fields
        private Activity _activity;
        private ObservableCollection<Activity> _activities;
        private Activity _selectedItem;
        public readonly SingletonActivity _userSingleton;                      //singleton

        //properties
        public string Type { get; set; }
        public double Price { get; set; }
        public string Teacher { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        //dynamic properties
        public Activity SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ObservableCollection<Activity> Activities
        {
            get { return _activities; }
            set
            {
                _activities = value;
                OnPropertyChanged(nameof(Activities));
            }
        } 

        //constructor
        public ActivityVm()
        {
            _activity = new Activity();
            _selectedItem = new Activity();
            _userSingleton = SingletonActivity.GetInstance();

            _activities = _activity.Activities;

            Type = _userSingleton.GetType();                                    //singleton
            Price = _userSingleton.GetPrice();
            Teacher = _userSingleton.GetTeacher();
            Description = _userSingleton.GetDescription();
            Image = _userSingleton.GetImage();
        }
    }
}
