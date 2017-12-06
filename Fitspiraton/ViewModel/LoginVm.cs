using System;
using Windows.UI.Popups;
using Fitspiraton.Interfaces;
using Fitspiraton.Model;
using Fitspiraton.View;

namespace Fitspiraton.ViewModel
{
    class LoginVm :NotifyPropertyClass
    {
        private bool LoginStatus { get; set; }

        private Member _currentUser = new Member();

        public Member CurrentUser {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser)); 
            }
        }

        public Collector Col { get; set; }

        public RelayCommand CheckCommand { get; set; }
        private readonly FrameNavigateClass _frame = new FrameNavigateClass();
        private readonly SingletonMember _userSingleton;

        public async void Check()
        {
            LoginStatus = false;
            if (Col.Persons != null)
            {

                foreach (Member mem in Col.Persons)
                {
                    
                    if ((mem.Id == CurrentUser.Id) && (mem.Password == CurrentUser.Password))
                    {
                        _userSingleton.SetPerson(mem);
                        LoginStatus = true;
                        _frame.ActivateFrameNavigation(typeof(UserMenu), mem);
                        MessageDialog msg = new MessageDialog($"Welcome {mem.Name}!");
                        await msg.ShowAsync();
                        break;
                    }
                    else if (("game" == CurrentUser.Id) && ("ofthrones" == CurrentUser.Password))
                    {
                        LoginStatus = true;
                        _frame.ActivateFrameNavigation(typeof(CalendarPage), mem);
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


        public LoginVm()
        {
            CheckCommand = new RelayCommand(Check);
            Col = new Collector();
            _userSingleton = SingletonMember.GetInstance();
        }
    }
}
