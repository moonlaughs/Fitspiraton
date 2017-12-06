using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitspiraton.Model;

namespace Fitspiraton.Interfaces
{
    class SingletonBMI
    {
        public static BMI _bmi;

        private static SingletonBMI Instance { get; set; }

        private SingletonBMI()
        {
            _bmi = new BMI();
        }

        public static SingletonBMI GetInstance()
        {
            if (Instance == null)
            {
                Instance = new SingletonBMI();
            }
            return Instance;
        }
        
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
