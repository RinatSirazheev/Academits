using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTableTask
{
    class HashTable<T> : ICollection<T>
    {
        private readonly List<T>[] array;
        private int modeCount;
        private const int defaultCapacity = 100;

        public HashTable()
        {
            array = new List<T>[defaultCapacity];
        }

        public HashTable(int capacity)
        {
            array = new List<T>[capacity];
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            int index = Math.Abs(item == null ? 0 : item.GetHashCode() % array.Length);

            if (array[index] == null)
            {
                array[index] = new List<T> { item };
            }
            else
            {
                array[index].Add(item);
            }

            Count++;
            modeCount++;
        }

        public void Clear()
        {
            foreach (var element in array)
            {
                element?.Clear();
            }

            modeCount++;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var hashTableIndex = Math.Abs(item != null ? item.GetHashCode() % array.Length : 0);

            if (array[hashTableIndex] != null)
            {
                foreach (var element in array[hashTableIndex])
                {
                    if (Equals(element, item))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"Ошибка! Массив {nameof(array)} равен Null");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException($"Ошибка! Индекс = {arrayIndex}, не может быть меньше нуля.");
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("Ошибка! Количество элементов в исходной коллекции больше доступного места в массиве.");
            }

            foreach (var item in this)
            {
                array[arrayIndex] = item;
                arrayIndex++;
            }
        }

        public bool Remove(T item)
        {
            var hashTableIndex = Math.Abs(item != null ? item.GetHashCode() % array.Length : 0);

            if (array[hashTableIndex] != null)
            {
                return array[hashTableIndex].Remove(item);
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int startModeCount = modeCount;

            for (int i = 0; i < array.Length; i++)
            {
                if (startModeCount != modeCount)
                {
                    throw new InvalidOperationException("Ошибка! В коллекции за время обхода изменилось количество элементов!");
                }

                if (array[i] != null)
                {
                    for (int j = 0; j < array[i].Count; j++)
                    {
                        yield return array[i][j];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}