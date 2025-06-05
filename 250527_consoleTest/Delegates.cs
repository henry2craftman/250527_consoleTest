using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest
{
    // 대리자: 대신해서 특정 함수를 실행시켜주는 역할
    class Delegates
    {
        enum Color
        {
            Red,
            Green,
            Blue
        }
        Color color = new Color();

        // 1. 대리자 템플릿, 반환형이 없고,
        // 인자가 있는 함수를 대리자로 지정할 수 있다.
        delegate void DelegateTemplate(int num);

        // 2. 대리자 정의: 템플릿의 사용
        static DelegateTemplate myDelegate;

        // 3. 리턴값이 있는 대리자 템플릿
        delegate string MyDele<T1, T2>(T1 a, T2 b); // 제네릭
        static MyDele<int, string> myDele;

        // 예, 스마트폰에 알람설정
        // 시간설정, 알람기간, 알람음, ...
        // 확인 버튼을 누르면, 모든것이 한번에 설정 가능하도록 함

        // 예2. 전사 레벨에 따라 여러 기술 사용가능
        // 일반공격 + 포이즌
        // 델리게이트 실행 시, 일반기능 + 추가기능 사용이 됨

        // 예3. MES의 현재상태 확인버튼
        // CheckLine1, CheckLine2, CheckLine3, CheckLine4
        // 대리자에게 CheckLine1, CheckLine2, CheckLine3, CheckLine4를 실행하라.
        // 모든 상태를 한번에 확인 가능
        static void Main23()
        {
            myDelegate = PrintNum; // 대리자에게 PrintNum을 등록
            myDelegate(3);

            myDelegate = DoubleNum; // DoubleNum 기능을 등록해
            myDelegate(10);

            myDelegate += PrintNum; // 한가지 기능을 추가 등록
            myDelegate(50);

            // 델리게이트 체인, 체이닝, 멀티캐스팅
            if(myDele != null)
            {
                myDele += RegisterMembership;
                myDele += SetMembership; // 기능 추가
                myDele -= SetMembership; // 기능 제거
                string content = myDele(20, "신태욱");
                Console.WriteLine(content);
            }
        }

        static void PrintNum(int num)
        {
            Console.WriteLine("출력1: " + num);
        }

        static void DoubleNum(int num)
        {
            Console.WriteLine("출력2: " + num);
        }

        static string RegisterMembership(int age, string name)
        {
            return $"나이 {age}의 {name}가 등록되었습니다.";
        }

        static string SetMembership(int count, string workoutName)
        {
            return $"{workoutName}이 {count}회로 설정되었습니다.";
        }
    }
}
