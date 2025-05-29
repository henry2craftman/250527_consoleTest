using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest
{
    class ClassStudy1
    {
        static void Main12()
        {
            Person person1 = new Person(); // new 키워드의 의미: 실체화, 객체화, 인스턴싱
            //person1.name = "신태욱"; // name과 age를 public으로 정했을 경우 사용가능
            //person1.age = 20;
            person1.Greet();
            person1.Walk();
            person1.Run();

            bool isRight = person1.Greet("김현수", 25);
            Console.WriteLine(isRight == true ? "맞습니다. 정답!" : "땡ㅋ!"); // 삼항연산자: 조건문 ? true반환 : false반환

            // 정적메서드 사용
            float result = Util.Add(561, 5.6f);
            Console.WriteLine(result);
            // Array.Reverse();

            Person person2 = new Person(); // new 키워드의 의미: 실체화, 객체화, 인스턴싱
            //person2.name = "김하늘";
            //person2.age = 25;
            person2.Greet();
            person2.Walk();
            person2.Run();

            Person person3 = new Person("한수현", 50);
            Console.WriteLine(person3.Name); // get 프로퍼티의 사용
            person3.Name = "김택선";         // set 프로퍼티의 사용
            Console.WriteLine(person3.Id);

            Animal dog = new Animal("치와와", 4, "삼돌이");
            Animal cat = new Animal("코리안숏헤어", 4, "나비");
        }
    }

    // 캡슐화(Encapsulation)
    // 접근제한자(접근지정자): public, private, protected (적지 않으면 default는 private)
    // 기능: 접근제어 매커니즘을 추가로 사용가능 + 기능을 추가할 수 있음
    public class Person
    {
        private string name; // 클래스의 멤버변수
        public string Name // 겟-셋 프로퍼티
        {
            get { return name; }
            set { name = value; }
        }

        private string id;
        public string Id // 겟 프로퍼티만 사용: id를 확인할 수는 있으나, 변경할 수는 없음
        {
            get 
            {
                id += " 입니다.";

                Console.WriteLine(id);

                return id; 
            }
            // set { name = value; }
        }

        private int age;
        public int Age { get; }         // 나이는 확인만 가능
        public int Age1 { get; set; }   // 나이를 확인, 변경 가능

        // 생성자1: 아무기능없음
        public Person()
        {
            Console.WriteLine("태어났다!");
        }

        public Person(string _name, int _age)
        {
            name = _name;
            age = _age;

            Console.WriteLine("이름을 가지고 태어났다!");
        }

        // 메서드(클래스 안의 함수)
        public void Greet()
        {
            Console.WriteLine($"안녕하세요 저는 {name}이고, 나이는 {age}입니다.");
        }

        public void Walk()
        {
            Console.WriteLine("걷는 중 입니다.");
        }

        public void Run()
        {
            Console.WriteLine("달리는 중 입니다.");
        }

        // 다형성(polymorphism)
        // 메서드(함수)의 오버로드
        public bool Greet(string _name, int _age) // string _name, int _age: 매개변수, 인자, 파라미터
        {
            Console.WriteLine($"저는 {_name}이고, 나이는 {_age}");

            if(_name == name && _age == age)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    // 유용한 기능을 담은 클래스로 보통 사용됨
    public class Util
    {
        // 정적메소드: 인스턴싱(객체 생성) 하지 않고 사용할 수 있는 메서드
        // 보통 기능만을 정의할 때 사용
        public static float Add(float a, float b)
        {
            return a + b;
        }
    }

    public class Animal
    {
        private string type;
        private int legCnt;
        private string name;

        public Animal(string type, int legCnt, string name)
        {
            this.type = type;
            this.legCnt = legCnt;
            this.name = name;

            Console.WriteLine($"종은 {type}이고, 다리개수는 {legCnt}이고," +
                $"이름은 {name}입니다.");
        }

        public void Walk()
        {

        }

        public void Bark()
        {

        }
        public void Run()
        {

        }
    }
}
