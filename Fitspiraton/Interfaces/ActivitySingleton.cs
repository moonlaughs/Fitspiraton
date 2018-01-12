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

        public void SetActivity(Activity activity)
        {
           _activity  = activity;
        }

        public string GetType()
        {
            return _activity.Type;
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
