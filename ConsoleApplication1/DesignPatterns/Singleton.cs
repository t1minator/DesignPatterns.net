using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class SimpleSingleton
    {
        private static SimpleSingleton instance;
        private Random random = null;
        private SimpleSingleton()
        {
            random = new Random();
        }

        public static SimpleSingleton CreateInstance()
        {
            if (instance == null)
            {
                instance = new SimpleSingleton();
            }
            return instance;
        }

        public int getRandomNumber()
        {
         
            return random.Next(1, 300);
        }
    }
}
