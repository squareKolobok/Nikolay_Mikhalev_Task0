using System;

namespace Mikhalev_Nikolay_Task1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите размер массива");
            myArray arr = new myArray(ReadKey());
            Console.WriteLine("Массив создан");
            arr.PrintArr();
            string continWork;
            do
            {
                Console.Write("Выберите что хотите сделать с массивом:\n" +
                                    "\t 1: Создать новый массив\n" +
                                    "\t 2: Найти максимальный элемент\n" +
                                    "\t 3: Найти минимальный элемент\n" +
                                    "\t 4: Отсортировать массив по возрастанию\n" +
                                    "\t 5: Посмотреть массив\n");
                int key = ReadKey();
                switch (key)
                {
                    case 1:
                        Console.WriteLine("Введите размер нового массива");
                        arr = new myArray(ReadKey());
                        Console.WriteLine("Массив создан");
                        arr.PrintArr();
                        break;
                    case 2:
                        Console.WriteLine("Вид массива:");
                        arr.PrintArr();
                        Console.WriteLine("Максимальный элемент массива: {0}",arr.Max());
                        break;
                    case 3:
                        Console.WriteLine("Вид массива:");
                        arr.PrintArr();
                        Console.WriteLine("Минимальный элемент массива: {0}", arr.Min());
                        break;
                    case 4:
                        Console.WriteLine("Не сортированный массив:");
                        arr.PrintArr();
                        arr.Sort();
                        Console.WriteLine("Сортированный массив");
                        arr.PrintArr();
                        break;
                    case 5:
                        Console.WriteLine("Вид массива:");
                        arr.PrintArr();
                        break;
                    default:
                        Console.WriteLine("Выбранного пункта меню не существует");
                        break;
                }
                Console.WriteLine("Желаете продолжить?(y/n - н/т)");
                continWork = Console.ReadLine();
                Console.Clear();
            } while (continWork == "y" || continWork == "н");
        }

        static int ReadKey() {
            int key;
            while (true) {
                string k = Console.ReadLine();
                if (int.TryParse(k, out key))
                    break;
                else
                    Console.WriteLine("Данные введены не верно, повторите ввод");
            }
            return key;
        }
    }
}
