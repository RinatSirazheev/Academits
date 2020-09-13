﻿using System;
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
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Ошибка! Вместимость не может быть меньше либо равна нулю.");
            }

            array = new List<T>[capacity];
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        private int GetIndex(T item)
        {
            if (item == null)
            {
                return 0;
            }

            return Math.Abs(item.GetHashCode() % array.Length);
        }

        public void Add(T item)
        {
            var hashTableIndex = GetIndex(item);

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
            var hashTableIndex = GetIndex(item);

            if (array[hashTableIndex] != null)
            {
                return array[hashTableIndex].Contains(item);
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Ошибка! Массив равен Null");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), "Ошибка! Индекс, не может быть меньше нуля.");
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("Ошибка! Количество элементов в исходной коллекции больше доступного места в массиве.");
            }

            var i = arrayIndex;

            foreach (var item in this)
            {
                array[i] = item;
                i++;
            }
        }

        public bool Remove(T item)
        {
            var hashTableIndex = GetIndex(item);

            if (array[hashTableIndex] == null)
            {
                return false;
            }

            if (array[hashTableIndex].Remove(item))
            {
                Count--;
                changesCount++;

                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var initialChangesCount = changesCount;

            foreach (var list in array)
            {
                if (list != null)
                {
                    foreach (var element in list)
                    {
                        if (initialChangesCount != changesCount)
                        {
                            throw new InvalidOperationException("Ошибка! В коллекции за время обхода изменилось количество элементов!");
                        }

                        yield return element;
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