using Kzrnm.Competitive.IO;
using System;
using System.IO;
using System.Text;

namespace Suzuryg.Competitive.Answer
{
    static class HandMadeMain
    {
        static void Main(string[] args)
        {
            RuntimeErrorTest();
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
    }
}

