using System;

namespace ListTask
{
    class ListTaskDemo
    {
        static void Main()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();

            for (int i = 10; i > 0; i--)
            {
                list.AddFirst(i);
            }

            Console.WriteLine("Создали односвязный список.");
            Console.WriteLine(list);

            Console.WriteLine("Размер списка = " + list.Count);

            Console.WriteLine("Первый элемент списка = " + list.GetFirstElement());

            Console.WriteLine("Пятый элемент списка равен = " + list.GetItemAt(4));

            Console.WriteLine("Заменим пятый элемент списка  на 888. Старое значение = " + list.SetItemAt(4, 888));
            Console.WriteLine(list);

            Console.WriteLine("Удалим пятый элемент = " + list.RemoveAt(4));
            Console.WriteLine(list);

            Console.WriteLine("Вставим в начало число 888");
            list.AddFirst(888);
            Console.WriteLine(list);

            Console.WriteLine("Вставим число 888 по последнему индексу");
            list.Insert(list.Count - 1, 888);
            Console.WriteLine(list);

            Console.WriteLine("Удалить элемент со значением 5");

            if (list.Remove(5))
            {
                Console.WriteLine("Элемент списка со значением 5 успешно удален");

                Console.WriteLine(list);
            }
            else
            {
                Console.WriteLine("Элемента со значением 5 в списке не найдено");
            }

            Console.WriteLine("Удалим первый элемент = " + list.RemoveFirstElement());
            Console.WriteLine(list);

            Console.WriteLine("Осуществим разворот списка.");
            list.Turn();
            Console.WriteLine(list);

            Console.WriteLine("Создадим копию существующего списка.");

            SinglyLinkedList<int> listCopy = list.Copy();

            Console.WriteLine(listCopy);
        }
    }
}