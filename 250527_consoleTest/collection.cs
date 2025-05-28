using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest
{
    // 컬렉션: 배열처럼 여러개의 데이터를 하나의 객체로 관리하는 기능
    // 장점
    // 1. 데이터 관리를 위해 간결한 코드작성이 가능
    // 2. 데이터 검색, 정렬을 효율적으로 수행 가능
    // 3. 다양한 데이터 유형을 저장 가능

    class collection
    {
        static int[] numberArray = new int[5] { 1, 2, 3, 4, 5 };
        static List<int> numberList = new List<int>() { 1, 2, 3, 4, 5 };

        static void Main()
        {
            int[] numberArray = new int[5] { 1, 2, 3, 4, 5 };         // 고정형
            List<int> numberList = new List<int>() { 1, 2, 3, 4, 5 }; // 가변형

            // numberArray[6] = 10; // 배열은 정해진 인덱스만 접근 가능
            numberList.Add(6);
            numberList.Add(7);
            numberList.Add(8);

            // array는 int, float, double 기존의 자료형만 넣을 수 있음
            // 컬렉션은 클래스, 인터페이스, 구조체
            List<collection> collections = new List<collection>();
            // 여러 클래스를 여러개의 객체로 만들 수 있음.
        }
    }
}
