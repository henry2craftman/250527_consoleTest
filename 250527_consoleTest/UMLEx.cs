using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest4
{
    // 클래스 다이어그램
    class UMLEx
    {
        static void Main34()
        {
            Calcualtor calcualtor = new Calcualtor();
            calcualtor.Total = calcualtor.Power(2, 5);
            calcualtor.DisplayResult();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Address address { get; set; }

        public void Walk()
        {

        }

        public void Run()
        {

        }

        public void Speak()
        {

        }
    }

    class Student : Person
    {

    }

    class Professor : Person
    {

    }

    class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }

    public interface ICalculator
    {
        public double Add(double inputA, double inputB);
        public double Subtract(double inputA, double inputB);
        public double Multiply(double inputA, double inputB);
        public double Devide(double inputA, double inputB);
    }

    // 설명서의 역할
    public interface IEngineeringCalculator: ICalculator
    {
        public double Power(double baseNumber, double exponent);
        public double SqureRoot(double input);
        public double Sin(double angleRadian);
        public double Cos(double angleRadian);
    }

    // 실제 구현은 클래스에서
    public class Calcualtor : IEngineeringCalculator
    {
        public double Total { get; set; }

        public void DisplayResult()
        {
            Console.WriteLine(Total);
        }

        public double Add(double inputA, double inputB)
        {
            return inputA + inputB;
        }

        public double Subtract(double inputA, double inputB)
        {
            return inputA - inputB;
        }

        public double Multiply(double inputA, double inputB)
        {
            return inputA * inputB;
        }

        public double Devide(double inputA, double inputB)
        {
            return inputA / inputB;
        }

        public double Power(double baseNumber, double exponent)
        {
            return Math.Pow(baseNumber, exponent);
        }

        public double Sin(double angleRadian)
        {
            return Math.Sin(angleRadian);
        }
        public double Cos(double angleRadian)
        {
            return Math.Cos(angleRadian);
        }

        public double SqureRoot(double input)
        {
            return Math.Sqrt(input);
        }


    }
}
