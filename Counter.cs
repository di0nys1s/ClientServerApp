using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerApp
{
    public class Counter
    {
        private int _counter;
        Random r = new Random();
        
        
        public int counter
        {
            get {
                return _counter;
            }
            set
            {
                _counter = counter;
            }

            
        }

        public int counterNumber()
        {
            return r.Next(1,999999999);
        }
    }
}
