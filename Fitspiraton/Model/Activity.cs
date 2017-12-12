using System.Collections.ObjectModel;

namespace Fitspiraton.Model
{
    public class Activity
    {
        //auto properties
        public ObservableCollection<Activity> Activities { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string NameOfTeacher { get; set; }
        public string Description { get; set; }
        public string ImgSource { get; set; }

        //constructors
        public Activity(string type, double price, string nameOfTeacher, string description, string imgSource)
        {
            Type = type;
            Price = price;
            NameOfTeacher = nameOfTeacher;
            Description = description;
            ImgSource = imgSource;
        }

        public Activity()
        {
            Activities = new ObservableCollection<Activity>()
            {
                new Activity("Pole Dance", 50, "Natalia Koszyk", "Best sprot ever, but hard as hell", "../Assets/own images/activities/thumbnails/fitness_thumbnail.png")
            };
        }
        
    }
}
