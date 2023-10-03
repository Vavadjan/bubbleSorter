using System.Threading.Channels;

namespace LbubbleSorter
{
    internal class Program
    {

        static void ShowArray(int limitArrayNumber, int[] rndArray) // создаем метод который выводит в консоль содержимое массива через пробел в строчку
        {
            for (int i = 0; i < limitArrayNumber; i++)
            {
                Console.Write(rndArray[i] + " ");
            }
        }


        static void Main(string[] args)
        {
            int limitRndNumber = 100; // верхний предел лимита генератора псевдослучайных чисел
            int seedRndNumber = 100; // число seed
            int limitArrayNumber = 300; // лимит колличество элементов в инициализаторе массива
            int minArrayNumber = Int32.MaxValue; // минимальное число массива 
            int minArrayNumberIndex = 0; // индекс минимального элемента в массиве
            int arrayBufferNumber; // буфер для временного хранения числа во время перемещения

            int[] rndArray = new int[limitArrayNumber]; // резервируем место в памяти под массив

            Random rndNumber = new Random(seedRndNumber); // создаем генератор случайных чисел

            for (int i = 0; i < limitArrayNumber; i++) // блок заполнения массива случайными числами
            {
                rndArray[i] = rndNumber.Next(limitRndNumber);
                Console.Write(rndArray[i] + " ");
            }

            // 96 15 66 90 35 94 71 61 34 14

            for (int x = 0; x < limitArrayNumber; x++)
            {
                Console.WriteLine("\n"); // переход на новую строку
                minArrayNumber = Int32.MaxValue; // сброс переменной minArrayNumber

                for (int i = 0 + x; i < limitArrayNumber; i++) // блок поиска наименьшего числа (из оставшихся в массиве)
                {
                    if (rndArray[i] < minArrayNumber)
                    {
                        minArrayNumber = (rndArray[i]);
                        minArrayNumberIndex = i;
                    }
                }

                if (minArrayNumber != rndArray[x]) // блок перестановки местами элементов массива
                {
                    arrayBufferNumber = rndArray[minArrayNumberIndex];
                    rndArray[minArrayNumberIndex] = rndArray[x];
                    rndArray[x] = minArrayNumber;
                }

                Console.WriteLine("наименьшее число среди оставшихся - " + minArrayNumber); // выводим в консоль наименьшее число в данный момент
                ShowArray(limitArrayNumber, rndArray); // вызываем метод showArray
            }
        }
    }
}