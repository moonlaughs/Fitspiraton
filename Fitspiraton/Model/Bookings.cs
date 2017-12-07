using System;


namespace Fitspiraton.Model
{
    class Bookings
    {
        private string _membername;
        private DateTime _date;
        private string _type;

        public Bookings(string membername, DateTime date, string type)
        {
            _membername = membername;
            _date = date;
            _type = type;
        }

        public string Membername { get => _membername; set => _membername = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public string Type { get => _type; set => _type = value; }
    }
}
