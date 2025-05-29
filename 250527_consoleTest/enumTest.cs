using System;

namespace _250527_consoleTest
{
    // 접근한정자(public, private, protected)
    // enum: 열거형 타입
    // Weekday: 열거형 이름
    public enum Weekday
    {
        Sunday,
        Monday,
        Tuesday = 5,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public enum Color
    {
        Red = 0xff0000,
        Green = 0x00ff00,
        Blue = 0x0000ff
    }

    public enum State
    {
        작동,
        정지,
        긴급,
        오류
    }

    class enumTest
    {
        public int number = 0; // public 전역함수
        public static void Main32()
        {
            // 250528
            // 열거형
            Weekday weekday = Weekday.Monday;

            switch(weekday)
            {
                case Weekday.Monday:
                    Console.WriteLine("Monday");
                    break;
                case Weekday.Tuesday:

                    break;
                case Weekday.Wednesday:

                    break;
                case Weekday.Thursday:

                    break;
                case Weekday.Friday:

                    break;
                case Weekday.Saturday:

                    break;
                case Weekday.Sunday:

                    break;
            }

            State state = State.정지;
            state = State.작동;
        }
    }
}
