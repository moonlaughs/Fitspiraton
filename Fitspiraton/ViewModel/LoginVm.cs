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

        public Collector col { get; set; }

        public RelayCommand CheckCommand { get; set; }
        
        private readonly FrameNavigateClass _frame = new FrameNavigateClass();

        public async void Check()
        {
            LoginStatus = false;
            if (col.Persons != null)
            {
                foreach (var member in col.Persons)
                {
                    if ((member.Id == CurrentUser.Id) && (member.Password == CurrentUser.Password))
                    {
                        LoginStatus = true;
                        _frame.ActivateFrameNavigation(typeof(ManagerUsersPage));                  //page needs to be change in the future
                        MessageDialog msg = new MessageDialog($"Welcome {member.Name}!");
                        await msg.ShowAsync();
                        break;
                    }
                    else if (("game" == CurrentUser.Id) && ("ofthrones" == CurrentUser.Password))
                    {
                        LoginStatus = true;
                        _frame.ActivateFrameNavigation(typeof(ManagerUsersPage));                  //page needs to be change in the future
                        MessageDialog msg = new MessageDialog("Welcome George R.R. Martin");
                        await msg.ShowAsync();
                        break;
                    }
                    else if (LoginStatus != false) 
                    {
                        MessageDialog msg = new MessageDialog("Sorry wrong input.");
                        await msg.ShowAsync();
                        break;
                    }
                }
            }
        }

        public LoginVm()
        {
            CheckCommand = new RelayCommand(Check);
            col = new Collector();
        }

    }
}
