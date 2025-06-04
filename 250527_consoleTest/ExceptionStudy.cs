using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest
{
    class ExceptionStudy
    {
        static void Main42()
        {
            int[] number = { 1, 2, 3, 4 };

            try
            {
                Console.WriteLine(number[5]);
            }
            //catch(Exception e)
            //{

            //}
            catch(ArgumentException e)
            {
                Console.WriteLine("ArgumentException");
                // throw; // 프로그램 종료 원할 시 사용
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("IndexOutOfRangeException");
            }
            finally
            {
                Console.WriteLine("Finally문 실행");
            }
        }
    }
}
