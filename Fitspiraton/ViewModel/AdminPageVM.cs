//using System;
//using System.Collections.ObjectModel;
//using System.IO;
//using System.Threading.Tasks;
//using Windows.Storage;
//using Windows.UI.Xaml;
//using Fitspiraton.Model;
//using Fitspiraton.Persistancy;
//using Newtonsoft.Json;

//namespace Fitspiraton.ViewModel
//{
//    class AdminPageVM : NotifyPropertyClass
//    {
//        private User _selectedItem;

//        private static Facade _facade;

//        public ObservableCollection<User> Users { get; set; }
//        public User AddNewUser { get; set; }
//        public RelayCommand AddItemCommand { get; set; }
//        public RelayCommand DeleteItemCommand { get; set; }
//        public RelayCommand UpdateItemCommand { get; set; }

//        //Iza
//        //public ObservableCollection<Member> Members { get; set; }
//        private Member _loadUser;
//        private string _displayVisibility;
//        private Collector _members;
//        public Collector Members { get { return _members; } set { _members = value; OnPropertyChanged(nameof(Members)); } }

//        public static Member AddNewMember { get; set; }

//        public User SelectedItem
//        {
//            get => _selectedItem;
//            set
//            {
//                _selectedItem = value;
//                OnPropertyChanged(nameof(SelectedItem));
//            }
//        }

//        public AdminPageVM()
//        {
//            Users = new ObservableCollection<User>
//            {
//                new User("Jon", "stark01", "youknownothing", "../Assets/UP/jon.jpg"),
//                new User("Arya", "stark02", "needle", "../Assets/UP/arya.jpg")
//            };
//            DeleteItemCommand = new RelayCommand(DoDeleteItem);
//            AddItemCommand = new RelayCommand(DoAddItem);
//            UpdateItemCommand = new RelayCommand(DoUpdateItem);

//            AddNewUser = new User();
//            SelectedItem = new User();

//            _facade = new Facade();
//            Members = new Collector();
//            AddNewMember = new Member();

//            _loadUser = new Member();

//            //this.ShowList();

//            //Task.Run(() => ShowList());
//            DownLoadMembers();
//        }

//        // Delete/Add 
//        public void DoDeleteItem()
//        {
//            Users.Remove(SelectedItem);
//        }
//        public void DoAddItem()
//        {
//            //_facade.LoadPersons(Persons);
//            //Task.Run(() => Load());
//            //var member = new Member(AddNewMember.Name, AddNewMember.Id, AddNewMember.Password, AddNewMember.Photo);
//            Members.Persons.Add(AddNewMember);
//            //SAVE THE DATA: PERSISTANCY SERIALIZATION!!!!!!!!!!!!!!!!!!!!
//            //_facade.LoadPersons();
//            _facade.SaveMembers(AddNewMember);
//        }

//        public void DoUpdateItem()
//        {
//            Users = new ObservableCollection<User>
//            {
//                new User(SelectedItem.Id, SelectedItem.Name , SelectedItem.Password, SelectedItem.Photo)
//            };
//        }

//        //public async void Load()
//        //{
//        //    try
//        //    {
//        //        await _facade.LoadMEmberFile();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        string error = ex.Message;
//        //    }

//        //    _facade.SaveMembers(AddNewMember);
//        //}

//        //public Member LoadMember
//        //{
//        //    get { return this._loadUser; }
//        //    set
//        //    {
//        //        this._loadUser = value;
//        //        OnPropertyChanged(nameof(LoadMember));
//        //    }
//        //}

//        //public string DisplayVisibility

//        //{

//        //    get { return this._displayVisibility; }

//        //    set

//        //    {

//        //        this._displayVisibility = value;

//        //        OnPropertyChanged(nameof(DisplayVisibility));

//        //    }

//        //}

//        //public string ShowList()
//        //{
//        //    try
//        //    {
//        //        string member = Members.ToString();
//        //        LoadMember = JsonConvert.DeserializeObject<Member>(member);
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        string error = ex.Message;
//        //    }
//        //    return LoadMember.ToString();
//        //}

//        private static StorageFile _membersFile;

//        public static async void DownLoadMembers()
//        {
//            _membersFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("MEmbers.json", CreationCollisionOption.ReplaceExisting);

//            File.WriteAllText(_membersFile.Path, _facade.LoadMEmberFile().ToString());



//            ////Load created JSON file into collection

//            //_membersFile = await ApplicationData.Current.LocalFolder.GetFileAsync("MEmbers.json");

//            //_members = JsonConvert.DeserializeObject<ObservableCollection<Member>>(File.ReadAllText(_membersFile.Path));

//            //AccommodationsCollection.SetAccommodationsCollection(_members);
//        }
//    }
//}
