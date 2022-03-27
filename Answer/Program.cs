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
            int m = cr;
            int[] a = new int[n + 1];
            int[] c = new int[n + m + 1];
            for (int i = 0; i <= n; i++)
            {
                a[i] = cr;
            }
            for (int i = 0; i <= n + m; i++)
            {
                c[i] = cr;
            }

            int[,] coef = new int[n + m + 1, m + 1];

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    coef[i + j, j] += a[i];
                }
            }

            int offset = 0;
            for (int row = 0; row < n + m + 1; row++)
            {
                if (row - offset >= m + 1)
                {
                    break;
                }

                int div = coef[row, row - offset];
                if (div != 0)
                {
                    for (int col = 0; col < m + 1; col++)
                    {
                        coef[row, col] /= div;
                    }
                    c[row] /= div;

                    for (int rowB = row + 1; rowB < n + m + 1; rowB++)
                    {
                        int mul = coef[rowB, row - offset];
                        for (int col = 0; col < m + 1; col++)
                        {
                            coef[rowB, col] -= coef[row, col] * mul;
                        }
                        c[rowB] -= c[row] * mul;
                    }
                }
                else
                {
                    offset++;
                }
            }

            List<int> ans = new List<int>();
            for (int i = 0; i <= m; i++)
            {
                ans.Add(c[i + offset]);
            }
            return string.Join(' ', ans);
        }
    }
}

