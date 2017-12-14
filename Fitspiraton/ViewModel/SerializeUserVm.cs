using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using Fitspiraton.Interfaces;
using Fitspiraton.Model;
using Fitspiraton.Persistancy;
using Fitspiraton.View;

namespace Fitspiraton.ViewModel
{
    public class SerializeUserVm :NotifyPropertyClass
    {
        //instance fields
        private Member _selectedItem;
        private readonly GetItem _getMembers;                                   //serialization
        private ObservableCollection<Member> _members;
        private ObservableCollection<Member> _membersCatalog;

        //properties
        public RelayCommand AddItemCommand { get; set; }
        public RelayCommand DeleteItemCommand { get; set; }
        public RelayCommand UpdateItemCommand { get; set; }
        public Member AddNewMember { get; set; }
        public Member Up { get; set; }

        //dynamic properties
        public ObservableCollection<Member> Members
        {
            get { return _members; }
            set
            {
                _members = value;
                OnPropertyChanged(nameof(Members));
            }
        }
        public ObservableCollection<Member> MemberCatalog
        {
            get { return _membersCatalog; }
            set
            {
                _membersCatalog = value;
                OnPropertyChanged(nameof(MemberCatalog));
            }
        }
        public Member SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        //constructor
        public SerializeUserVm()
        {
            //initializing objects
            AddNewMember = new Member();
            Up = new Member();
            AddItemCommand = new RelayCommand(DoAddMember);
            DeleteItemCommand = new RelayCommand(DoDeleteItem);
            UpdateItemCommand = new RelayCommand(DoUpdateItem);
            SelectedItem = new Member();
            _getMembers = new GetItem();                                       //serialization
            MemberCatalog = new ObservableCollection<Member>();

            Task.Run(()=> LoadMembers());                                      //serialization
        }

        //Loading method
        public async void LoadMembers()                                        //serialization
        {
            try
            {
                MemberCatalog = await _getMembers.LoadFromJson();
                //Up.Persons = MemberCatalog;
            }
            catch (Exception e)
            {
                foreach (Member upPerson in Up.Persons)
                {
                    var person = upPerson;
                }
                string error = e.Message;
            }
        }

        //CRUD methods
        //CR(eate)
        public async void DoAddMember()
        {
            
            MemberCatalog.Add(AddNewMember);
            await _getMembers.SavetoJson(MemberCatalog);                       //serialization
        }
        
        //U(pdate)
        public void DoUpdateItem()
        {
            //await LoadMembers();
            //Up = new Member(SelectedItem.Name, SelectedItem.Id, SelectedItem.Password, SelectedItem.Photo);
            //MemberCatalog.Add(Up);
            //MemberCatalog.Remove(SelectedItem);
            //await _getMembers.SavetoJson(MemberCatalog);
            //await LoadMembers();

            MemberCatalog = new ObservableCollection<Member>
           {
                new Member(SelectedItem.Name, SelectedItem.Id , SelectedItem.Password, SelectedItem.Photo)
           };

            //await LoadMembers();
        }

        //D(elete)
        public async void DoDeleteItem()
        {
            MemberCatalog.Remove(SelectedItem);
            await _getMembers.SavetoJson(MemberCatalog);                       //serialization
        }
    }
}
