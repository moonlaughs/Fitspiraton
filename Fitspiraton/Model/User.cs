namespace Fitspiraton.Model
{
    public class User
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }

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
