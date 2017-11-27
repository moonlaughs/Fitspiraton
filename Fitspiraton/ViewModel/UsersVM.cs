using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitspiraton.Model;

namespace Fitspiraton.ViewModel
{
    class UsersVM : NotifyPropertyClass
    {
        private Users _selectedItem;


        public ObservableCollection<Users> Users { get; set; }


        public Users AddNewUser { get; set; }

        public RelayCommand AddItemCommand { get; set; }
        public RelayCommand DeleteItemCommand { get; set; }
        public RelayCommand UpdateItemCommand { get; set; }



        public Users SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }


        public UsersVM()
        {
            Users = new ObservableCollection<Users>
            {
                new Users("Jon", "stark01", "youknownothing", "../Assets/UP/jon.jpg"),
                new Users("Arya", "stark02", "needle", "../Assets/UP/arya.jpg")
            };
            DeleteItemCommand = new RelayCommand(DoDeleteItem);
            AddItemCommand = new RelayCommand(DoAddItem);
            UpdateItemCommand = new RelayCommand(DoUpdateItem);

            AddNewUser = new Users();
            SelectedItem = new Users();
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
            Users = new ObservableCollection<Users>
            {
                new Users(SelectedItem.id, SelectedItem.name , SelectedItem.password, SelectedItem.photo)
            };
        }
    }
}
