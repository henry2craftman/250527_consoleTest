using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest
{
    class typeCasting
    {
        // 전역변수(global variable)
        int value = 5; // class 안의 변수는 private이 defualt
        const float pi = 3.141592f; // 읽기전용

        // 암시적 형변환
        // char -> int -> long -> float -> double

        public static void Main55()
        {
            // pi = 423.4f; // 상수이기 때문에 바꿀 수 없음

            // 지역변수(local variable)
            int a = 5;    // 정수형 변수
            double b = 413.6; // 실수형 변수
            float number = 3.14f;

            // 1. 암시적 형변환
            double c = a; // 변수의 크기에 따라 큰 변수 <- 작은 변수

            // 2. 명시적 형변환
            int d = (int)b; // double -> int 413
            int e = (int)number;
            int f = Convert.ToInt32(b);
            int g = Int32.Parse("530"); // 문자의 경우 Parse, TryParse
            // 여러가지 내장 메소드: Convert.ToBoolean, ToDouble, ToString
        }
    }
}
