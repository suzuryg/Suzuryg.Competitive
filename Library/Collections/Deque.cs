using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Suzuryg.Competitive.Library.Collections
{
    // https://webbibouroku.com/Blog/Article/deque-cs
    public class Deque<T> : IEnumerable<T>
    {
        public T this[int i]
        {
            get { return Buffer[(FirstIndex + i) % Capacity]; }
            set
            {
                if (i < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    Buffer[(FirstIndex + i) % Capacity] = value;
                }
            }
        }

        private T[] Buffer;
        private int FirstIndex;
        private int NextIndex
        {
            get { return (FirstIndex + Length) % Capacity; }
        }
        // 現在確保している配列に格納できるデータ数
        private int Capacity;
        // 現在格納しているデータ数
        public int Length { get; private set; }

        public Deque(int capacity = 16)
        {
            Capacity = capacity;
            Buffer = new T[Capacity];
            FirstIndex = 0;
        }

        public void PushBack(T data)
        {
            if (Length == Capacity)
            {
                Resize();
            }
            Buffer[NextIndex] = data;
            Length++;
        }

        public void PushFront(T data)
        {
            if (Length == Capacity)
            {
                Resize();
            }
            var prevIndex = FirstIndex - 1;
            if (prevIndex < 0)
            {
                prevIndex = Capacity - 1;
            }
            Buffer[prevIndex] = data;
            Length++;
            FirstIndex = prevIndex;
        }

        public T PopBack()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("データが空です");
            }
            var data = this[Length - 1];
            Length--;
            return data;
        }

        public T PopFront()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("データが空です");
            }
            var data = this[0];
            FirstIndex++;
            FirstIndex %= Capacity;
            Length--;
            return data;
        }

        private void Resize()
        {
            var newArray = new T[Capacity * 2];
            for (int i = 0; i < Length; i++)
            {
                newArray[i] = this[i];
            }
            FirstIndex = 0;
            Capacity *= 2;
            Buffer = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return this[i];
            }
        }
    }
}
