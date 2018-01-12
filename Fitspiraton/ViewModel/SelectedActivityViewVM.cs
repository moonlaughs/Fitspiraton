using System;
using Fitspiraton.Interfaces;

namespace Fitspiraton.ViewModel
{
    class SelectedActivityViewVM
    {
        private ActivitySingleton _singelton;

        public string ImgSource { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string NameOfTeacher { get; set; }

        public SelectedActivityViewVM()
        {
            _singelton = ActivitySingleton.GetInstance();

            ImgSource = _singelton.GetImageSource();
            Type = _singelton.GetType();
            Description = _singelton.GetDescription();
            NameOfTeacher = _singelton.GetNameOfTeacher();
        }
    }
}
