using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest
{
    // 이벤트: 게시와 구독자로 나뉘어, 다른 클래스에게 신호를 전달한다, 관찰자 패턴
    // 디자인패턴: 소프트웨어 설계 방법론 중 하나,
    // (관찰자 패턴, 싱글턴 패턴, 컴포넌트 패턴, 빌더패턴)
    // 특징: 선언한 클래스에서만 사용 가능.
    class EventStudy
    {
        // 템플릿은 델리게이트로 정의
        delegate void ClickEvent();

        // 이벤트 정의
        static event ClickEvent onClicked;

        static void Main532()
        {
            onClicked += PrintEmmergencyAlarm;

            while (true)
            {
                if(Console.ReadKey().KeyChar == 'q')
                {
                    if (onClicked != null)
                    {
                        onClicked();

                        break;
                    }
                }
            }

            // Publisher & Subscriber 구조
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber();

            publisher.EventRaised += subscriber.OnEventRaised;

            publisher.RaiseEvent();
        }

        static void PrintEmmergencyAlarm()
        {
            Console.WriteLine("위험합니다. 대피해주세요!");
        }

        // Publisher & Subscriber 구조
        // 템플릿 작성
        public delegate void EventHandler(string message);
        
        public class Publisher
        {
            public event EventHandler EventRaised;

            public void RaiseEvent()
            {
                //Console.WriteLine("이벤트 발생");
                EventRaised.Invoke("이벤트 발생"); // Publisher -> Subscriber
            }
        }
        public class Subscriber
        {
            public void OnEventRaised(string message)
            {
                Console.WriteLine(message);
            }
        }
        
    }
}
