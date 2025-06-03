using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _250527_consoleTest
{
    /// <summary>
    /// 파일 스터디를 위한 클래스 입니다.
    /// </summary>
    class FileStudy
    {
        static void Main()
        {
            //ReadTextFile("file.txt");
            //WriteTextFile("file.txt");
            //AppendText("file.txt");
            //AppendText("file.txt");
            //ReadTextFileToEnd("file.txt");
            //ReadStringUsingFileClass("file2.txt");

            //DateTime dateTime = DateTime.Now;
            //Console.WriteLine(dateTime);

            // 실습1
            //ConsoleKeyInfo info;
            //while ((info = Console.ReadKey()).KeyChar != 'q')
            //{
            //    DateTime dateTime = DateTime.Now;

            //    using (FileStream fs = new FileStream("log.txt", FileMode.Append))
            //    {
            //        using (StreamWriter sw = new StreamWriter(fs))
            //        {
            //            sw.WriteLine($"{dateTime}: {info.KeyChar}");
            //        }
            //    }
            //}

            //WriteBinaryFile("data.dat");
            //ReadBinaryFile("data.dat");

            // 반복문에서 문자열을 저장할 때, 문자의 변경(복사)가 계속일어남
            // 오버로드
            // StringBuilder: 문자열을 효율적으로 빠르게 저장할 수 있는 클래스
            // 기존의 버퍼를 효율적으로 사용

            Stopwatch sw = new Stopwatch(); // 초시계기능

            sw.Start();
            // 일반 문자열 vs StringBuilder
            string dataStr = "";
            for(int i = 0; i < 100000; i++)
            {
                dataStr += i.ToString() + ","; // 매번 새로운 객체가 생성
            }
            sw.Stop();
            Console.WriteLine("string: " + sw.ElapsedMilliseconds + "ms");

            sw.Restart();
            StringBuilder sb = new StringBuilder();
            //sb.Capacity = 10000;

            for(int i = 0; i < 100000; i++)
            {
                sb.Append(i.ToString());
                sb.Append(",");
            }
            sw.Stop();
            Console.WriteLine("StringBuilder: " + sw.ElapsedMilliseconds + "ms");
        }

        /// <summary>
        /// 텍스트 파일을 읽는다.
        /// </summary>
        /// <param name="filePath">파일의 경로</param>
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

        private static void ReadBinaryFile(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            BinaryReader br = new BinaryReader(fs);

            byte[] buffer = new byte[100];
            int n = br.Read(buffer, 0, 100);

            Console.WriteLine(n);
            foreach(var character in buffer)
            {
                Console.WriteLine(character);
            }

            br.Close(); // 메모리 할당 해지
            fs.Close();
        }

        private static void WriteBinaryFile(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(fs);

            byte[] buffer = new byte[10] { 1, 0, 1, 0, 1, 0, 1, 0, 0, 1 };
            bw.Write(buffer, 0, 10);

            bw.Close();
            fs.Close();
        }

    }
}
