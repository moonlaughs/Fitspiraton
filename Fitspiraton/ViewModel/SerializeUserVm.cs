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

        //properties
        public RelayCommand AddItemCommand { get; set; }
        public RelayCommand DeleteItemCommand { get; set; }
        public RelayCommand UpdateItemCommand { get; set; }
        public Member AddNewMember { get; set; }
        public Member Up { get; set; }

        //dynamic properties
        public ObservableCollection<Member> MemberCatalog
        {
            get { return Up.Persons; }
            set
            {
                Up.Persons = value;
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
            _getMembers = new GetItem();

            Task.Run(()=> LoadMembers());                                      //serialization
        }

        //Loading method
        public async void LoadMembers()                                        //serialization
        {
            try
            {
                MemberCatalog = await _getMembers.LoadFromJson();
            }
            catch (Exception e)
            {
                foreach (Member upPerson in MemberCatalog)
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
        public async void DoUpdateItem()
        {
            await _getMembers.SavetoJson(MemberCatalog);
        }

        //D(elete)
        public async void DoDeleteItem()
        {
            MemberCatalog.Remove(SelectedItem);
            await _getMembers.SavetoJson(MemberCatalog);                       //serialization
        }
    }
}
