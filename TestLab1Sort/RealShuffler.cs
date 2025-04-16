using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLab1Sort;

namespace MySortingProject
{
    public class RealShuffler : IShuffler
    {
        private Random _random = new Random();

        public void Shuffle(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = _random.Next(0, i + 1);
                // Меняем местами элементы
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}
