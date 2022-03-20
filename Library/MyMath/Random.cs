using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Suzuryg.Competitive.Library.MyMath
{
    // https://gist.github.com/subena22jf/c7bb027ea99127944981
    public class Random
    {
        public int index;
		
		public void init()
        {
			System.Random rd = new System.Random();
		}

        public int Next(int Min, int Max)
        {
            System.Random rd = new System.Random();
            return rd.Next(Min, Max);
        }

        public long Next(long min, long max)
        {
            System.Random rd = new System.Random();

            if (max <= min)
                throw new ArgumentOutOfRangeException("max", "max must be > min!");

            ulong uRange = (ulong)(max - min);
            ulong ulongRand;
            do
            {
                byte[] buf = new byte[8];
                rd.NextBytes(buf);
                ulongRand = BitConverter.ToUInt64(buf, 0);
            } while (ulongRand > ulong.MaxValue - ((ulong.MaxValue % uRange) + 1) % uRange);

            return (long)(ulongRand % uRange) + min;
        }

        public long Next(long max)
        {
            return Next(0, max);
        }

        public int Next(int Max)
        {
            System.Random rd = new System.Random();
            return rd.Next(Max);
        }

        public byte NextBytes(byte[] buffer)
        {
            Random rnd = new Random();
            return rnd.NextBytes(buffer);
        }

        public double NextDouble()
        {
            System.Random rd = new System.Random();
            return rd.NextDouble();
        }

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
                return builder.ToString().ToLower();
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
}
