using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitspiraton.Model;
using Fitspiraton.ViewModel;

namespace Fitspiraton.ViewModel
{
    //Collect here all of the List<T>
    public class Collector: NotifyPropertyClass
    {
        private ObservableCollection<Member> _memberCollection;

      
        public ObservableCollection<Member> MemberCollector()
        {
            MemberCollection = new ObservableCollection<Member>
            {
                new Member("Jon", "Stark1", "you know nothing", "../Assets/UP/jon.jpg", 20),
                new Member("Arya", "Stark2", "needle", "../Assets/UP/arya.jpg", 18)
            };
            return MemberCollection;
        }

        internal ObservableCollection<Member> MemberCollection
        {
            get => _memberCollection;
            set => _memberCollection = value;
        }
        
    }
}
