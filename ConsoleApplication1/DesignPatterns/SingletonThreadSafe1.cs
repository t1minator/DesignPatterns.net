using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ThreadSafeSingleton
    {
        private static readonly object mutex = new object();
        private static ThreadSafeSingleton instance;
        private Random random = null;
        private ThreadSafeSingleton()
        {
            random = new Random();
        }

        public static ThreadSafeSingleton CreateInstance()
        {
            if (instance == null)
            {
                lock (mutex)
                {
                    if (instance == null)
                    {
                        instance = new ThreadSafeSingleton();
                    }
                }
            }
            return instance;
        }

        public int getRandomNumber()
        {
         
            return random.Next(1, 300);
        }
    }
}
