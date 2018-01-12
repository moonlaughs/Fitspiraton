using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Fitspiraton.Interfaces;
using Fitspiraton.Model;
using Fitspiraton.Persistancy;
using Fitspiraton.ViewModel;
using Microsoft.Toolkit.Uwp;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Fitspiraton.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ManagerUsersPage : Page
    {
        private SerializeUserVm ser;


        private SingletonMember _userSingleton;

        private GetItem getMembers;

        private ObservableCollection<Member> _membersCatalog;

        public ObservableCollection<Member> MemberCatalog
        {
            get { return _membersCatalog; }
            set {_membersCatalog = value;}
        }

        public async Task LoadMembers()
        {
            try
            {
               await getMembers.LoadFromJson();
                MemberCatalog = getMembers.ItemsCatalog;
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
        }

        public ManagerUsersPage()
        {
            this.InitializeComponent();

            LoadMembers();
            getMembers = new GetItem();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ser = new SerializeUserVm();
            _userSingleton = SingletonMember.GetInstance();
            Frame.Navigate(typeof(MainPage), LoadMembers());
        }
    }
}
