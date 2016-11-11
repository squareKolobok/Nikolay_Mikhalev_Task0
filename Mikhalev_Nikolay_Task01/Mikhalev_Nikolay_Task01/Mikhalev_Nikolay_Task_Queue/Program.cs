using System;

namespace Mikhalev_Nikolay_Task_Queue
{
    class Program
    {
        static myQueue<string> testQueue = new myQueue<string>();

        static void Main()
        {
            string continWork;
            do
            {

                Console.Clear();
                Console.Write("Выберите что хотите сделать с очередью:\n" +
                                    "\t 1: добавить элемент\n" +
                                    "\t 2: получить элемент\n" +
                                    "\t 3: посмотреть элемент\n" +
                                    "\t 4: проверить является ли очередь пустой\n");
                string key = Console.ReadLine();
                string elem;
                switch (key)
                {
                    case "1":
                        Console.WriteLine("Введите элемент, который хотиде добавить");
                        elem = Console.ReadLine();
                        testQueue.Enqueue(elem);
                        Console.WriteLine("элемент {0} добавлен в очередь", elem);
                        break;
                    case "2":
                        if (testQueue.Empty())
                            Console.WriteLine("Нельзя получить элемент из пустой очереди");
                        else
                        {
                            elem = testQueue.Dequeue();
                            Console.WriteLine("элемент {0} взят из очереди", elem);
                        }
                        break;
                    case "3":
                        if (testQueue.Empty())
                            Console.WriteLine("Очередь пустая");
                        else
                        {
                            elem = testQueue.Front();
                            Console.WriteLine("в очереди находиться элемент {0}", elem);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Очередь {0}пустая", testQueue.Empty() ? "" : "не ");
                        break;
                    default:
                        Console.WriteLine("Выбранного пункта меню не существует");
                        break;
                }
                Console.WriteLine("Желаете продолжить?(y/n - н/т)");
                continWork = Console.ReadLine();
            } while (continWork == "y" || continWork == "н");
        }
    }
}
