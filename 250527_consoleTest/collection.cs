// 자료구조: 자료를 저장하는 구조
namespace _250527_consoleTest
{
    // 컬렉션: 배열처럼 여러개의 데이터를 하나의 객체로 관리하는 기능
    // 장점
    // 1. 데이터 관리를 위해 간결한 코드작성이 가능
    // 2. 데이터 검색, 정렬을 효율적으로 수행 가능
    // 3. 다양한 데이터 유형을 저장 가능

    class collection
    {
        static int[] numberArray = new int[5] { 1, 2, 3, 4, 5 };
        static List<int> numberList = new List<int>() { 1, 2, 3, 4, 5 };

        static void Main32()
        {
            int[] numberArray = new int[5] { 1, 2, 3, 4, 5 };         // 고정형
            List<int> numberList = new List<int>() { 1, 2, 3, 4, 5 }; // 가변형
            // new 키워드를 사용하지 않으면 null을 반환

            // numberArray[6] = 10; // 배열은 정해진 인덱스만 접근 가능
            numberList.Add(6);
            numberList.Add(7);
            numberList.Add(8);

            numberList.Remove(6);   // 특정 정보를 지운다.
            numberList.RemoveAt(2); // 특정 인덱스의 정보를 지운다.
            numberList.Reverse();   // 정보를 역순으로 바꾼다.

            Console.WriteLine(numberList.Count); // 정보의 총 개수
            numberList.Clear();     // 리스트에 있는 정보 초기화
            
            foreach(int number in numberList)
            {
                Console.WriteLine(number);
            }

            // array는 int, float, double 기존의 자료형만 넣을 수 있음
            // 컬렉션은 클래스, 인터페이스, 구조체
            List<collection> collections = new List<collection>();
            // 여러 클래스를 여러개의 객체로 만들 수 있음.

            // Stack: LIFO(Last In First Out)
            // ex, 뒤로가기 기능
            // 노인과바다
            // 인간관계론
            // 마인드셋
            Stack<string> books = new Stack<string>();
            books.Push("마인드셋");     // 책을 쌓는다
            books.Push("인간관계론");
            books.Push("노인과바다");

            books.Pop();                // 책을 위에서 부터 제거한다.
            Console.WriteLine(books.Count + "개의 책이 존재합니다.");

            foreach(string book in books)
            {
                Console.WriteLine(book);
            }

            books.Clear(); // 저장된 책을 모두 제거

            // Queue: 첫번째 저장한 정보부터 꺼낸다. FIFO(First In First Out)
            // ex. 프린터 작업 대기줄, 다운로드 대기줄
            Queue<char> chars = new Queue<char>(); // 인스턴싱, 객체화

            // 줄서기
            chars.Enqueue('a');
            chars.Enqueue('b');
            chars.Enqueue('c');

            chars.Dequeue(); // 정보를 가장 먼저 들어온 순서대로 제거

            foreach(char c in chars)
            {
                Console.WriteLine(c);
            }

            // HashSet: 중복된 값은 무시하는 자료구조
            // 예시. 이메일 중복 방지, 태그관리
            HashSet<string> names = new HashSet<string>();
            names.Add("홍길동");
            names.Add("손흥민");
            names.Add("신태욱");
            names.Add("신태욱");
            Console.WriteLine("신태욱이 있나요?: " + names.Contains("신태욱"));

            foreach(var name in names)
            {
                Console.WriteLine(name);
            }

            // names 해시셋에 내 이름이 없다면 추가한다.
            // if(names.Contains("신태욱") == false)
            if(!names.Contains("신태욱")) // !는 true -> false, false -> true
            {
                names.Add("신태욱");
            }

            // Dictionary: 뜻(key)-의미(value)를 사용하여 데이터를 저장하는 자료구조
            Dictionary<string, string> englishDictionary = new Dictionary<string, string>();
            englishDictionary.Add("책", "book");
            englishDictionary.Add("사전", "dictionary");
            englishDictionary.Add("우유", "milk");

            // 방어코드
            if(!englishDictionary.ContainsKey("책"))
            {
                englishDictionary.Add("책", "book");
            }

            Console.WriteLine("사전의 의미는: " + englishDictionary["사전"]);
        }
    }
}
