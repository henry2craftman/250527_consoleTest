using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _250527_consoleTest; // 네임스페이스의 사용

namespace _250527_consoleTest2 // 네임스페이스를 새로 정의
{
    class ClassStudy4
    {
        static void Main()
        {
            //Car car1 = new Car();
            //car1.Brand = "Hyundai";
            //car1.Model = "IONIC";
            //car1.Honk();
            //car1.Accelerate();

            Marine marine1 = new Marine();
            Zergling zergling1 = new Zergling();

            Console.WriteLine("----------전투 시작-----------");
            marine1.Move("적진 앞");
            marine1.Attack(zergling1);
            marine1.UseSpecialAbility();

            zergling1.Move("마린 앞");
            zergling1.Attack(marine1);
            zergling1.UseSpecialAbility();
        }
    }

    // 탈것
    public class Vehicle
    {
        public string Brand { get; set; }

        public void Honk()
        {
            Console.WriteLine("경적을 울림!");
        }
    }

    // 자동차 클래스: 부모(베이스)클래스의 기능을 상속받음
    public class Car : Vehicle
    {
        public string Model { get; set; }

        public Car(string brand, string model)
        {
            base.Brand = brand; // base는 Vehicle class
            this.Model = model; // this는 Car class
        }

        public void Accelerate()
        {
            Console.WriteLine("Accelerating...");
        }
    }

    public class 산업용로봇
    {
        public string 모델명 { get; set; }
        public string 제조사 { get; set; }
        public bool 전원 { get; set; }

        public 산업용로봇(string 모델명, string 제조사, bool 전원)
        {
            this.모델명 = 모델명;
            this.제조사 = 제조사;
            this.전원 = 전원;
        }

        public string 전원켜기()
        {
            this.전원 = true;
            return $"{this.모델명} 로봇의 전원을 켰습니다.";
        }

        // 추상화 virtual 함수
        public virtual string 작업수행()
        {
            return "기본 작업을 수행합니다.";
        }
    }

    public class 용접로봇 : 산업용로봇
    {
        public string 용접유형 { get; set; }
        public 용접로봇(string 모델명, string 제조사, bool 전원) : base(모델명, 제조사, 전원)
        {

        }

        // 부모 클래스의 virtual + 자식 클래스의 override
        // 베이스 클래스의 virtual 메소드의 기능에 추가 기능을 넣을 수 있음
        public override string 작업수행()
        {

            return base.작업수행() + "용접로봇의 작업수행";
        }
    }

    // 스타크래프트 버전으로 클래스 만들기
    public class StarcraftUnit
    {
        public string UnitName { get; set; }
        public int Hp { get; set; }
        public int AttackDamage { get; set; }

        // 유닛 초기화를 위한 베이스 생성자
        public StarcraftUnit(string unitName, int hp, int attackDamage)
        {
            UnitName = unitName;
            Hp = hp;
            AttackDamage = attackDamage;

            Console.WriteLine($"{UnitName} HP: {Hp}, 공격력: {AttackDamage} 유닛 생성 완료");
        }

        // 모든 유닛이 공통적으로 수행가능한 이동메서드(변경 불가함)
        public void Move(string location)
        {
            Console.WriteLine($"{UnitName}이 {location}으로 이동합니다.");
        }

        public virtual void Attack(StarcraftUnit target)
        {
            Console.WriteLine($"{UnitName}이 {target.UnitName}을 공격! (데미지 {AttackDamage})");
        }

        public virtual void UseSpecialAbility()
        {
            Console.WriteLine($"{UnitName}: 특수 능력이 없음.");
        }
    }

    public abstract class StarcraftUnit2
    {
        public string UnitName { get; set; }
        public int Hp { get; set; }
        public int AttackDamage { get; set; }

        // 유닛 초기화를 위한 베이스 생성자
        public StarcraftUnit2(string unitName, int hp, int attackDamage)
        {
            UnitName = unitName;
            Hp = hp;
            AttackDamage = attackDamage;

            Console.WriteLine($"{UnitName} HP: {Hp}, 공격력: {AttackDamage} 유닛 생성 완료");
        }

        // 모든 유닛이 공통적으로 수행가능한 이동메서드(변경 불가함)
        public void Move(string location)
        {
            Console.WriteLine($"{UnitName}이 {location}으로 이동합니다.");
        }

        public virtual void Attack(StarcraftUnit target)
        {
            Console.WriteLine($"{UnitName}이 {target.UnitName}을 공격! (데미지 {AttackDamage})");
        }

        public virtual void UseSpecialAbility()
        {
            Console.WriteLine($"{UnitName}: 특수 능력이 없음.");
        }

        public abstract void MakeSound();
    }

    public class Marine : StarcraftUnit
    {
        public Marine() : base("마린", 40, 6) // 부모(base)클래스의 생성자를 이용
        {
            Console.WriteLine("마린 준비 완료! Ready to go Sir!");
        }

        // 재정의: base 클래스의 기능을 재정의
        public override void UseSpecialAbility()
        {
            Console.WriteLine($"{UnitName} 스팀팩 사용 (HP: {--Hp}, 공격력: {++AttackDamage})");
        }
    }

    public class Zergling : StarcraftUnit
    {
        public Zergling() : base("저글링", 35, 5) // 부모(base)클래스의 생성자를 이용
        {
            Console.WriteLine("저글링 생성!");
        }
    }

    public class Probe : StarcraftUnit2
    {
        public Probe(string unitName, int hp, int attackDamage) : base(unitName, hp, attackDamage)
        {
        }

        // 무조건 부모클래스의 추상메서드를 재정의 해야함.
        public override void MakeSound()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Animal
    {
        public abstract void Move(); // 구현이 없음
    }

    public class Dog : Animal
    {
        public override void Move()
        {
            Console.WriteLine("Dog 움직이는 중...");
        }
    }
}
