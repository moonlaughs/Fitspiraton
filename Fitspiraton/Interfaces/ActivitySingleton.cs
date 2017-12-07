using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitspiraton.Model;

namespace Fitspiraton.Interfaces
{
    class ActivitySingleton
    {
        public static Activity _activity;

        private static ActivitySingleton Instance { get; set; }

        private ActivitySingleton()
        {
            _activity = new Activity();
        }

        public static ActivitySingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ActivitySingleton();
            }
            return Instance;
        }

        //private string _type;
        //private int _maxNumOfMembers;
        //private string _nameOfTeacher;
        //private string _description;
        //private string _imgSource;

        public void SetActivity(Activity activity)
        {
           _activity  = activity;
        }

        public string GetType()
        {
            return _activity.Type;
        }

        public int GetNumberOfMembers()
        {
            return _activity.MaxNumOfMembers;
        }

        public string GetNameOfTeacher()
        {
            return _activity.NameOfTeacher;
        }

        public string GetDescription()
        {
            return _activity.Description;
        }

        public string GetImageSource()
        {
            return _activity.ImgSource;
        }
    }
}
