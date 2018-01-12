using System;


namespace Fitspiraton.Model
{
    public class Booking
    {
        private string _membername;
        private DateTimeOffset _date;
        private string _type;
        private string _imgSource;
        private string _nameOfTeacher;


        public Booking(string membername, DateTimeOffset date, string type, string imgSource, string nameOfTeacher)
        {
            _membername = membername;
            _date = date;
            _type = type;
            _imgSource = imgSource;
            _nameOfTeacher = nameOfTeacher;
        }

        public Booking()
        {

        }

        public string Membername { get => _membername; set => _membername = value; }
        public DateTimeOffset Date { get => _date; set => _date = value; }
        public string Type { get => _type; set => _type = value; }
        public string ImgSource { get => _imgSource; set => _imgSource = value; }
        public string NameOfTeacher { get => _nameOfTeacher; set => _nameOfTeacher = value; }
    }
}
