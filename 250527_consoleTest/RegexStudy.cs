using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _250527_consoleTest
{
    class RegexStudy
    {
        static void Main45()
        {
            // 내가 작성한 문자와 정규표현식을 비교
            Regex regex = new Regex("C.*공부하는 중입니다.");
            Match match = regex.Match("C#공부하는 중입니다.");
            Console.WriteLine(match.Index + "번째에 C#이 명시되어 있음.");
            Console.WriteLine("값: " + match.Value);
            Console.WriteLine("길이: " + match.Length);

            string input = "There are 15 apples and 10 oranges.";
            Regex regex1 = new Regex(@"\b\d+\b"); // 단어와 단어 사이 숫자 매칭 확인
            MatchCollection matches = regex1.Matches(input);

            foreach(Match m in matches)
            {
                Console.WriteLine($"{m.Value}는 {m.Index}번재에 있습니다.");
            }

            // 유효한 이메일 주소 확인
            string inputEmail = "example@domain.com";
            Regex emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            bool isValid = emailRegex.IsMatch(inputEmail);
            Console.WriteLine(isValid == true ? "잘 입력하셨습니다." : "잘못 입력하셨습니다.");

            // 비밀번호 유효성 검사
            string inputPassword = "dD546456!!";
            Regex passwordRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            bool isPwValid = passwordRegex.IsMatch(inputPassword);
            Console.WriteLine(isPwValid == true ? "잘 입력하셨습니다." : "잘못 입력하셨습니다." +
                " 8글자 이상, 대문자 1개 이상, 소문자 1개 이상, 숫자 1개 이상, 특수문자 1개 이상 입력해 주세요.");
        }
    }
}
