using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest5
{
    class ObjectInitializer_AnonymousType
    {
        static void Main32()
        {
            // 객체 초기화자
            Person person = new Person() { Name = "신태욱" };
            Person person1 = new Person() { Age = "15" };
            
            
            // 익명형: 읽기 전용 프로퍼티만 가진다, 임시 데이터용
            Person person2 = new Person() { Name = "신태욱", Age = "15" };

            var person3 = new { Name = "신태욱", Age = 20 };
            var person4 = new[]
            {
                new { Name = "신태욱", Age = 20 },
                new { Name = "김하늘", Age = 20 }
            };
            
            foreach(var p in person4)
            {
                Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Age { get; set; }

        public Person()
        {

        }
    }
}
