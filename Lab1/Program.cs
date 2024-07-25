using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        
        private static int a;
        private static int b;
        private static int[,] sad;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размеры сада");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            sad = new int[a, b];

            ThreadStart threadStart = new ThreadStart(Gardener1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardener2();

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(sad[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        private static void Gardener1()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (sad[i, j] == 0)
                        sad[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }

        private static void Gardener2()
        {
            for (int i = b - 1; i >= 0; i--)
            {
                for (int j = a - 1; j >= 0; j--)
                {
                    if (sad[j, i] == 0)
                        sad[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}
