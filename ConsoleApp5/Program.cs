using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    static class Extensions
    {
        public static void Snake<T>(this T[,] arr, IEnumerable<T> sourceValues)
        {
            int m = arr.GetLength(0);
            int n = arr.GetLength(1);
            int maxCount = m * n;
            int mVector = 0;
            int nVector = 1;

            int mi = 0, ni = 0;

            foreach (var val in sourceValues.Take(maxCount))
            {
                arr[mi, ni] = val;
                mi += mVector;
                ni += nVector;
                if (nVector != 0)
                {
                    if (nVector < 0 && ni < m - mi)
                    {
                        mVector = -1;
                        nVector = 0;
                    }
                    if (nVector > 0 && ni >= n - mi - 1)
                    {
                        mVector = 1;
                        nVector = 0;
                    }
                }
                else if (mVector != 0)
                {
                    if (mVector < 0 && mi <= ni + 1)
                    {
                        mVector = 0;
                        nVector = 1;
                    }
                    if (mVector > 0 && mi > m - (n - ni) - 1)
                    {
                        mVector = 0;
                        nVector = -1;
                    }
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество строк: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов: ");
            int m = int.Parse(Console.ReadLine());

            int[,] arr = new int[n, m];
            arr.Snake(Enumerable.Range(1, n*m));
            for (int i = 0; i < arr.GetLength(0); i++, Console.WriteLine())
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write("{0,3}", arr[i, j]);
            Console.ReadKey();
        }
    }
}


/*          int a, line, column;

            Console.Write("Введите количество строк: ");
            int n = int.Parse(Console.ReadLine());  
            Console.Write("Введите количество столбцов: ");
            int m = int.Parse(Console.ReadLine());

            int[,] array = new int[n, m];
            int[,] arrayTwo = new int[n, m];

            Random rnd = new Random();

            Console.WriteLine("Исходный массив: ");

            for (int i = 0; i < array.GetLength(0); i++)
            {

                for (int j = 0; j < array.GetLength(1); j++)
                {

                    a = rnd.Next(0, 100);
                    array[i, j] = a;
                    Console.Write(array[i, j] + "\t");
                }

                Console.WriteLine();
            }

            line = rnd.Next(0, n);
            column = rnd.Next(0, m);

            Console.WriteLine($"\nИндекс столбца = {column} \nИндекс строки = {line}\n\nПолученный массив: ");
            
            for (int i = 0; i < arrayTwo.GetLength(0); i++)
            {
                if (i != line)
                {
                    for (int j = 0; j < arrayTwo.GetLength(1); j++)
                    {
                        if (j != column)
                        {
                            arrayTwo[i, j] = array[i, j];
                            Console.Write(arrayTwo[i, j] + "\t");
                        }
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
*/