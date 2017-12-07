using System.Collections.ObjectModel;
using Fitspiraton.Model;

namespace Fitspiraton.ViewModel
{
    //Collect here all of the List<T>
    class Collector
    {
        //instanceFields
        private ObservableCollection<Member> _persons;
        private ObservableCollection<Activity> _activitys;

        //Properties
        public ObservableCollection<Member> Persons { get => _persons; set => _persons = value; }
        public ObservableCollection<Activity> Activitys {  get => _activitys; set => _activitys = value; }

        //Ctor
        public Collector()
        {
            Persons = new ObservableCollection<Member>()
            {
                new Member("Jon", "stark01", "youknownothing",  "../Assets/UP/jon.jpg"),
                new Member("Arya", "stark02", "needle", "../Assets/UP/arya.jpg"),
                new Member("Patrik<3", "pat", "xxx", "../Assets/UP/sansa.jpg"),
                new Member("Iza", "moon", "ooo", "../Assets/UP/arya.jpg")
            };

            Activitys = new ObservableCollection<Activity>()
            {
                new Activity("Fitness",20,"JohnDoe","Descripton....","../Assets/own images/activities/thumbnails/fitness_thumbnail.png"),
                new Activity("Yoga",20,"JohnDoe","Descripton....","../Assets/own images/activities/thumbnails/yoga_thumbnail.png"),
                new Activity("Salsa",20,"JohnDoe","Descripton....","../Assets/own images/activities/thumbnails/salsa_thumbnail.png"),
                new Activity("TEST",20,"JohnDoe","Descripton....","../Assets/own images/activities/thumbnails/testActivity.png")

            };


        }
    }
}
