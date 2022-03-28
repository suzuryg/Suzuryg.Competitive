using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Suzuryg.Competitive.Library.MyMath
{
    // https://gist.github.com/subena22jf/c7bb027ea99127944981
    public class LongRandom
    {
        private System.Random _random;

        public LongRandom()
        {
            _random = new System.Random();
        }

        public void Init()
        {
            _random = new System.Random();
        }

        public long Next(long minInclusive, long maxExclusive)
        {
            if (maxExclusive <= minInclusive)
            {
                throw new ArgumentOutOfRangeException("maxExclusive", "maxExclusive must be > minInclusive!");
            }

            ulong uRange = (ulong)(maxExclusive - minInclusive); // ここで maxExclusive が long.MaxValue + 1 だった場合オーバーフローする
            ulong ulongRand;
            do
            {
                byte[] buf = new byte[8];
                _random.NextBytes(buf);
                ulongRand = BitConverter.ToUInt64(buf, 0);
            } while (ulongRand > ulong.MaxValue - ((ulong.MaxValue % uRange) + 1) % uRange);
            // ex)  [0, 8] で生成される乱数を利用して [-1, 3) の乱数を作りたい
            //      すべての要素の出現確率を一様にするには、元になる乱数の要素数を4 (= 3 - (-1)) の倍数とする必要がある
            //      そのため、[0, 7] に含まれない値が出現した場合は再度乱数を生成する
            //      value > 8 - (((8 % 4) + 1) % 4)
            //      value > 8 - (1 % 4)
            //      value > 7 のとき再生成
            //      [0, 11] で乱数が生成される場合は
            //      value > 11 - (((11 % 4) + 1) % 4)
            //      value > 11 - (4 % 4)  ← 2度目のmodがないと範囲が正しくならない
            //      value > 11 のとき再生成（つまり全範囲を使用）

            return (long)(ulongRand % uRange) + minInclusive;
        }

        public long Next()
        {
            return Next(0, long.MaxValue);
        }

        public long Next(long maxExclusive)
        {
            return Next(0, maxExclusive);
        }

        public long NextInclusive(long minInclusive, long maxInclusive)
        {
            if (maxInclusive == long.MaxValue)
            {
                if (minInclusive == long.MinValue)
                {
                    var value1 = Next() % 0x100000000;  // 0x0000000000000000 <= value1 <= 0x00000000FFFFFFFF
                    var value2 = Next() % 0x100000000;  // 0x0000000000000000 <= value2 <= 0x00000000FFFFFFFF
                    return (value1 << 32) | value2;     // 0x0000000100000000 <= (value1 << 32) <= 0xFFFFFFFF00000000 (0も含む)
                                                        // 0x0000000000000000 <= ((value1 << 32) | value2) <= 0xFFFFFFFFFFFFFFFF
                }
                return Next(minInclusive - 1, long.MaxValue) + 1;
            }
            return Next(minInclusive, maxInclusive + 1);
        }
    }

    // https://stackoverflow.com/questions/57118385/random-number-between-int-minvalue-and-int-maxvalue-inclusive
    public static class IntRandom
    {
        public static int NextInclusive(this Random random, int minValue, int maxValue)
        {
            if (maxValue == Int32.MaxValue)
            {
                if (minValue == Int32.MinValue)
                {
                    var value1 = random.Next() % 0x10000;   // 0x00000000 <= value1 <= 0x0000FFFF
                    var value2 = random.Next() % 0x10000;   // 0x00000000 <= value2 <= 0x0000FFFF
                    return (value1 << 16) | value2;         // 0x00010000 <= (value1 << 16) <= 0xFFFF0000 (0も含む)
                                                            // 0x00000000 <= ((value1 << 16) | value2) <= 0xFFFFFFFF
                }
                return random.Next(minValue - 1, Int32.MaxValue) + 1;
            }
            return random.Next(minValue, maxValue + 1);
        }
    }

    // https://gist.github.com/subena22jf/c7bb027ea99127944981
    // 未整理
    public class OthersRandom
    {
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            System.Random random = new System.Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            if (lowerCase)
            {
                return builder.ToString().ToLower();
            }

            return builder.ToString();
        }
        
        public object NextArrayList(ArrayList Arrays)
        {
            System.Random rd = new System.Random();
            int rand = rd.Next(0, Arrays.Count);
            var value = Arrays[rand];
            return value;
        }
        
        public IEnumerable<T> Randomize<T>(IEnumerable<T> source)
        {
            System.Random rnd = new System.Random();
            return source.OrderBy<T, int>((item) => rnd.Next());
        }
    }

    public class RandomTest
    {
        public static void IntTest()
        {
            const int itr = 10000000;
            const int div = 10;

            List<int> list = new List<int>();
            var random = new System.Random();
            for (int i = 0; i < itr; i++)
            {
                list.Add(random.NextInclusive(int.MinValue, int.MaxValue));
            }
            Console.WriteLine($"int.MinValue:  {int.MinValue}");
            Console.WriteLine($"MinInt:        {list.Min()}");

            Console.WriteLine($"int.MaxValue:  {int.MaxValue}");
            Console.WriteLine($"MaxInt:        {list.Max()}");

            Dictionary<int, int> hist = new Dictionary<int, int>();
            int unit = int.MaxValue / div * 2;
            int now = int.MinValue;
            foreach (var val in list.OrderBy(x => x))
            {
                if (val < now || val == int.MaxValue)
                {
                    hist[now]++;
                }
                else
                {
                    if (now > 0 && int.MaxValue - now < unit * 2)
                    {
                        now = int.MaxValue;
                    }
                    else
                    {
                        now += unit;
                    }
                    hist[now] = 1;
                }
            }

            foreach (var key in hist.Keys)
            {
                Console.WriteLine($"{hist[key]}: \t ～{key}");
            }
        }

        public static void LongTest()
        {
            const int itr = 10000000;
            const int div = 10;

            List<long> list = new List<long>();
            var longRandom = new LongRandom();
            for (int i = 0; i < itr; i++)
            {
                list.Add(longRandom.NextInclusive(long.MinValue, long.MaxValue));
            }
            Console.WriteLine($"long.MinValue: {long.MinValue}");
            Console.WriteLine($"MinLong:       {list.Min()}");

            Console.WriteLine($"long.MaxValue: {long.MaxValue}");
            Console.WriteLine($"MaxLong:       {list.Max()}");

            Dictionary<long, int> hist = new Dictionary<long, int>();
            long unit = long.MaxValue / div * 2;
            long now = long.MinValue;
            foreach (var val in list.OrderBy(x => x))
            {
                if (val < now || val == long.MaxValue)
                {
                    hist[now]++;
                }
                else
                {
                    if (now > 0 && long.MaxValue - now < unit * 2)
                    {
                        now = long.MaxValue;
                    }
                    else
                    {
                        now += unit;
                    }
                    hist[now] = 1;
                }
            }

            foreach (var key in hist.Keys)
            {
                Console.WriteLine($"{hist[key]}: \t ～{key}");
            }
        }
    }
}
