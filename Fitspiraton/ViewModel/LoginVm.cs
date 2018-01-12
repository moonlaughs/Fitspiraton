using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Fitspiraton.Interfaces;
using Fitspiraton.Model;
using Fitspiraton.Persistancy;
using Fitspiraton.View;

namespace Fitspiraton.ViewModel
{
    public class LoginVm :NotifyPropertyClass
    {
        //instance fields
        private Member _currentUser;
        private readonly FrameNavigateClass _frame;
        private readonly SingletonMember _userSingleton;                          //singleton
        private GetItem _getMembers;                                              //persistancy
        private ObservableCollection<Member> _membersCatalog;
    
        //properties
        private bool LoginStatus { get; set; }
        public Member Obj { get; set; }
        public RelayCommand CheckCommand { get; set; }

        //dynamic properties
        public Member CurrentUser {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser)); 
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

        //constructor
        public LoginVm()
        {
            _currentUser = new Member();
            _frame = new FrameNavigateClass();
            _userSingleton = SingletonMember.GetInstance();                  //singleton
            _getMembers = new GetItem();                                     //persistancy
            MemberCatalog = new ObservableCollection<Member>();
            CheckCommand = new RelayCommand(Check);
            Obj = new Member();
            LoadMembers();
        }

        //login method
        public async void Check()
        {
            LoginStatus = false;
            LoadMembers();                                                                            //persistancy
            if (Obj.Persons != null)
            {

                foreach (Member member in Obj.Persons)
                {
                    
                    if ((member.Id == CurrentUser.Id) && (member.Password == CurrentUser.Password))
                    {
                        _userSingleton.SetPerson(member);                                                       //singleton
                        LoginStatus = true;
                        _frame.ActivateFrameNavigation(typeof(UserMenu), member);
                        MessageDialog msg = new MessageDialog($"Welcome {member.Name}!");
                        await msg.ShowAsync();
                        break;
                    }
                    else if (("game" == CurrentUser.Id) && ("ofthrones" == CurrentUser.Password))
                    {
                        LoginStatus = true;
                        _frame.ActivateFrameNavigation(typeof(ManagerPage), member);
                        MessageDialog msg = new MessageDialog("Welcome George R.R. Martin");
                        await msg.ShowAsync();
                        break;
                    }
                }
                if (LoginStatus == false)
                {
                    MessageDialog msg = new MessageDialog("Sorry wrong input.");
                    await msg.ShowAsync();
                }
            }
        }

        //Load from json method
        public async void LoadMembers()
        {
            try
            {
                Obj.Persons = await _getMembers.LoadFromJson();
            }
            catch
            {
                await _getMembers.SavetoJson(Obj.Persons);
            }
        }
    }
}
