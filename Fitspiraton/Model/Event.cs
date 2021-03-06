﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitspiraton.Model
{
    public class Event
    {
        private DateTime _date;
        private string _type;
        private string _nameOfTeacher;
        private int _maxNumOfMembers;

        public DateTime Date { get => _date; set => _date = value; }
        public string Type { get => _type; set => _type = value; }
        public string NameOfTeacher { get => _nameOfTeacher; set => _nameOfTeacher = value; }
        public int MaxNumOfMembers { get => _maxNumOfMembers; set => _maxNumOfMembers = value; }

        public Event(DateTime date, string type, string nameOfTeacher, int maxNumOfMembers)
        {
            Date = date;
            Type = type;
            NameOfTeacher = nameOfTeacher;
            MaxNumOfMembers = maxNumOfMembers;
        }

        public Event()
        {
            
        }
    }
}
