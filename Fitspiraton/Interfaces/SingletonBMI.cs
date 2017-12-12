using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitspiraton.Model;

namespace Fitspiraton.Interfaces
{
    public class SingletonBMI
    {
        //instance field
        public static BMI _bmi;

        //property
        private static SingletonBMI Instance { get; set; }

        //Constructor
        private SingletonBMI()
        {
            _bmi = new BMI();
        }

        //method for getting the instance
        public static SingletonBMI GetInstance()
        {
            if(Instance == null)
            {
                Instance = new SingletonBMI();
            }
            return Instance;
        }

        //method of the business logic
        public string GetDescriptin()
        {
            return _bmi.Description;
        }

        public string GetLegend()
        {
            return _bmi.Legend;
        }
    }
}
