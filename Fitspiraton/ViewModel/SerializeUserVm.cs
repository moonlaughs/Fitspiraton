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
        private FrameNavigateClass _frame = new FrameNavigateClass();

        private Member _selectedItem;

        private GetItem getMembers;

        public RelayCommand AddItemCommand { get; set; }
        public RelayCommand DeleteItemCommand { get; set; }
        public RelayCommand UpdateItemCommand { get; set; }

        public Member AddNewMember { get; set; }
        public Member Up { get; set; }

        private ObservableCollection<Member> _members;

        private ObservableCollection<Member> _membersCatalog;
        
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

        public SerializeUserVm()
        {
            //Members = new ObservableCollection<Member>
            //{

            //    new Member("Jon", "stark01", "youknownothing", "../Assets/UP/jon.jpg"),
            //    new Member("Arya", "stark02", "needle", "../Assets/UP/arya.jpg")
            //}

            AddNewMember = new Member();
            Up = new Member();
            //MemberCatalog = new ObservableCollection<Member>()
            //{
            //    new Member("Jon", "stark01", "youknownothing", "../Assets/UP/jon.jpg"),
            //    new Member("Arya", "stark02", "needle", "../Assets/UP/arya.jpg")
            //};
            MemberCatalog = new ObservableCollection<Member>();
            
            getMembers = new GetItem();


            AddItemCommand = new RelayCommand(DoAddMember);
            DeleteItemCommand = new RelayCommand(DoDeleteItem);
            UpdateItemCommand = new RelayCommand(DoUpdateItem);


            SelectedItem = new Member();

            //LoadMembers();
        }

        public async void DoAddMember()
        {
            MemberCatalog.Add(AddNewMember);
            await getMembers.SavetoJson(MemberCatalog);
            await LoadMembers();
        }

        public async Task LoadMembers()
        {
            try
            {
                MemberCatalog = await getMembers.LoadFromJson();
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
        }

        public async void DoDeleteItem()
        {
            MemberCatalog.Remove(SelectedItem);
            await getMembers.SavetoJson(MemberCatalog);
        }

        public async void DoUpdateItem()
        {
            await LoadMembers();
            Up = new Member(SelectedItem.Name, SelectedItem.Id, SelectedItem.Password, SelectedItem.Photo);
            MemberCatalog.Add(Up);
            MemberCatalog.Remove(SelectedItem);
            await getMembers.SavetoJson(MemberCatalog);
            await LoadMembers();

        }
    }
}
