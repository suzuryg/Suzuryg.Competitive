using System;
using System.Collections.Generic;
using System.Text;

namespace Suzuryg.Competitive.Library.Math
{
    public class Integer
    {
        public static bool IsPrime(long n)
        {
            if (n == 1)
            {
                return false;
            }
            for (long a = 2; a * a <= n; a++)
            {
                if (n % a == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<(long primeFactor, long exponent)> PrimeFactrize(long n)
        {
            List<(long, long)> ret = new List<(long, long)>();
            for (long a = 2; a * a <= n; a++)
            {
                if (n % a != 0)
                {
                    continue;
                }

                long ex = 0;
                while(n % a == 0)
                {
                    ex++;
                    n /= a;
                }

                ret.Add((a, ex));
            }

            if (n != 1)
            {
                ret.Add((n, 1));
            }

            return ret;
        }
    }
}
