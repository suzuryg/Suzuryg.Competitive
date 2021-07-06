using Kzrnm.Competitive.IO;
using System.IO;
using System.Text;

namespace Suzuryg.Competitive.Answer
{
    static class HandMadeMain
    {
        static void Main(string[] args)
        {
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader(new FileStream("../../../input.txt", FileMode.Open, FileAccess.Read), Encoding.UTF8);
            new Program(reader, writer).Run();
        }
    }
}

