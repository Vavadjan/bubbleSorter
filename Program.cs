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
            int seedRndNumber = 1; // число seed
            int limitArrayNumber = 10; // лимит колличество элементов в инициализаторе массива
            int bufferNumber = Int32.MaxValue; // минимальное число массива 
            int minArrayNumberIndex = 0; // индекс минимального элемента в массиве
            int arrayBufferNumber; // буфер для временного хранения числа во время перемещения

            int[] rndArray = new int[limitArrayNumber]; // резервируем место в памяти под массив

            Random rndNumber = new Random(); // создаем генератор случайных чисел

            for (int i = 0; i < limitArrayNumber; i++) // блок заполнения массива случайными числами
            {
                rndArray[i] = rndNumber.Next(limitRndNumber);
                Console.Write(rndArray[i] + " ");
            }

            // 96 15 66 90 35 94 71 61 34 14

            for (int x = 0; x < limitArrayNumber; x++)
            {

                Console.WriteLine("\n"); // переход на новую строку
                bufferNumber = Int32.MaxValue; // сброс переменной minArrayNumber

                for (int i = 0 + x; i < limitArrayNumber; i++) // блок поиска наименьшего числа (из оставшихся в массиве)
                {
                    if (rndArray[i] < bufferNumber)
                    {
                        bufferNumber = (rndArray[i]);
                        minArrayNumberIndex = i;
                    }
                }

                if (bufferNumber != rndArray[x]) // блок перестановки местами элементов массива
                {
                    arrayBufferNumber = rndArray[minArrayNumberIndex];
                    rndArray[minArrayNumberIndex] = rndArray[x];
                    rndArray[x] = bufferNumber;
                }

                Console.WriteLine("наименьшее число среди оставшихся - " + bufferNumber); // выводим в консоль наименьшее число в данный момент
                ShowArray(limitArrayNumber, rndArray); // вызываем метод showArray
            }
        }
    }
}