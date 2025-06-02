using _250527_consoleTest2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest
{
    class valueReferenceType
    {
        // 구조체
        public struct Point
        {
            public int x { get; set; }
            public int y { get; set; }

            public Point()
            {

            }

            public Point(int _x, int _y)
            {
                x = _x;
                y = _y;
            }

            public void Translate(int dx, int dy)
            {
                x += dx;
                y += dy;
            }
        }

        static void Main()
        {
            // Value Type으로 Stack에 저장
            int a = 10;
            int b = 20;

            Console.WriteLine(a + b); // Call by Value

            // Reference Type: 동적할당, 주소(포인터)는 Stack에 저장, 실제 값은 Heap
            StarcraftUnit unit = new StarcraftUnit("Marine", 5, 6);
            StarcraftUnit unit2 = unit; // 참조에 의한 복사: 주소가 복사됨

            Console.WriteLine(unit2.Hp); // Call by reference
            unit2.Hp = 10;
            Console.WriteLine(unit.Hp);
            // 참조형의 값을 바꾸고자 할 때, 다른 참조가 있는지 주의해야함
            // 반복문 안에서 new 키워드를 사용할 경우 메모리 오버헤드 발생(자료구조 사용시 주의)
            // 가비지 컬렉션: 동적할당된 참조형 변수는 자동으로 메모리가 해지됨


            // AVR, AMR의 이동 위치를 저장하는 변수 형태로 사용, 마우스 포인터의 이동경로, 물체의 이동경로, 특정 부분의 위치
            Point p1 = new Point(3, 4);
            p1.Translate(1, 2);
            List<Point> points = new List<Point>(); // 로봇의 위치를 미리 정의
            Vector3 location = new Vector3(10, 30, 50); // 3차원 공간의 좌표
        }
    }
}
