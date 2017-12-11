﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitspiraton.Interfaces;

namespace Fitspiraton.ViewModel
{
    class BMIVm :NotifyPropertyClass
    {
        private readonly SingletonBMI _singleton;

        public RelayCommand ResultCommand { get; set; }

        public string Description { get; set; }
        public string Legend { get; set; }
        
        public BMIVm()
        {
            _singleton = SingletonBMI.GetInstance();
            Description = _singleton.GetDescriptin();
            Legend = _singleton.GetLegend();
        }
    }
}
