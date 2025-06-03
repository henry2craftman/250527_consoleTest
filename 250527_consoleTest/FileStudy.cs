using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest
{
    class FileStudy
    {
        static void Main()
        {
            ReadTextFile("file.txt");
            WriteTextFile("file.txt");
            AppendText("file.txt");
            AppendText("file.txt");
            ReadTextFileToEnd("file.txt");

            ReadStringUsingFileClass("file2.txt");
        }

        private static void ReadTextFile(string filePath)
        {
            // 보안프로그램 log, CCTV log, 실시간 서버 log, setting 정보 불러올때
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string content = sr.ReadLine();
            Console.WriteLine($"읽기 완료: {content}");

            sr.Dispose(); // 메모리 할당 해지
            fs.Dispose();
        }

        private static void ReadTextFileToEnd(string filePath)
        {
            // 보안프로그램 log, CCTV log, 실시간 서버 log, setting 정보 불러올때
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string content = sr.ReadToEnd();
            Console.WriteLine($"읽기 완료: {content}");

            sr.Dispose(); // 메모리 할당 해지
            fs.Dispose();
        }

        private static void WriteTextFile(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Welcome!");
            Console.WriteLine("쓰기 완료");

            sw.Dispose(); 
            fs.Dispose();
        }

        private static void AppendText(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Welcome!");
            Console.WriteLine("쓰기 완료");

            sw.Dispose();
            fs.Dispose();
        }

        // 간단한 파일 작업 가능, Dispose 필요없음.
        private static void ReadStringUsingFileClass(string filePath)
        {
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine(content);
            }
            else
            {
                // 파일을 만들거나 열고, 이미 있다면 덮어쓴다.
                StreamWriter sw = File.CreateText(filePath);
                sw.WriteLine("하하하");
                sw.Dispose();

                // using 키워드 2: 자동 메모리 해지 기능
                using(StreamWriter sw2 = File.CreateText(filePath))
                {
                    sw2.WriteLine("하하하");
                }
            }

        }
    }
}
