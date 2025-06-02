using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _250527_consoleTest;

namespace _250527_consoleTest
{
    class GenericStudy
    {
        static void Main23()
        {
            var stringList = new GenericList<string>(10);
            stringList.Add("Hello");
            var stringItem = stringList.Get(0);

            string inputA = "hello";
            string inputB = "world";
            bool isEqual = Utility.AreEqual<string>(inputA, inputB);

            System.Console.WriteLine("123");
        }
    }

    public class GenericList<T>
    {
        private T[] items;
        private int Count { get; set; }

        public GenericList(int capacity)
        {
            items = new T[capacity];
        }

        public void Add(T item)
        {
            if(Count < items.Length)
            {
                items[Count++] = item;
            }
        }

        public T Get(int index)
        {
            return items[index];
        }
    }

    public class Utility
    {
        public static bool AreEqual<T>(T value1, T value2)
        {
            return value1.Equals(value2);
        }
    }
}
