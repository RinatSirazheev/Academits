using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ArrayListTask
{
    class MyArrayList<T> : IList<T>
    {
        private T[] items;
        private int modeCount;

        public int Count { get; private set; }

        public int Capacity
        {
            get { return items.Length; }

            set
            {
                if (value < Count)
                {
                    throw new ArgumentException("Ошибка. Нельзя задать вместимость списка меньше количества элементов списка.");
                }

                T[] old = items;
                items = new T[value];
                Array.Copy(old, 0, items, 0, old.Length);
            }
        }

        public bool IsReadOnly => false;

        public MyArrayList()
        {
            items = new T[10];
        }

        public MyArrayList(int capacity)
        {
            items = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            int startModeCount = modeCount;

            for (int i = 0; i < Count; i++)
            {
                if (startModeCount != modeCount)
                {
                    throw new InvalidOperationException("Ошибка! В коллекции за время обхода изменилось количество элементов!");
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Count)
                {
                    throw new ArgumentOutOfRangeException($"Ошибка! Индекс = {index} находится вне границ массива.");
                }

                return items[index];
            }

            set
            {
                if (index < 0 || index > Count)
                {
                    throw new ArgumentOutOfRangeException($"Ошибка! Индекс = {index} находится вне границ массива.");
                }

                items[index] = value;
                modeCount++;
            }
        }

        public void Add(T item)
        {
            Insert(Count, item);
        }

        private void IncreaseCapacity()
        {
            T[] old = items;
            items = new T[old.Length * 2];

            Array.Copy(old, 0, items, 0, old.Length);

            modeCount++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Ошибка! Индекс = {index}, индекс не должен выходить за рамки массива.", nameof(index));
            }

            Array.Copy(items, index + 1, items, index, Count - index - 1);

            items[Count] = items[Count + 1];
            Count--;
            modeCount++;
        }

        public int IndexOf(T item)
        {
            int specificItemIndex = -1;

            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    specificItemIndex = i;

                    break;
                }
            }

            return specificItemIndex;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException($"Ошибка! Индекс = {index}. Индекс не должен выходить за пределы массива");
            }

            if (IsReadOnly)
            {
                throw new NotSupportedException("Ошибка! Список только для чтения!");
            }

            if (Count >= Capacity)
            {
                IncreaseCapacity();
            }

            Array.Copy(items, index, items, index + 1, Count - index);

            items[index] = item;
            Count++;
            modeCount++;
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Ошибка! Список только для чтения!");
            }

            items = new T[10];

            Count = 0;
            modeCount++;
        }

        public bool Contains(T item)
        {
            bool contains = false;

            foreach (T e in items)
            {
                if (e.Equals(item))
                {
                    contains = true;

                    break;
                }
            }

            return contains;
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

            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Ошибка! Список только для чтения!");
            }

            bool result = false;

            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    Array.Copy(items, i + 1, items, i, Count - i - 1);

                    Count--;
                    modeCount++;
                    result = true;

                    break;
                }
            }

            return result;
        }

        public T[] ToArray()
        {
            T[] newArray = new T[Count];

            Array.Copy(items, 0, newArray, 0, Count);

            return newArray;
        }

        public int LastIndexOf(T item)
        {
            int specificItemOccurrenceLastIndex = -1;

            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    specificItemOccurrenceLastIndex = i;
                }
            }

            return specificItemOccurrenceLastIndex;
        }

        public void TrimExcess()
        {
            T[] arrayCopy = items;
            items = new T[arrayCopy.Count()];

            Array.Copy(arrayCopy, 0, items, 0, Count);

            modeCount++;
        }
    }
}