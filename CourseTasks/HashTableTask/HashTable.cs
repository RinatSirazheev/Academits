using NPOI.SS.Formula.Functions;
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

        public bool IsReadOnly { get { return true; } }

        public void Add(T item)
        {
            int index = Math.Abs(item.GetHashCode() % array.Length);

            if (array[index] == null)
            {
                array[index].Add(item);
            }

            if (array[index] != null)
            {

            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
