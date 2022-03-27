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
            WrongAnswerTest();
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
            while (true)
            {
                // ABC245 D
                //int minN = 1;
                //int maxN = 100;
                //int minM = 1;
                //int maxM = 100;
                int minN = 3;
                int maxN = 3;
                int minM = 3;
                int maxM = 3;

                var rand = new Random();
                List<string> inputList = new List<string>();
                List<string> outputList = new List<string>();

                int n = rand.Next(minN, maxN + 1);
                inputList.Add($"{n}\n");
                int m = rand.Next(minM, maxM + 1);
                inputList.Add($"{m}\n");

                List<int> a = new List<int>();
                for (int i = 0; i <= n; i++)
                {
                    int aVal = rand.Next(-100, 100 + 1);
                    a.Add(aVal);
                }
                inputList.Add(string.Join(' ', a));
                inputList.Add("\n");

                List<int> b = new List<int>();
                for (int i = 0; i <= m; i++)
                {
                    int bVal = rand.Next(-100, 100 + 1);
                    b.Add(bVal);
                }
                outputList.Add(string.Join(' ', b));

                int[] c = new int[n + m + 1];
                for (int i = 0; i <= n; i++)
                {
                    for (int j = 0; j <= m; j++)
                    {
                        c[i + j] += a[i] * b[j];
                    }
                }
                inputList.Add(string.Join(' ', c));
                inputList.Add("\n");

                // cw.WriteLineで出力しているため、最後に改行が入る
                // WAになる場合は、ここをコメントアウトして試してみる
                outputList.Add("\n");

                // REが発生していたケースを探す
                int[,] coef = new int[n + m + 1, m + 1];

                for (int i = 0; i <= n; i++)
                {
                    for (int j = 0; j <= m; j++)
                    {
                        coef[i + j, j] += a[i];
                    }
                }

                for (int row = 0; row < n + m + 1; row++)
                {
                    if (row >= m + 1)
                    {
                        continue;
                    }

                    int div = coef[row, row];
                    if (div != 0)
                    {
                        for (int col = 0; col < m + 1; col++)
                        {
                            coef[row, col] /= div;
                        }
                        c[row] /= div;

                        for (int rowB = row + 1; rowB < n + m + 1; rowB++)
                        {
                            int mul = coef[rowB, row];
                            for (int col = 0; col < m + 1; col++)
                            {
                                coef[rowB, col] -= coef[row, col] * mul;
                            }
                            c[rowB] -= c[row] * mul;
                        }
                    }
                    else
                    {
                        return (string.Concat(inputList), string.Concat(outputList));
                    }
                }
            }
        }
    }
}

