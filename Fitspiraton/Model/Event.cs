using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitspiraton.Model
{
    public class Event
    {
        private DateTime _date;
        private string _type;
        private string _nameOfTeacher;
        private int _maxNumOfMembers;

        public DateTime Date { get => _date; set => _date = value; }
        public string Type { get => _type; set => _type = value; }
        public string NameOfTeacher { get => _nameOfTeacher; set => _nameOfTeacher = value; }
        public int MaxNumOfMembers { get => _maxNumOfMembers; set => _maxNumOfMembers = value; }
        public ObservableCollection<Event> Events{ get; set; }

        public Event(DateTime date, string type, string nameOfTeacher, int maxNumOfMembers)
        {
            Date = date;
            Type = type;
            NameOfTeacher = nameOfTeacher;
            MaxNumOfMembers = maxNumOfMembers;
        }

        public Event()
        {
            Events = new ObservableCollection<Event>()
            {
                new Event(new DateTime(2017,12,20),"Fitness","John", 20),
                new Event(new DateTime(2017,12,21),"Fitness","John", 20),
                new Event(new DateTime(2017,12,22),"Fitness","John", 20),
                new Event(new DateTime(2017,12,23),"Fitness","John", 20),
                new Event(new DateTime(2017,12,24),"Yoga","John", 20),
                new Event(new DateTime(2017,12,25),"Yoga","John", 20),
                new Event(new DateTime(2017,12,26),"Dance","John", 20),
                new Event(new DateTime(2017,12,27),"Dance","John", 20),
            };
        }
    }
}
