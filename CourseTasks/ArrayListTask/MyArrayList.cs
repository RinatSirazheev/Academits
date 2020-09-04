using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ArrayListTask
{
    class MyArrayList<T> : IList<T>
    {
        private T[] items;
        private int changesCount;
        private const int DefaultCapacity = 10;

        public int Count { get; private set; }

        public int Capacity
        {
            get { return items.Length; }

            set
            {
                if (value < Count)
                {
                    throw new ArgumentException($"Ошибка. Нельзя задать вместимость списка = {Capacity} если она меньше количества элементов списка({Count}).");
                }

                if (Capacity == value)
                {
                    return;
                }

                Array.Resize(ref items, value);

                changesCount++;
            }
        }

        public bool IsReadOnly => false;

        public MyArrayList()
        {
            items = new T[DefaultCapacity];
        }

        public MyArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), $"Ошибка! Вместимость = {capacity}. Вместимость не может быть меньше нуля.");
            }

            items = new T[capacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            int startModeCount = changesCount;

            for (int i = 0; i < Count; i++)
            {
                if (startModeCount != changesCount)
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

        private bool IsGodIndex(int index) => index < 0 || index >= Count;

        public T this[int index]
        {
            get
            {
                if (IsGodIndex(index))
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Ошибка! Индекс = {index} находится вне границ массива. Допустимый диапазон значений от 0 до {Count}.");
                }

                return items[index];
            }

            set
            {
                if (IsGodIndex(index))
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Ошибка! Индекс = {index} находится вне границ массива. Допустимый диапазон значений от 0 до {Count}.");
                }

                items[index] = value;
                changesCount++;
            }
        }

        public void Add(T item)
        {
            Insert(Count, item);
        }

        private void IncreaseCapacity()
        {
            if (items.Length == 0)
            {
                Capacity = DefaultCapacity;
            }
            else
            {
                Capacity = items.Length * 2;
            }

            changesCount++;
        }

        public void RemoveAt(int index)
        {
            if (IsGodIndex(index))
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Ошибка! Индекс = {index} находится вне границ массива. Допустимый диапазон значений от 0 до {Count}.");
            }

            Array.Copy(items, index + 1, items, index, Count - index - 1);

            items[Count - 1] = default;
            Count--;
            changesCount++;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (IsGodIndex(index))
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Ошибка! Индекс = {index} находится вне границ массива. Допустимый диапазон значений от 0 до {Count}.");
            }

            if (Count >= Capacity)
            {
                IncreaseCapacity();
            }

            Array.Copy(items, index, items, index + 1, Count - index);

            items[index] = item;
            Count++;
            changesCount++;
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                items[i] = default;
            }

            Count = 0;
            changesCount++;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
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
            int itemIndex = IndexOf(item);

            if (itemIndex != -1)
            {
                Array.Copy(items, itemIndex + 1, items, itemIndex, Count - itemIndex - 1);

                Count--;
                changesCount++;

                return true;
            }

            return false;
        }

        public T[] ToArray()
        {
            T[] newArray = new T[Count];

            Array.Copy(items, 0, newArray, 0, Count);

            return newArray;
        }

        public int LastIndexOf(T item)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                if (Equals(items[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void TrimExcess()
        {
            Capacity = Count;
        }
    }
}