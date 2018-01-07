using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class NotSingleton
    {
        private Random random = null;
        public NotSingleton()
        {
            random = new Random();
        }

        public int getRandomNumber()
        {
            return random.Next(1, 300); 
        }
    }
}
