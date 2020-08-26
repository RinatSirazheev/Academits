using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTableTask
{
    class HashTable<T> : ICollection<T>
    {
        private List<T>[] array;
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

        public bool IsReadOnly { get { return false; } }

        public void Add(T item)
        {
            int index = Math.Abs(item.GetHashCode() % array.Length);

            if (array[index] == null)
            {
                array[index] = new List<T> { item };
                Count++;
            }
            else
            {
                array[index].Add(item);
                Count++;
            }
        }

        public void Clear()
        {
            foreach (List<T> element in array)
            {
                if (element != null)
                {
                    element.Clear();
                }
            }

            Count = 0;
        }

        public bool Contains(T item)
        {
            bool result = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    if (array[i].Contains(item))
                    {
                        result = true;

                        break;
                    }
                }
            }

            return result;
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

            Array.Copy(this.array, 0, array, arrayIndex, Count);
        }

        public bool Remove(T item)
        {
            bool result = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    if (array[i].Contains(item))
                    {
                        result = array[i].Remove(item);

                        break;
                    }
                }
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
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
