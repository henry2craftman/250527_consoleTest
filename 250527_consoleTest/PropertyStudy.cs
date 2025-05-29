using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest
{
    class PropertyStudy
    {
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string AdminID { get; }

        static void Main343()
        {
            int[] array = new int[3];
            Console.WriteLine(array.Length); // Length는 프로퍼티
        }
    }
}
