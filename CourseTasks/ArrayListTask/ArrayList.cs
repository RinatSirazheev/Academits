using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListTask
{
    class MyArray<T>
    {
        private T[] items;
        private int length;

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

        }
    }
}