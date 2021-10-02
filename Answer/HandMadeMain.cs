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
        private static void RuntimeErrorTestWithoutOutput()
        {
            const int numCases = 1000;

            var writer = new ConsoleWriter(Stream.Null, Encoding.UTF8);
            for (int idxCase = 0; idxCase < numCases; idxCase++)
            {
                var input = GenerateInputForRutimeErrorTest();
                var reader = new ConsoleReader(new MemoryStream(new UTF8Encoding(false).GetBytes(input)), Encoding.UTF8);
                new Program(reader, writer).Run();
            }
        }
        private static string GenerateInputForRutimeErrorTest()
        {
            // ABC221 D
            int minN = 1;
            int maxN = 2 * 100000;

            var rand = new Random();
            List<string> inputList = new List<string>();

            int n = rand.Next(minN, maxN + 1);
            inputList.Add($"{n}\n");

            for (int i = 0; i < n; i++)
            {
                int a = rand.Next(1, (int)Math.Pow(10, 9) + 1);
                int b = rand.Next(1, (int)Math.Pow(10, 9) + 1);
                inputList.Add($"{a} {b}\n");
            }

            return string.Concat(inputList);
        }
        private static void WrongAnswerTest()
        {
            const int numCases = 100;

            for (int idxCase = 0; idxCase < numCases; idxCase++)
            {
                (string input, string output) = GenerateInputForWrongAnswerTest();

                var outStream = new MemoryStream();
                var writer = new ConsoleWriter(outStream, Encoding.UTF8);
                var reader = new ConsoleReader(new MemoryStream(new UTF8Encoding(false).GetBytes(input)), Encoding.UTF8);
                new Program(reader, writer).Run();

                string answer = Encoding.UTF8.GetString(outStream.ToArray());
                answer = answer.Replace("\r\n", "\n");

                if (answer.CompareTo(output) == 0)
                {
                }
                else
                {
                    Console.WriteLine("WA");
                    Console.WriteLine($"Input: {input}");
                    Console.WriteLine($"Correct: {output}");
                    Console.WriteLine($"Wrong: {answer}");
                    return;
                }
            }
            Console.WriteLine("AC");
        }
        private static (string input, string output) GenerateInputForWrongAnswerTest()
        {
            // ABC206 C
            int minN = 2;
            int maxN = 10000;

            var rand = new Random();
            List<string> inputList = new List<string>();
            List<string> outputList = new List<string>();

            int n = rand.Next(minN, maxN + 1);
            inputList.Add($"{n}\n");

            List<int> a = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int aVal = rand.Next(1, (int)Math.Pow(10, 9) + 1);
                a.Add(aVal);
                inputList.Add($"{aVal} ");
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

            outputList.Add($"{ans}");
            // cw.WriteLineで出力しているため、最後に改行が入る
            // WAになる場合は、ここをコメントアウトして試してみる
            outputList.Add("\n");

            return (string.Concat(inputList), string.Concat(outputList));
        }
    }
}

