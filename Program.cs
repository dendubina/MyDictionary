using System;

namespace Dictionary
{    
    public class Program
    {        
        static void Main(string[] args)
        {            
            const int NodesCount = 100000000; // 100kk записей для каждой коллекции                
            Random rnd = new Random();             
            int keyToFind = rnd.Next(0, NodesCount);

            Console.WriteLine("Started \r\n");            

            Counter.CountFillingAndSerchingDictionary(NodesCount, keyToFind);
            Console.WriteLine();
            Counter.CountFillingAndSerchingMyDictionary(NodesCount, keyToFind);
            Console.WriteLine();
            Counter.CountFillingAndSerchingArray(NodesCount, keyToFind);
            Console.WriteLine();

            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}
