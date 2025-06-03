using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest
{
    class IsAndas
    {
        static void Main52()
        {
            // is 연산자 예시
            object myObj = "Hello World!";

            if(myObj is string)
            {
                Console.WriteLine("문자열 타입입니다.");
            }

            if(myObj is string myString)
            {
                Console.WriteLine(myString.ToLower());
            }

            // as 연산자 예시
            object myObj2 = "Welcome to C#";
            string myString2 = myObj2 as string; 

            // 예외처리
            if(myString2 != null)
            {
                Console.WriteLine(myString2.ToUpper());
            }
        }

    }
}
