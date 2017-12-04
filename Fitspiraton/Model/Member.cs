using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitspiraton.Model
{
    public class Member : User
    {
        private int _bmiResult;

        public Member(string name, string id, string password, string photo , int bmiResult) : base(name, id, password, photo)
        {
            BmiResult = bmiResult;
        }

        public Member()
        {
            
        }

        public int BmiResult { get => _bmiResult; set => _bmiResult = value; }
    }
}
