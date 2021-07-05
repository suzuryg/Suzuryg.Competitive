﻿using Kzrnm.Competitive.IO;
using System.IO;
using System.Text;

namespace AtCoder.Answer
{
    static class HandMadeMain
    {
        static void Main(string[] args)
        {
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader(new MemoryStream(new UTF8Encoding(false).GetBytes(@"1 2
    3 4
    5 6
    ")), Encoding.UTF8);
            new Program(reader, writer).Run();
        }
    }
}

