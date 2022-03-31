using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Dictionary
{    
    public class Program
    {
        // проверка скорости заполнения стандартного словаря, своего словаря и простого массива для наглядного сравнения
        static void Main(string[] args)
        {            
            const int NodesCount = 100000000; // 100kk записей для каждой коллекции                
            Random rnd = new Random();             
            int keyToFind = rnd.Next(0, NodesCount);

            Console.WriteLine("Started \r\n");            

            CountFillingAndSerchingDictionary();
            Console.WriteLine();
            CountFillingAndSerchingMyDictionary();
            Console.WriteLine();
            CountFillingAndSerchingArray();
            Console.WriteLine();


            Console.WriteLine("Finished");
            Console.ReadLine();


            void WriteElapsedTime(string text, TimeSpan ts)
            {
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
                Console.WriteLine(text + elapsedTime);
            }
           
            void CountFillingAndSerchingDictionary(int valuesCount = NodesCount)
            {
                Stopwatch stopwatch = new();
                Dictionary<int, int> dictionary = new();

                stopwatch.Start();

                for (int i = 0; i < valuesCount; i++)
                {
                    dictionary.Add(i, rnd.Next());
                }

                stopwatch.Stop();
                WriteElapsedTime("Dictionary filling runtime: ", stopwatch.Elapsed);

                stopwatch.Restart();
                int value = dictionary[keyToFind];
                stopwatch.Stop();
                WriteElapsedTime("Dictionary searching runtime: ", stopwatch.Elapsed);
            }

            void CountFillingAndSerchingMyDictionary(int valuesCount = NodesCount)
            {
                Stopwatch stopwatch = new();
                MyDictionary<int, int> mydict = new();

                stopwatch.Start();

                for (int i = 0; i < valuesCount; i++)
                {
                    mydict.Add(i, rnd.Next());
                }

                stopwatch.Stop();
                WriteElapsedTime("Custom dictionary filling runtime: ", stopwatch.Elapsed);

                stopwatch.Restart();
                int value = mydict[keyToFind];
                stopwatch.Stop();
                WriteElapsedTime("Custom dictionary searching runtime: ", stopwatch.Elapsed);
            }

            void CountFillingAndSerchingArray(int valuesCount = NodesCount)
            {
                int[] anArray = new int[valuesCount];
                Stopwatch stopwatch = new();

                stopwatch.Start();

                for (int i = 0; i < valuesCount; i++)
                {
                    anArray[i] = rnd.Next();
                }

                stopwatch.Stop();
                WriteElapsedTime("Array filling runtime: ", stopwatch.Elapsed);

                stopwatch.Restart();
                for (int i = 0; i < keyToFind; i++)
                {

                }
                stopwatch.Stop();
                WriteElapsedTime("Array searching runtime: ", stopwatch.Elapsed);
            }           

        }
    }
}
