
namespace Fitspiraton.Model
{
    public class Member : User
    {
        private int _bmiResult;

        public Member(string name, string id, string password, string photo , int bmiResult) : base(name, id, password, photo)
        {
            BmiResult = bmiResult;
        }

        public Member(string name, string id, string password, string photo)
        {
            Name = name;
            Id = id;
            Password = password;
            Photo = photo;
        }

        public Member()
        {
            
        }

        public int BmiResult { get => _bmiResult; set => _bmiResult = value; }
    }
}
