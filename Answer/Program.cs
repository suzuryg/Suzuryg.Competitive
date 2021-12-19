// https://qiita.com/naminodarie/items/dce121a992cbdca69a78
using Kzrnm.Competitive.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

using Suzuryg.Competitive.Library.Collections;
using Suzuryg.Competitive.Library.Math;
using Suzuryg.Competitive.Library.Graph;
using Suzuryg.Competitive.Library.Search;

namespace Suzuryg.Competitive.Answer
{
    public partial class Program
    {
        static void Main() => new Program(new ConsoleReader(), new ConsoleWriter()).Run();
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public ConsoleReader cr;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] public ConsoleWriter cw;
        public Program(ConsoleReader r, ConsoleWriter w)
        {
            this.cr = r;
            this.cw = w;
            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        }
    }
    public partial class Program
    {
        public void Run()
        {
            SourceExpander.Expander.Expand();
            var res = Calc();
            if (res is double) cw.WriteLine(((double)res).ToString("0.####################", System.Globalization.CultureInfo.InvariantCulture));
            else if (res is bool) cw.WriteLine(((bool)res) ? "Yes" : "No");
            else if (res != null) cw.WriteLine(res.ToString());
            cw.Flush();
        }
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private object Calc()
        {
            int n = cr;

            return n;
        }
    }
}

