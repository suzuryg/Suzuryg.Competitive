using System;
using System.Collections.Generic;
using System.Text;

namespace Suzuryg.Competitive.Library.MyMath
{
    public class Linear
    {
        /// <summary>
        /// 行基本変形で連立方程式を解く
        /// </summary>
        /// <param name="coef">拡大係数行列</param>
        /// <returns>連立方程式の解（拡大係数行列の列順にソート）</returns>
        public static int[] ElementaryRowTransformation(int[,] coef)
        {
            int rows = coef.GetUpperBound(0) + 1;
            int cols = coef.GetUpperBound(1) + 1;
            if (rows < cols - 1)
            {
                return null;
            }

            int[] order = new int[cols - 1];
            HashSet<int> seen = new HashSet<int>();

            for (int col = 0; col < cols - 1; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    if (seen.Contains(row) || coef[row, col] == 0)
                    {
                        continue;
                    }
                    order[col] = row;
                    seen.Add(row);
                    break;
                }

                int div = coef[order[col], col];
                for (int i = 0; i < cols; i++)
                {
                    coef[order[col], i] /= div;
                }

                for (int i = 0; i < rows; i++)
                {
                    if (i == order[col])
                    {
                        continue;
                    }

                    int mul = coef[i, col];
                    for (int j = 0; j < cols; j++)
                    {
                        coef[i, j] -= mul * coef[order[col], j];
                    }
                }
            }

            if (seen.Count < cols - 1)
            {
                return null;
            }

            int[] ans = new int[cols - 1];
            for (int i = 0; i < cols - 1; i++)
            {
                ans[i] = coef[order[i], cols - 1];
            }

            return ans;
        }
    }
}
