using Kzrnm.Competitive.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Suzuryg.Competitive.Library;

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
            List<string> inputList = new List<string>();

            while (inputList.Count == 0)
            {
                try
                {
                    // ABC243 D
                    var rand = new Library.MyMath.Random();
                    int n = rand.Next(1, int.Parse("1" + new string('0', 6)) + 1);
                    long x = rand.Next(1, long.Parse("1" + new string('0', 18)) + 1);
                    List<char> s = new List<char>();
                    long ans = x;
                    for (int i = 0; i < n; i++)
                    {
                        int temp = rand.Next(0, 2 + 1);
                        if (temp % 3 == 0)
                        {
                            if (ans >= 2)
                            {
                                ans /= 2;
                                s.Add('U');
                            }
                            else
                            {
                                int temp2 = rand.Next(0, 1 + 1);
                                if (temp2 % 2 == 0)
                                {
                                    ans *= 2;
                                    s.Add('L');
                                }
                                else
                                {
                                    ans = ans * 2 + 1;
                                    s.Add('R');
                                }
                            }
                        }
                        else if (temp % 3 == 1)
                        {
                            if (ans <= long.MaxValue / 2)
                            {
                                ans *= 2;
                                s.Add('L');
                            }
                            else
                            {
                                ans /= 2;
                                s.Add('U');
                            }
                        }
                        else
                        {
                            if (ans <= (long.MaxValue - 1) / 2)
                            {
                                ans = ans * 2 + 1;
                                s.Add('R');
                            }
                            else
                            {
                                ans /= 2;
                                s.Add('U');
                            }
                        }
                    }

                    inputList.Add($"{n}\n");
                    inputList.Add($"{x}\n");
                    inputList.Add($"{string.Concat(s)}\n");
                }
                catch (Exception _)
                {
                    inputList.Clear();
                }
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
                    Console.WriteLine($"[Input]\n{input}");
                    Console.WriteLine($"[Correct]\n{output}");
                    Console.WriteLine($"[Wrong]\n{answer}");
                    return;
                }
            }
            Console.WriteLine("AC");
        }
        private static (string input, string output) GenerateInputForWrongAnswerTest()
        {
            List<string> inputList = new List<string>();
            List<string> outputList = new List<string>();

            while (inputList.Count == 0 || outputList.Count == 0)
            {
                try
                {
                    // ABC243 D
                    var rand = new Library.MyMath.Random();
                    int n = rand.Next(1, int.Parse("1" + new string('0', 6)) + 1);
                    long x = rand.Next(1, long.Parse("1" + new string('0', 18)) + 1);
                    List<char> s = new List<char>();
                    long ans = x;
                    for (int i = 0; i < n; i++)
                    {
                        int temp = rand.Next(0, 2 + 1);
                        if (temp % 3 == 0)
                        {
                            if (ans >= 2)
                            {
                                ans /= 2;
                                s.Add('U');
                            }
                            else
                            {
                                int temp2 = rand.Next(0, 1 + 1);
                                if (temp2 % 2 == 0)
                                {
                                    ans *= 2;
                                    s.Add('L');
                                }
                                else
                                {
                                    ans = ans * 2 + 1;
                                    s.Add('R');
                                }
                            }
                        }
                        else if (temp % 3 == 1)
                        {
                            if (ans <= long.MaxValue / 2)
                            {
                                ans *= 2;
                                s.Add('L');
                            }
                            else
                            {
                                ans /= 2;
                                s.Add('U');
                            }
                        }
                        else
                        {
                            if (ans <= (long.MaxValue - 1) / 2)
                            {
                                ans = ans * 2 + 1;
                                s.Add('R');
                            }
                            else
                            {
                                ans /= 2;
                                s.Add('U');
                            }
                        }
                    }

                    inputList.Add($"{n}\n");
                    inputList.Add($"{x}\n");
                    inputList.Add($"{string.Concat(s)}\n");

                    outputList.Add($"{ans}");
                    // cw.WriteLineで出力しているため、最後に改行が入る
                    // WAになる場合は、ここをコメントアウトして試してみる
                    outputList.Add("\n");
                }
                catch (Exception _)
                {
                    inputList.Clear();
                    outputList.Clear();
                }
            }

            return (string.Concat(inputList), string.Concat(outputList));
        }
    }
}

