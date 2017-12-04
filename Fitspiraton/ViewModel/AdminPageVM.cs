using System.Collections.ObjectModel;
using Fitspiraton.Model;

namespace Fitspiraton.ViewModel
{
    class AdminPageVM : NotifyPropertyClass
    {
        private User _selectedItem;

        public ObservableCollection<User> Users { get; set; }
        public User AddNewUser { get; set; }
        public RelayCommand AddItemCommand { get; set; }
        public RelayCommand DeleteItemCommand { get; set; }
        public RelayCommand UpdateItemCommand { get; set; }

        public User SelectedItem
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
            

            //Users = new ObservableCollection<User>
            //{
            //    new User("Jon", "stark01", "youknownothing", "../Assets/UP/jon.jpg"),
            //    new User("Arya", "stark02", "needle", "../Assets/UP/arya.jpg")
            //};
            DeleteItemCommand = new RelayCommand(DoDeleteItem);
            AddItemCommand = new RelayCommand(DoAddItem);
            UpdateItemCommand = new RelayCommand(DoUpdateItem);

            AddNewUser = new User();
            SelectedItem = new User();
        }

        // Delete/Add 
        public void DoDeleteItem()
        {
            Users.Remove(SelectedItem);
        }
        public void DoAddItem()
        {
            Users.Add(AddNewUser);
        }

        public void DoUpdateItem()
        {
            Users = new ObservableCollection<User>
            {
                new User(SelectedItem.Id, SelectedItem.Name , SelectedItem.Password, SelectedItem.Photo)
            };
        }
    }
}
