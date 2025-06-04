using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest
{
    class StringStudy
    {
        static void Main()
        {
            string content = "Hello World";

            Console.WriteLine("문자열의 길이: " + content.Length);
            Console.WriteLine("문자열이 비어있는가?: " + content == string.Empty ? true : false);
            Console.WriteLine(content.ToLower());
            Console.WriteLine(content.ToUpper());
            Console.WriteLine("문자열에 World가 포함되어 있는가?: " +
                content.Contains("World"));
            
            content.Replace("Hello", "태욱"); // 문자열 변경
            Console.WriteLine(content);

            string[] newContent = content.Split(' '); // " " 기준으로 나눠서 배열에 담는다

            int order  = 3;
            int order1 = 6;
            int order2 = 9;

            Console.WriteLine("{0}, {1}, {2} 순서입니다.", order, order1, order2);
            Console.WriteLine($"{order}, {order1}, {order2} 순서입니다.");

            // 다양한 서식 지정자
            Console.WriteLine("서식지정자 C: {0, 6:C}", 1235467);
            Console.WriteLine("서식지정자 D: {0, 8:D}", 1235467);
            Console.WriteLine("서식지정자 E: {0, 6:E}", 1235467);
            Console.WriteLine("서식지정자 F: {0, 6:F3}", 1235467);
            Console.WriteLine("서식지정자 G: {0, 6:G}", 123.5467);
            Console.WriteLine("서식지정자 N: {0, 6:N}", 1235467);
            Console.WriteLine("서식지정자 P: {0, 6:P}", 1235467);
            Console.WriteLine("서식지정자 X: {0, 6:X}", 1235467);

            // 시간형식 서식 지정자
            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine(formattedDate);

            int numberA = 300;
            string numberAStr = numberA.ToString();
            string formattedString = String.Format("{0}", numberA);

            string name = "JOHN";
            string newStr = String.Format("{0} has {1} apples.", name, numberA);

            string info = @"안녕하세요. 반갑습니다.
저는 신태욱입니다.
오늘은 6월 4일 입니다.
감사합니다.";
            Console.WriteLine(info);
        }
    }
}
