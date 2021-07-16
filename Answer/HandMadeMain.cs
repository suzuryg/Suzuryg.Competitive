using Kzrnm.Competitive.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Suzuryg.Competitive.Answer
{
    static class HandMadeMain
    {
        static void Main(string[] args)
        {
            TestWithInputTxt();
        }
        private static void TestWithInputTxt()
        {
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader(new FileStream("../../../input.txt", FileMode.Open, FileAccess.Read), Encoding.UTF8);
            new Program(reader, writer).Run();
        }
        private static void RuntimeErrorTest()
        {
            const int numCases = 100;

            var writer = new ConsoleWriter();
            for (int idxCase = 0; idxCase < numCases; idxCase++)
            {
                var input = GenerateInputForRutimeErrorTest();
                var reader = new ConsoleReader(new MemoryStream(new UTF8Encoding(false).GetBytes(input)), Encoding.UTF8);
                writer.WriteLine(input);
                new Program(reader, writer).Run();
            }
        }
        private static string GenerateInputForRutimeErrorTest()
        {
            // ABC206 C
            int minN = 2;
            int maxN = 10000;

            var rand = new Random();
            string input = "";

            int n = rand.Next(minN, maxN);
            input += $"{n}\n";

            for (int i = 0; i < n; i++)
            {
                int a = rand.Next(1, (int)Math.Pow(10, 9));
                input += $"{a} ";
            }

            return input;
        }
        private static void WrongAnswerTest()
        {
            const int numCases = 100;

            for (int idxCase = 0; idxCase < numCases; idxCase++)
            {
                (string input, string output) = GenerateInputForWrongAnswerTest();
                Console.WriteLine(input);

                var outStream = new MemoryStream();
                var writer = new ConsoleWriter(outStream, Encoding.UTF8);
                var reader = new ConsoleReader(new MemoryStream(new UTF8Encoding(false).GetBytes(input)), Encoding.UTF8);
                new Program(reader, writer).Run();

                string answer = Encoding.UTF8.GetString(outStream.ToArray());
                answer = answer.Replace("\r\n", "\n");

                if (answer.CompareTo(output) == 0)
                {
                    Console.WriteLine("AC");
                }
                else
                {
                    Console.WriteLine("WA");
                    break;
                }
            }
        }
        private static (string input, string output) GenerateInputForWrongAnswerTest()
        {
            // ABC206 C
            int minN = 2;
            int maxN = 10000;

            var rand = new Random();
            string input = "";
            string output = "";

            int n = rand.Next(minN, maxN);
            input += $"{n}\n";

            List<int> a = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int aVal = rand.Next(1, (int)Math.Pow(10, 9));
                a.Add(aVal);
                input += $"{aVal} ";
            }

            // 愚直解
            long ans = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (a[i] != a[j])
                    {
                        ans++;
                    }
                }
            }

            output += $"{ans}";
            // cw.WriteLineで出力しているため、最後に改行が入る
            output += "\n";

            return (input, output);
        }
    }
}

