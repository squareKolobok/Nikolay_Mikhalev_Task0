using System;

namespace Mikhalev_Nikolay_Task1
{
    class Program
    {
        static void Main()
        {
            string continWork;
            Console.Write("Программа поддерживает ввод на en и ru раскладке прописными буквами\n");
            do
            {
                Console.Write("Выберете график (а - к) \n");
                string NumGraph = Console.ReadLine();
                double coordX, coordY;
                while (true)
                {
                    Console.Write("Введите X и Y (вводить через Enter, добную часть разделять ',') \n");
                    if (double.TryParse(Console.ReadLine(), out coordX) &&
                        double.TryParse(Console.ReadLine(), out coordY))
                        break;
                    else
                        Console.Write("данные введены не правильно, повторите ввод \n");
                }
                switch (NumGraph)
                {
                    case "а":
                    case "f":
                        NumGraph = "а";
                        WriteResult(coordX, coordY, NumGraph,
                            (coordX * coordX + coordY * coordY <= 1));
                        break;
                    case "б":
                    case ",":
                        NumGraph = "б";
                        WriteResult(coordX, coordY, NumGraph,
                        (coordX * coordX + coordY * coordY <= 1) && (coordX * coordX + coordY * coordY >= 0.5));
                        break;
                    case "в":
                    case "d":
                        NumGraph = "в";
                        WriteResult(coordX, coordY, NumGraph,
                        Math.Abs(coordX) <= 1 && Math.Abs(coordY) <= 1);
                        break;
                    case "г":
                    case "u":
                        NumGraph = "г";
                        WriteResult(coordX, coordY, NumGraph,
                        (Math.Abs(coordX) - 1 <= coordY) && (1 - Math.Abs(coordX) >= coordY));
                        break;
                    case "д":
                    case "l":
                        NumGraph = "д";
                        WriteResult(coordX, coordY, NumGraph,
                        (Math.Abs(2 * coordX) - 1 <= coordY) && (1 - Math.Abs(2 * coordX) >= coordY));
                        break;
                    case "е":
                    case "t":
                        NumGraph = "е";
                        WriteResult(coordX, coordY, NumGraph,
                        (coordX < 0 && (Math.Abs(coordY) - 2 <= coordX)) ||
                        (coordX >= 0 && coordX * coordX + coordY * coordY <= 1));
                        break;
                    case "ж":
                    case ";":
                        NumGraph = "ж";
                        WriteResult(coordX, coordY, NumGraph,
                        (coordY >= -1) && (2 - Math.Abs(2 * coordX) >= coordY));
                        break;
                    case "з":
                    case "p":
                        NumGraph = "з";
                        WriteResult(coordX, coordY, NumGraph,
                        (Math.Abs(coordX) <= 1 && Math.Abs(coordY + 0.5) <= 1.5) && (Math.Abs(coordX) >= coordY));
                        break;
                    case "и":
                    case "b":
                        NumGraph = "и";
                        WriteResult(coordX, coordY, NumGraph,
                        (coordY >= 0 && coordX <= -coordY && coordX >= (coordY - 3) / 2) ||
                        (coordY <= 0 && coordX >= (coordY - 3) / 2 && coordY >= (coordX - 1) / 3));
                        break;
                    case "к":
                    case "r":
                        NumGraph = "к";
                        WriteResult(coordX, coordY, NumGraph,
                        (coordY >= 1) || (Math.Abs(coordX) <= coordY));
                        break;
                    default:
                        Console.Write("данные введены неправильно  \n");
                        break;
                }
                Console.Write("Продолжить работу? (y / n) \n");
                continWork = Console.ReadLine();
            } while (continWork == "y" || continWork == "н");
        }

        static void WriteResult(double X, double Y, string figure, bool negativ)
        {
            Console.Write("Точка ({0}; {1}) {2}", X, Y, (negativ ? "" : "не ") + "принадлежит фигуре " + figure + " \n");
        }
    }
}
