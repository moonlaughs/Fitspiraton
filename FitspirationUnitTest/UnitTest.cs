﻿using System;
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
        private LoginVm _loginVm;
        private SerializeUserVm _serializeUserVm;

        //initialiling objects
        [TestInitialize]
        public void BeforeTest()
        {
            _member = new Member("Jane", "jane", "pw", "../Assets/UP/sansa.jpg");
            _loginVm = new LoginVm();
            _serializeUserVm = new SerializeUserVm();
        }

        //n collector class
        [TestMethod]
        public void ColectorTest()
        {
            //testing adding to the member list
            try
            {
                Assert.ThrowsException<ArgumentException>(() => _member.Name = "Jane");
            }
            catch (Exception)
            {
                Assert.AreEqual("Jane", _member.Name);
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
            catch (Exception)
            {
                Assert.AreEqual("Lucy", _member.Name);
                Assert.AreEqual("o", _member.Password);
            }
        }

        [TestMethod]
        public void LoadMembersTest()
        {
            //loading from json
            //??????????????????????????????
        }

        [TestMethod]
        public void DeleteMethodTest()
        {
            //deleting member
            //try
            //{
            //    _serializeUserVm.DoDeleteItem();
            //}
            //catch (Exception)
            //{
            //    Assert.AreEqual("Jane", _member.Name);
            //}
            Member x = new Member("Ola", "ola", "p", "kk");
            MembersList.Add(x);
            _serializeUserVm.DoDeleteItem();
            Assert.AreEqual(null, x.Name);
        }

        [TestMethod]
        public void UpdateTest()
        {
            //cannot test this method, it does not have any parameter
        }
    }
}