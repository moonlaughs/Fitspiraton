using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Fitspiraton.Model;
using Fitspiraton.Persistancy;
using Fitspiraton.View;
using Fitspiraton.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FitspirationUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //creating objects from classes
        private Member _member;
        private ObservableCollection<Member> MembersList;
        private Collector _collector;
        private LoginVm _loginVm;
        private SerializeUserVm _serializeUserVm;
        private readonly GetItem _getItem;
        private Booking _booking;
        private UserBookingView _userbookingVm;
        private ObservableCollection<Booking> Bookings { get; set; }

        //initialiling objects
        [TestInitialize]
        public void BeforeTest()
        {
            _collector = new Collector();
            _member = new Member("Jane", "jane", "pw", "../Assets/UP/sansa.jpg");
            _loginVm = new LoginVm();
            _serializeUserVm = new SerializeUserVm();
            _booking = new Booking("Jane", DateTimeOffset.Now, "fitness", "", "anna");
            _userbookingVm = new UserBookingView();
            Bookings = new ObservableCollection<Booking>();

            MembersList = new ObservableCollection<Member>();
        }

        //--------------------------------------------in SerializeUserVm class
        [TestMethod]
        public void AddMethodTest()
        {
            //testing adding new members method
            int beforeCount = MembersList.Count;
            int afterCount = 0;
            try
            {
                Member x = new Member("Ola", "ola", "p", "kk");
                MembersList.Add(x);
                afterCount = MembersList.Count;
                //_serializeUserVm.DoAddMember();
            }
            catch (Exception)
            {
                //Assert.AreEqual("Ola", _member.Name);
                //Assert.AreEqual("p", _member.Password);
                Assert.AreEqual(beforeCount, afterCount);
            }

            //cannot check because of luck of paramiters
        }

        [TestMethod]
        public void DeleteMethodTest()
        {
            //deleting member

            /*Member x = new Member("Ola", "ola", "p", "kk");
            MembersList.Add(x);
            _serializeUserVm.DoDeleteItem();
            Assert.AreEqual(null, x.Name);*/

            //cannot check because of luck of paramiters
        }
        /*
        [TestMethod]
        public void UpdateTest()
        {
            //updating test
            /*try
            {
                _member.Name = "Ola"; //??????????????????????
                _serializeUserVm.DoUpdateItem();
            }
            catch (Exception)
            {
                Assert.AreEqual("Ola", _member.Name);
                
            } */

        //cannot check because of luck of paramiters

        //-------------------------------------------in ManagerEventPageVm
        [TestMethod]
        public void DeleteUSerTest()
        {
            //cannot check because of luck of paramiters
        }

        [TestMethod]

        public void AddUserTest()
        {
            //cannot check because of luck of paramiters


        }

        [TestMethod]
        public void UpdateUserTest()
        {
            //cannot check because of luck of paramiters
        }

        //-----------------------------------------------in RecentBookingsVM
        [TestMethod]
        public void CheckExistingBookingTest()
        {
            //cannot check because of luck of paramiters
        }

        [TestMethod]
        public void DeleteBookingTest()
        {
            //cannot check because of luck of paramiters
        }

        //-----------------------------------------------in UserBookingVM
        [TestMethod]
        public void RegisterBookingTest()
        {
            /*try
            {
                Bookings.Add(_booking);
            }
            catch
            {
                Assert.AreEqual("anna", _booking.NameOfTeacher);
            }*/

            //cannot check because of luck of paramiters
        }
    } 


}
