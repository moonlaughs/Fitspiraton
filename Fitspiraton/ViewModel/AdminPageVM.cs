using System.Collections.ObjectModel;
using Fitspiraton.Model;

namespace Fitspiraton.ViewModel
{
    class AdminPageVM : NotifyPropertyClass
    {
        private Member _selectedItem;

        private Collector _members;


       // public ObservableCollection<Member> Members { get; set; }

        public Collector Members { get; set; }

        public Member AddNewMember { get; set; }
        public RelayCommand AddItemCommand { get; set; }
        public RelayCommand DeleteItemCommand { get; set; }
        public RelayCommand UpdateItemCommand { get; set; }

        public Member SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public AdminPageVM()
        {
            _members = new Collector();
            

            //DeleteItemCommand = new RelayCommand(DoDeleteItem);
            //AddItemCommand = new RelayCommand(DoAddItem);
            //UpdateItemCommand = new RelayCommand(DoUpdateItem);

            AddNewMember = new Member();
            SelectedItem = new Member();
        }

        //Delete/Add
        //public void DoDeleteItem()
        //{
        //    Members.Remove(SelectedItem);
        //}
        //public void DoAddItem()
        //{
        //    Members.Add(AddNewMember);
        //}

        //public void DoUpdateItem()
        //{
        //    Members = new ObservableCollection<Member>
        //    {
        //        new Member(SelectedItem.Id, SelectedItem.Name , SelectedItem.Password, SelectedItem.Photo, SelectedItem.BmiResult)
        //    };
        //}
    }
}
