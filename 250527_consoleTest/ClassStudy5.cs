using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 인터페이스(Interface): C++의 클래스 다중상속을 보완한 기능, C#에서는 Interface를 다중 상속 가능
namespace _250527_consoleTest3
{
    class ClassStudy5
    {

    }

    public class Animal : IMovable, ISpeakable
    {
        public string Type { get; set; }
        public int legCnt { get; set; }

        public Animal(string type, int legCnt)
        {
            this.Type = type;
            this.legCnt = legCnt;
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Speak()
        {
            throw new NotImplementedException();
        }
    }

    // 추상화: OOP의 4대 특징 중 하나
    public interface IMovable
    {
        // abstract 메소드와 같이 구현 필수 -> 재정의
        void Move(); // abstract 메서드랑 유사하게 이름만 정의, 구현은 상속한 클래스에
    }

    public interface ISpeakable
    {
        void Speak(); // C# 8.0 부터 인터페이스에서 직접 구현도 가능
    }

    // 스마트폰 기능
    // 전화걸기, 전화받기, 터치하기, 진동울리기, SNS, 문자하기
    // 알람, 시계 ....
    // 수 많은 기능들이 있을 때, 다른 버전의 스마트폰을 프로그램 할 경우
    // Interface(설명서)를 상속하여 간편하게 사용가능
}
