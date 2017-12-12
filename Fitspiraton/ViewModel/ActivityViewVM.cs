using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitspiraton.Interfaces;
using Fitspiraton.Model;

namespace Fitspiraton.ViewModel
{
    class ActivityViewVM : NotifyPropertyClass
    {
        private ObservableCollection<Activity> activitys;
        private Collector col;
        private ActivitySingleton _activitySingleton;
        private Activity _selectedActivity;

        public Activity SelectedActivity
        {
            get => _selectedActivity;
            set
            {
                _selectedActivity = value;
                OnPropertyChanged(nameof(SelecetedActivity));
            }

        }

        public ActivityViewVM()
        {
            col = new Collector();
            Activitys = col.Activitys;
            _activitySingleton = ActivitySingleton.GetInstance();
            _activitySingleton.SetActivity(SelecetedActivity);


        }

        public ObservableCollection<Activity> Activitys { get => activitys; set => activitys = value; }
        public Activity SelecetedActivity { get => _selectedActivity; set => _selectedActivity = value;  }
    }
}
