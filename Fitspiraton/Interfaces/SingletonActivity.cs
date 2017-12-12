using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitspiraton.Model;

namespace Fitspiraton.Interfaces
{
    public class SingletonActivity
    {
        //instance fields
        public static Activity _activity;

        //property
        private static SingletonActivity Instance { get; set; }

        //Constructor
        private SingletonActivity()
        {
            _activity = new Activity();
        }

        //method for getting the instance
        public static SingletonActivity GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SingletonActivity();
            }
            return Instance;
        }

        //method of the business logic
        public void SetActivity(Activity activity)
        {
            _activity = activity;
        }

        public new string GetType()
        {
            return _activity.Type;
        }

        public double GetPrice()
        {
            return _activity.Price;
        }

        public string GetTeacher()
        {
            return _activity.NameOfTeacher;
        }

        public string GetDescription()
        {
            return _activity.Description;
        }

        public string GetImage()
        {
            return _activity.ImgSource;
        }
    }
}
