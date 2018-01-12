using Fitspiraton.ViewModel;

namespace Fitspiraton.Model
{
    public class User :NotifyPropertyClass
    {
        private string _name;
        private string _id;
        private string _password;
        private string _photo;

        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public string Id { get { return _id; } set { _id = value; OnPropertyChanged(nameof(Id)); } }
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string Photo { get { return _photo; } set { _photo = value; OnPropertyChanged(nameof(Photo)); } }

        public User()
        {

        }

        public User(string name, string id, string password, string photo)
        {
            Name = name;
            Id = id;
            Password = password;
            Photo = photo;
        }

        public override string ToString()
        {
            return $"{Name}{Id}{Password}{Photo}";
        }
    }
}
