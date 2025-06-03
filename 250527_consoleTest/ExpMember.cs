using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest
{
    class ExpMember
    {
        public string Name { get; } = "신태욱";
        public string Message => $"Hello, {Name}"; // 식형식 멤버를 사용한 프로퍼티
        //public string this[int index] => $"Index: {index}";

        public int Add(int a, int b)
        {
            return a + b;
        }

        // 식형식 멤버
        public int Subtract(int a, int b) => a - b;

        public ExpMember(string name) => Name = name;
    }
}
