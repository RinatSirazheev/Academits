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
        private const int defaultCapacity = 10;

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
            items = new T[defaultCapacity];
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
            Array.Resize<T>(ref items, items.Length + defaultCapacity);

            modeCount++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Ошибка! Индекс = {index}, индекс не должен выходить за рамки массива.", nameof(index));
            }

            Array.Copy(items, index + 1, items, index, Count - index - 1);

            items[Count - 1] = default;
            Count--;
            modeCount++;
        }

        public int IndexOf(T item)
        {
            int specificItemIndex = -1;

            for (int i = 0; i < Count; i++)
            {
                if (Equals(items[i], item))
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
                throw new ArgumentOutOfRangeException($"Ошибка! Индекс = {index}. Индекс не должен выходить за пределы массива");
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
            for (int i = 0; i < Count; i++)
            {
                items[i] = default;
            }

            Count = 0;
            modeCount++;
        }

        public bool Contains(T item)
        {
            bool contains = false;

            if (IndexOf(item) != -1)
            {
                contains = true;
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
            bool result = false;
            int itemIndex = IndexOf(item);

            if (itemIndex != -1)
            {
                Array.Copy(items, itemIndex + 1, items, itemIndex, Count - itemIndex - 1);

                Count--;
                modeCount++;
                result = true;
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

            for (int i = Count - 1; i > 0; i--)
            {
                if (Equals(items[i], item))
                {
                    specificItemOccurrenceLastIndex = i;

                    break;
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