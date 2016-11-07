using System;

namespace Mikhalev_Nikolay_Task1
{
    class Program
    {
        static void Main()
        {
            string continWork;
            do
            {
                Console.Write("Выберете график (а - к) \n");
                string NumGraph = Console.ReadLine();
                double coordX, coordY;
                while (true)
                {
                    Console.Write("Введите X и Y \n");
                    if (double.TryParse(Console.ReadLine(), out coordX) && double.TryParse(Console.ReadLine(), out coordY))
                        break;
                    else
                        Console.Write("данные введены не правильно, повторите ввод \n");
                }
                switch (NumGraph)
                {
                    case "а":
                        if ((coordX * coordX + coordY * coordY <= 1))
                            WriteResult(coordX, coordY, NumGraph, "");
                        else
                            WriteResult(coordX, coordY, NumGraph, "не ");
                        break;
                    case "б":
                        if ((coordX * coordX + coordY * coordY <= 1) && (coordX * coordX + coordY * coordY >= 0.5))
                            WriteResult(coordX, coordY, NumGraph, "");
                        else
                            WriteResult(coordX, coordY, NumGraph, "не ");
                        break;
                    case "в":
                        if (Math.Abs(coordX) <= 1 && Math.Abs(coordY) <= 1)
                            WriteResult(coordX, coordY, NumGraph, "");
                        else
                            WriteResult(coordX, coordY, NumGraph, "не ");
                        break;
                    case "г":
                        if ((Math.Abs(coordX) - 1 <= coordY) && (1 - Math.Abs(coordX) >= coordY))
                            WriteResult(coordX, coordY, NumGraph, "");
                        else
                            WriteResult(coordX, coordY, NumGraph, "не ");
                        break;
                    case "д":
                        if ((Math.Abs(2 * coordX) - 1 <= coordY) && (1 - Math.Abs(2 * coordX) >= coordY))
                            WriteResult(coordX, coordY, NumGraph, "");
                        else
                            WriteResult(coordX, coordY, NumGraph, "не ");
                        break;
                    case "е":
                        if ((coordX < 0 && (Math.Abs(coordY) - 2 <= coordX)) || (coordX >= 0 && coordX * coordX + coordY * coordY <= 1))
                            WriteResult(coordX, coordY, NumGraph, "");
                        else
                            WriteResult(coordX, coordY, NumGraph, "не ");
                        break;
                    case "ж":
                        if ((coordY >= -1) && (2 - Math.Abs(2 * coordX) >= coordY))
                            WriteResult(coordX, coordY, NumGraph, "");
                        else
                            WriteResult(coordX, coordY, NumGraph, "не ");
                        break;
                    case "з":
                        if ((Math.Abs(coordX) <= 1 && Math.Abs(coordY + 0.5) <= 1.5) && (Math.Abs(coordX) <= coordY))
                            WriteResult(coordX, coordY, NumGraph, "");
                        else
                            WriteResult(coordX, coordY, NumGraph, "не ");
                        break;
                    case "и":
                        if ((coordY >= 0 && coordX <= -coordY && coordX >= (coordY - 3) / 2) ||
                            (coordY <= 0 && coordX >= (coordY - 3) / 2 && coordY >= (coordX - 1) / 3))
                            WriteResult(coordX, coordY, NumGraph, "");
                        else
                            WriteResult(coordX, coordY, NumGraph, "не ");
                        break;
                    case "к":
                        if ((coordY >= 1) || (Math.Abs(coordX) <= coordY))
                            WriteResult(coordX, coordY, NumGraph, "");
                        else
                            WriteResult(coordX, coordY, NumGraph, "не ");
                        break;
                    default:
                        Console.Write("данные введены неправильно  \n");
                        break;
                }
                Console.Write("Продолжить работу? (y / n) \n");
                continWork = Console.ReadLine();
            } while (continWork == "y" || continWork == "н");
        }

        static void WriteResult(double X, double Y, string figure, string negativ)
        {
            Console.Write("Точка (" + X + ";" + Y + ") " + negativ + "принадлежит фигуре " + figure + " \n");
        }
    }
}
