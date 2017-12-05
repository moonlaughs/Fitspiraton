using System.Collections.ObjectModel;
using Fitspiraton.Model;

namespace Fitspiraton.ViewModel
{
    //Collect here all of the List<T>
    class Collector
    {
        //instanceFields
        private ObservableCollection<Member> _persons;

        //Properties
        public ObservableCollection<Member> Persons { get => _persons; set => _persons = value; }

        //Ctor
        public Collector()
        {
            Persons = new ObservableCollection<Member>()
            {
                new Member("Jon", "stark01", "youknownothing"),
                new Member("Arya", "stark02", "needle"),
                new Member("Patrik<3", "pat", "xxx")
            };
        }
    }
}
