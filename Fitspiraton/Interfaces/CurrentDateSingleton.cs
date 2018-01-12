using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitspiraton.Interfaces
{
    class CurrentDateSingleton
    {
        public static DateTimeOffset _currentDate;
        public static CurrentDateSingleton Instance { get; set; }

        private CurrentDateSingleton()
        {
            _currentDate = new DateTimeOffset();
        }

        public static CurrentDateSingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new CurrentDateSingleton();
            }
            return Instance;
        }

        public void SetCurrentDate(DateTimeOffset currentDate)
        {
            _currentDate = currentDate;
        }

        public DateTimeOffset GetCurrentDate()
        {
            return _currentDate;
        }

    }
}
