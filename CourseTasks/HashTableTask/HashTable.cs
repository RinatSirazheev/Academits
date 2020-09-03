using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTableTask
{
    class HashTable<T> : ICollection<T>
    {
        private readonly List<T>[] array;
        private int changesCount;
        private const int DefaultCapacity = 100;

        public HashTable()
        {
            array = new List<T>[DefaultCapacity];
        }

        public HashTable(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("Ошибка! Вместимость не может быть меньше нуля.");
            }

            array = new List<T>[capacity];
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        private int GetHash(T item)
        {
            if (item == null)
            {
                return 0;
            }
            else
            {
                return Math.Abs(item.GetHashCode() % array.Length);
            }
        }

        public void Add(T item)
        {
            var hashTableIndex = GetHash(item);

            if (array[hashTableIndex] == null)
            {
                array[hashTableIndex] = new List<T> { item };
            }
            else
            {
                array[hashTableIndex].Add(item);
            }

            Count++;
            changesCount++;
        }

        public void Clear()
        {
            foreach (var element in array)
            {
                element?.Clear();
            }

            changesCount++;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var hashTableIndex = GetHash(item);

            if (array[hashTableIndex] != null)
            {
                return array[hashTableIndex].Contains(item);
            }

            return false;
        }

        public void CopyTo(T[] array, int hashTableIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"Ошибка! Массив {nameof(array)} равен Null");
            }

            if (hashTableIndex < 0)
            {
                throw new ArgumentOutOfRangeException($"Ошибка! Индекс = {hashTableIndex}, не может быть меньше нуля.");
            }

            if (Count > array.Length - hashTableIndex)
            {
                throw new ArgumentException("Ошибка! Количество элементов в исходной коллекции больше доступного места в массиве.");
            }

            var i = hashTableIndex;

            foreach (var item in this)
            {
                array[i] = item;
                i++;
            }
        }

        public bool Remove(T item)
        {
            var hashTableIndex = GetHash(item);

            return array[hashTableIndex] != null ? array[hashTableIndex].Remove(item) : false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var startChangesCount = changesCount;

            foreach (var list in array)
            {
                if (list != null)
                {
                    if (startChangesCount != changesCount)
                    {
                        throw new InvalidOperationException("Ошибка! В коллекции за время обхода изменилось количество элементов!");
                    }

                    for (var i = 0; i < list.Count; i++)
                    {
                        yield return list[i];
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