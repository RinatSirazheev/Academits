using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListTask
{
    class MyArray<T> : IList<T>
    {
        private T[] items;
        private int length;
        private int modeCoumt;

        public IEnumerator<T> GetEnumerator()
        {
            int flag = modeCoumt;

            for (int i = 0; i < length; i++)
            {
                if (flag != modeCoumt)
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

        public int Count
        {
            get { return length; }
        }

        public int Capacity
        {
            get { return items.Length; }

            set
            {
                if (value < Count)
                {
                    throw new ArgumentException("Ошибка. Нельзя задать вместимость списка меньше количества элементов списка.");
                }

                if (Capacity == value)
                {
                    throw new Exception(" ");
                }

                T[] old = items;
                items = new T[value];
                Array.Copy(old, 0, items, 0, old.Length);
            }
        }

        public bool IsReadOnly { get { return false; } }

        public MyArray()
        {
            items = new T[10];
        }

        public MyArray(int capacity)
        {
            items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > length)
                {
                    throw new ArgumentOutOfRangeException($"Ошибка! Индекс = {index} находится вне границ массива.");
                }

                return items[index];
            }

            set
            {
                if (index < 0 || index > length)
                {
                    throw new ArgumentOutOfRangeException($"Ошибка! Индекс = {index} находится вне границ массива.");
                }

                items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (length >= Capacity)
            {
                IncreaseCapacity();
            }

            items[length] = item;
            length++;
            modeCoumt++;
        }

        private void IncreaseCapacity()
        {
            T[] old = items;
            items = new T[old.Length * 2];

            Array.Copy(old, 0, items, 0, old.Length);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException($"Ошибка! Индекс = {index}, индекс не должен выходить за рамки массива.", nameof(index));
            }

            Array.Copy(items, index + 1, items, index, length - index - 1);

            length--;
            modeCoumt++;
        }

        public int IndexOf(T item)
        {
            int specificItemIndex = -1;

            for (int i = 0; i < length; i++)
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
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException($"Ошибка! Индекс = {index}. Индекс не должен выходить за пределы массива");
            }

            if (IsReadOnly)
            {
                throw new NotSupportedException("Ошибка! Список только для чтения!");
            }

            if (length >= Capacity)
            {
                IncreaseCapacity();
            }

            Array.Copy(items, index, items, index + 1, length - index);

            items[index] = item;
            length++;
            modeCoumt++;
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Ошибка! Список только для чтения!");
            }

            items = new T[10];

            length = 0;
            modeCoumt++;
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

            if (length > array.Length - arrayIndex)
            {
                throw new ArgumentException("Ошибка! Количество элементов в исходной коллекции больше доступного места в массиве.");
            }

            Array.Copy(items, 0, array, arrayIndex, length);
        }

        public bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Ошибка! Список только для чтения!");
            }

            bool result = false;

            for (int i = 0; i < length; i++)
            {
                if (items[i].Equals(item))
                {
                    Array.Copy(items, i + 1, items, i, length - i - 1);

                    length--;
                    modeCoumt++;
                    result = true;

                    break;
                }
            }

            return result;
        }

        public T[] ToArray()
        {
            T[] newArray = new T[length];

            Array.Copy(items, 0, newArray, 0, length);

            return newArray;
        }

        public int LastIndexOf(T item)
        {
            int specificItemOccurrenceLastIndex = -1;

            for (int i = 0; i < length; i++)
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

            Array.Copy(arrayCopy, 0, items, 0, length);
        }
    }
}