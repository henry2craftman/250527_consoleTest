using System;

public class Program
{
    public static void Main(string[] args)
    {
        byte data; // 8bit data
        int number = 5; // 정수형 4byte
        float speed = 5.66f; // 실수형 4byte
        double value = 456456456456.5f; // 실수형 8byte
        char input = 'a'; // 8bit
        string name = "taeuk shin"; // char(문자형)의 배열
        bool isActive = false; // or true
        int[] numbers = new int[4]; // 공간만 할당, 공간에는 0이 들어있음
        int[] numbers2 = { 1, 2, 5, 10 };
        int[] numbers3 = new int[5] { 5, 3, 5, 7, 6 };

        Console.WriteLine("Hello, World!");
        Console.WriteLine(numbers2[1]);
        numbers2[2] = 8;
        Console.WriteLine(numbers2[2]);
        Console.WriteLine(numbers2.Length); // 배열의 크기 프로퍼티
        Console.WriteLine(numbers2.Rank); // 배열의 차원 프로퍼티

        Console.WriteLine("---------------------");
        numbers2.CopyTo(numbers, 0); // numbers2의 정보를 numbers의 0번째 인덱스부터 붙여넣기
        for(int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }

        Console.WriteLine("---------------------");
        Array.Reverse(numbers); // 메소드의 오버로드: 같은이름 여러기능
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }

        // 2차원 배열
        int[,] matrix = new int[3, 3] 
        { 
            { 3, 2, 1 },
            { 2, 3, 4 },
            { 4, 5, 6 }
        };
        matrix[1, 2] = 10;

        // 3차원 배열
        int[,,] matrix2 = new int[3, 3, 3];

        // If 조건문
        if (matrix[1, 2] == 10)
        {
            matrix[1, 2] = 5;
        }

        if(isActive)
        {
            Console.WriteLine("활성화 되었습니다.");
        }
        else
        {
            Console.WriteLine("비활성화 되었습니다.");
        }

        if(number >= 0)
        {
            Console.WriteLine("0 이상입니다.");
        }
        else if(number > 5 && number < 10)
        {
            Console.WriteLine("5 초과, 10 미만입니다.");
        }
        else if(number > 20 && number < 30)
        {
            Console.WriteLine("20 초과, 30 미만입니다.");
        }
        else
        {
            Console.WriteLine("나머지 조건입니다.");
        }

        switch(number)
        {
            case 0:
                Console.WriteLine("0 입니다.");
                break;
            case 1:
                Console.WriteLine("1 입니다.");
                break;
            case 2:
                Console.WriteLine("2 입니다.");
                break;
            case 3:
                Console.WriteLine("3 입니다.");
                break;
            //default:
            //    Console.WriteLine("defualt 입니다.");
            //    break;
        }

        // 반복문 for
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine(i + "번 입니다.");
        }

        for(int i = 0; i < numbers3.Length; i++)
        {
            Console.WriteLine(numbers3[i] + "번");
        }

        string[] names = { "Alice", "Bob", "Chalie" };
        foreach(string n in names)
        {
            Console.WriteLine(n + "입니다.");
        }

        isActive = true;
        while(isActive)
        {
            Console.WriteLine("isActive");

            if (isActive)
                break;
        }

        int k = 0;
        while(k < 10)
        {
            Console.WriteLine("While: " + k + "번 입니다.");
            k++;
        }

        int j = 0;
        do
        {
            Console.WriteLine("Do-While: " + j + "번 입니다.");
            j++;
        } while (j < 10);

        // 실습1. 이름 리스트에서 내 이름찾기 -> 출력: "내 이름은 신태욱 입니다."
        string[] nameList = { "홍길동", "이순신", "임꺽정", "신태욱" };
        for(int i = 0; i < nameList.Length; i++)
        {
            if (nameList[i].Contains("신태욱"))
            {
                Console.WriteLine("내 이름은" + nameList[i] + "입니다.");
                break;
            }
        }
        float number5;
        bool isFloat = float.TryParse("3.4", out number5);


        // 실습2. 4x4 2차원 행렬 만들고, 행렬의 요소합 계산하기
        int[,] matrix3 = new int[4, 4];
        matrix2.GetLength(0); // 행렬의 첫번째 차원의 길이를 확인
        matrix2.GetLength(1);

        // Test
    }
}

