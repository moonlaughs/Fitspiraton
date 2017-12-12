using System;


namespace Fitspiraton.Model
{
    class Booking
    {
        private string _membername;
        private DateTimeOffset _date;
        private string _type;

        public Booking(string membername, DateTimeOffset date, string type)
        {
            _membername = membername;
            _date = date;
            _type = type;
        }

        public Booking()
        {
            
        }
        public string Membername { get => _membername; set => _membername = value; }
        public DateTimeOffset Date { get => _date; set => _date = value; }
        public string Type { get => _type; set => _type = value; }
    }
}
