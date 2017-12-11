
using System;
using System.Collections.ObjectModel;
using Fitspiraton.Model;
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

        //initialiling objects
        [TestInitialize]
        public void BeforeTest()
        {
            _collector = new Collector();
            _member = new Member("Jane", "jane", "pw", "../Assets/UP/sansa.jpg");
            _loginVm = new LoginVm();
            _serializeUserVm = new SerializeUserVm();
        }

        //n collector class
        [TestMethod]
        public void ColectorTest()
        {
            //testing adding to the colector list
            try
            {
                Assert.ThrowsException<ArgumentException>(() => _collector.Name = _member.Name);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Jane", _collector.Name);
            }
        }

        //in loginVm class
        [TestMethod]
        public void CheckMethodTest()
        {
            //Login method

        }

        [TestMethod]
        public void LoadMembersLoginTest()
        {
            //loading from json
        }

        //in SerializeUserVm class
        [TestMethod]
        public void AddMethodTest()
        {
            //testing adding new members method
            try
            {
                _serializeUserVm.DoAddMember();
            }
            catch (Exception )
            {
                Assert.AreEqual("Jane", _member.Name);
                Assert.AreEqual("pw", _member.Password);
            }
        }

        [TestMethod]
        public void LoadMembersTest()
        {
            //loading from json
        }

        [TestMethod]
        public void DeleteMethodTest()
        {
            //deleting member
        }

        [TestMethod]
        public void UpdateTest()
        {
            //updating test
        }
    }
}
