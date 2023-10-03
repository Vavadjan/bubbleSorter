using System.Threading.Channels;

namespace LbubbleSorter
{
    internal class Program
    {

        static void ShowArray(int limitArrayNumber, int[] rndArray)
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
            int limitArrayNumber = 10; // лимит колличество элементов в инициализаторе массива
            int minArrayNumber = Int32.MaxValue; // минимальное число массива 
            int minArrayNumberIndex = 0; // индекс минимального элемента в массиве
            int arrayBufferNumber; // буфер для временного хранения числа во время перемещения

            int[] rndArray = new int[limitArrayNumber];

            Random rndNumber = new Random(seedRndNumber);

            for (int i = 0; i < limitArrayNumber; i++)
            {
                rndArray[i] = rndNumber.Next(limitRndNumber);
                Console.Write(rndArray[i] + " ");
            }

            //96 15 66 90 35 94 71 61 34 14

            for (int x = 0; x < limitArrayNumber; x++)
            {
                Console.WriteLine("\n");
                minArrayNumber = Int32.MaxValue;

                for (int i = 0 + x; i < limitArrayNumber; i++)
                {
                    if (rndArray[i] < minArrayNumber)
                    {
                        minArrayNumber = (rndArray[i]);
                        minArrayNumberIndex = i;
                    }
                }

                if (minArrayNumber != rndArray[x])
                {
                    arrayBufferNumber = rndArray[minArrayNumberIndex];
                    rndArray[minArrayNumberIndex] = rndArray[x];
                    rndArray[x] = minArrayNumber;
                }

                Console.WriteLine("наименьшее число среди оставшихся - " + minArrayNumber);
                ShowArray(limitArrayNumber, rndArray);
            }
        }
    }
}