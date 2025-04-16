using TestLab1Sort;

/// <summary>
/// ВНИМАНИЕ ЛУЧШАЯ СОРТИРОВКА ЧТО ВЫ ВИДЕЛИ!!!
/// ВЗЯТА ОТСЮДА: https://habr.com/ru/articles/198114/
/// </summary>

namespace MySortingProject
{
    /// <summary>
    /// Сортировщик, реализующий bogosort.
    /// В конструкторе можно передать свою реализацию IShuffler для упрощения тестирования.
    /// </summary>
    public class Sorter : ISorter
    {
        private readonly IShuffler _shuffler;

        // Если shuffler не передан – используется RealShuffler.
        public Sorter(IShuffler shuffler = null)
        {
            _shuffler = shuffler ?? new RealShuffler();
        }

        public int[] Sort(int[] array)
        {
            // Если массив пуст или содержит один элемент, он уже отсортирован.
            if (array.Length <= 1)
                return array;
            return BogoSort(array);
        }

        private int[] BogoSort(int[] array)
        {
            // Проводим перемешивание, пока массив не будет отсортирован.
            while (!IsSorted(array))
            {
                _shuffler.Shuffle(array);
            }
            return array;
        }

        private bool IsSorted(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                    return false;
            }
            return true;
        }
    }
}
