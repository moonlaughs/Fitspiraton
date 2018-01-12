using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitspiraton.Model;

namespace Fitspiraton.Interfaces
{
    class ActivitySingletonList
    {
        public ObservableCollection<Activity> _activitys;

        public static ActivitySingletonList Instance { get; set; }

        private ActivitySingletonList()
        {
            _activitys = new ObservableCollection<Activity>();
        }

        public static ActivitySingletonList GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ActivitySingletonList();
            }
            return Instance;
        }

        public void SetActivitys(ObservableCollection<Activity> activitys)
        {
            _activitys = activitys;
        }

        public ObservableCollection<Activity> GetActivitys()
        {
            return _activitys;
        }
    }
}
