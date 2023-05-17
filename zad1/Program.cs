using System;

namespace zad1lab2
{
    class Program
    {
        static void Main() //основная функция
        {
            Console.Write("Введите степень: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите число для возведения: ");
            double d = Chislo(Console.ReadLine());
            Console.WriteLine(func(n, d));
            Console.ReadKey();
        }

        static double Chislo(string text) //обработка вещественных чисел
        {
            if (text.Contains("."))
            {
                text = text.Replace(".", ",");
            }
            return double.Parse(text);
        }

        static double func(int n, double a) //функция возведения в степень
        {
            if (n == 0)
                return 1;
            if (n == 1)
                return a;
            else
            {
                n--;
                return a * func(n, a);
            }
        }
    }
}
