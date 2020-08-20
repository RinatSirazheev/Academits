using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableTask
{
    class HashTable<T> : ICollection<T>
    {
        private List<T>[] array;
        private int length;

        public HashTable()
        {
            array = new List<T>[100];
        }

        public HashTable(int capacity)
        {
            array = new List<T>[capacity];
        }

        public int Count { get { return length; } }

        public bool IsReadOnly { get { return false; } }

        public void Add(T item)
        {
            int index = Math.Abs(item.GetHashCode() % array.Length);

            if (array[index] == null)
            {
                array[index] = new List<T> { item };
                length++;
            }
            else
            {
                array[index].Add(item);
                length++;
            }
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Ошибка! Доступен только для чтения.");
            }

            foreach (List<T> element in array)
            {
                if (element != null)
                {
                    element.Clear();
                }
            }

            length = 0;
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

            if (length > array.Length - arrayIndex)
            {
                throw new ArgumentException("Ошибка! Количество элементов в исходной коллекции больше доступного места в массиве.");
            }

            Array.Copy(this.array, 0, array, arrayIndex, length);
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

        public bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Ошибка! Доступен только для чтения.");
            }

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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
