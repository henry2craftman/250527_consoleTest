using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 회원정보 입력을 받아서, 객체로 만들기 -> 리스트에 객체를 저장하기
namespace _250527_consoleTest
{
    class ClassStudy2
    {
        public static List<Membership> membershipList; // 정의

        static void Main22()
        {
            //membershipList = new List<Membership>(); // 할당

            while(true)
            {
                RegisterMember();

                if (membershipList.Count > 2)
                    break;
            }
        }

        private static void RegisterMember()
        {
            Console.Write("1. 이름을 입력해 주세요: ");
            string name = Console.ReadLine();

            Console.Write("2. 나이를 입력해 주세요: ");
            int age = Int32.Parse(Console.ReadLine());

            Console.Write("3. id를 입력해 주세요: ");
            string id = Console.ReadLine();

            Console.Write("4. 주소를 입력해 주세요: ");
            string address = Console.ReadLine();

            Console.Write("5. 전화번호를 입력해 주세요: ");
            string phoneNumber = Console.ReadLine();

            Membership membership = new Membership(name, age, id, address, phoneNumber);

            membershipList.Add(membership);

            Console.WriteLine("멤버십 등록 완료");
        }
    }

    // Container로 사용되는 pure class(상속 X)
    public class Membership
    {
        public string name;
        public int age;
        public string id;
        public string address;
        public string phoneNumber;

        public Membership(string name, int age, string id, string address, string phoneNumber)
        {
            this.name = name;
            this.age = age;
            this.id = id;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }
    }
}
