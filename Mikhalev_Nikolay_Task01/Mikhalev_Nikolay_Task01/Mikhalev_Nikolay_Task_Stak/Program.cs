using System;

namespace Mikhalev_Nikolay_Task_Stak
{
    class Program
    {
        static myStack<string> testStack = new myStack<string>();

        static void Main()
        {
            string continWork;
            do
            {

                Console.Clear();
                Console.Write("Выберите что хотите сделать со стеком:\n" +
                                    "\t 1: добавить элемент\n" +
                                    "\t 2: получить элемент\n" +
                                    "\t 3: посмотреть элемент\n" +
                                    "\t 4: проверить является ли стек пустым\n");
                string key = Console.ReadLine();
                string elem;
                switch (key)
                {
                    case "1":
                        Console.WriteLine("Введите элемент, который хотиде добавить");
                        elem = Console.ReadLine();
                        testStack.Push(elem);
                        Console.WriteLine("элемент {0} добавлен в стек", elem);
                        break;
                    case "2":
                        if (testStack.Empty())
                            Console.WriteLine("Нельзя получить элемент из пустого стека");
                        else
                        {
                            elem = testStack.Pop();
                            Console.WriteLine("элемент {0} взят из стека", elem);
                        }
                        break;
                    case "3":
                        if (testStack.Empty())
                            Console.WriteLine("Стек пустой");
                        else
                        {
                            elem = testStack.Get();
                            Console.WriteLine("в стеке находиться элемент {0}", elem);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Стек {0}пустой", testStack.Empty() ? "" : "не ");
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
