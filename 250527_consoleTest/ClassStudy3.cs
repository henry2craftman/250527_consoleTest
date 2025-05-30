using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 2개의 입력을 받아 사용하는 사칙연산 계산기
// 클래스를 만들어 활용할 생각을 미리 해야함.
namespace _250527_consoleTest
{
    class ClassStudy3
    {
        static void Main12()
        {
            Calculator basicCal = new Calculator();

            string input = Console.ReadLine(); // 5+6, 99*1.6, 555555/3.5566

            char[] opers = { '+', '-', '*', '/' };

            string[] numberStr = input.Split(opers); // {"55", "632"}

            float number1, number2;
            if(float.TryParse(numberStr[0], out number1) && float.TryParse(numberStr[1], out number2))
            {
                foreach(char oper in input)
                {
                    float result;

                    if (oper == '+')
                    {
                        result = basicCal.Plus(number1, number2);
                        basicCal.Total = result;
                    }
                    else if(oper == '-')
                    {
                        result = basicCal.Minus(number1, number2);
                        basicCal.Total = result;
                    }
                    else if(oper == '*')
                    {
                        result = basicCal.Multiply(number1, number2);
                        basicCal.Total = result;
                    }
                    else if(oper == '/')
                    {
                        result = basicCal.Divide(number1, number2);
                        basicCal.Total = result;
                    }
                }

                basicCal.Print();
            }
            else
            {
                Console.WriteLine("잘못 입력하셨습니다. 다시 입력해 주세요.");
            }

            //float number1 = float.Parse(numberStr[0]);
            //float number2 = float.Parse(numberStr[1]);

        }
    }

    public class Calculator
    {
        public float total;
        public float Total { get; set; } // 숫자가 최종 저장되는 프로퍼티

        public void Print()
        {
            Console.WriteLine($"결과는 {Total} 입니다.");
        }

        public float Plus(float number1, float number2)
        {
            return number1 + number2;
        }

        public float Minus(float number1, float number2)
        {
            return number1 - number2;
        }

        public float Multiply(float number1, float number2)
        {
            return number1 * number2;
        }

        public float Divide(float number1, float number2)
        {
            return number1 / number2;
        }
    }
}
