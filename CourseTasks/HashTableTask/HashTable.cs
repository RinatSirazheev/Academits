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
            

throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < length; i++)
            {
                for(int j = 0; j < array[i].Count; j++)
                {
                    T res = array[i][j];
                    yield return res;
                }
            }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
