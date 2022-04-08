using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public static class Counter
    {
        public static void CountFillingAndSerchingDictionary(int valuesCount, int keyToFind)
        {
            Stopwatch stopwatch = new();
            Random rnd = new();
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
        public static void CountFillingAndSerchingMyDictionary(int valuesCount, int keyToFind)
        {
            Stopwatch stopwatch = new();
            Random rnd = new();
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
        public static void CountFillingAndSerchingArray(int valuesCount, int keyToFind)
        {
            int[] anArray = new int[valuesCount];
            Random rnd = new();
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
        private static void WriteElapsedTime(string text, TimeSpan ts)
        {
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            Console.WriteLine(text + elapsedTime);
        }
    }
}
