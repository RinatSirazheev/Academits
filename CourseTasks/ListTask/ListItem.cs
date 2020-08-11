using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListTask
{
    class ListItem<T> 
    {
        public T Data { get; set; }
        public ListItem<T> Next { get; set; }

        public ListItem() { }

        public ListItem(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Ошибка. Отсутствуют данные для создания элемента списка.", nameof(data));
            }

            Data = data;
        }

        public ListItem(T data, ListItem<T> next)
        {
            if(data == null)
            {
                throw new ArgumentNullException("Ошибка. Отсутствуют данные для создания элемента списка.", nameof(data));
            }

            Data = data;
            Next = next;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}