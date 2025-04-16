using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLab1Sort;

namespace TestLab1Sort
{
    /// <summary>
    /// Интерфейс для перемешивания массива.
    /// Позволяет в unit-тестах подменять реальное случайное перемешивание.
    /// </summary>
    public interface IShuffler
    {
        void Shuffle(int[] array);
    }
}

