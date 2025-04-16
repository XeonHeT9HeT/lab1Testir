using System;
using System.Diagnostics;
using TestLab1Sort;

namespace MySortingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ISorter sorter = new Sorter();
            int[] array = { 5, 3, 8, 1, 2 };

            Console.WriteLine("Исходный массив: " + string.Join(", ", array));

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int[] sortedArray = sorter.Sort(array);

            stopwatch.Stop();

            Console.WriteLine("Отсортированный массив: " + string.Join(", ", sortedArray));
            Console.WriteLine("Время выполнения: " + stopwatch.ElapsedMilliseconds + " мс");
        }
    }
}
