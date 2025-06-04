using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest
{
    class IsAndas
    {
        static void Main34()
        {
            // is 연산자 예시
            object myObj = "Hello World!";

            if(myObj is string)
            {
                Console.WriteLine("문자열 타입입니다.");
            }

            // 자료형 확인 및 초기화도 동시에 가능
            if(myObj is string myString)
            {
                Console.WriteLine(myString.ToLower()); // hello world
            }

            // as 연산자 예시
            object myObj2 = 123;
            string myString2 = myObj2 as string; // 타입캐스팅 기능 int -> string

            // 예외처리
            if(myString2 != null)
            {
                Console.WriteLine(myString2.ToUpper());
            }
        }

    }
}
