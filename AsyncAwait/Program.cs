using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static byte[] values = new byte[500000000];
        static long[] portionResults;
        static int portionSize;
        static int processorCnt = Environment.ProcessorCount;
        static MySchronizedQueue<int> numbers = new MySchronizedQueue<int>();
        const int numThreads = 3;
        static int[] sums = new int[numThreads];

        static void Main(string[] args)
        {
            portionResults = new long[processorCnt];
            portionSize = values.Length / processorCnt;
            //StartSomethingAsync();
            //GenerateInts();
            ProduceSumNumbers();
            Console.Read();
        }

        private static void ProduceSumNumbers()
        {
            var producingThread = new Thread(ProduceNumbers);
            producingThread.Start();
            Thread[] threads = new Thread[numThreads];

            for (int i = 0; i < numThreads; i++)
            {
                threads[i] = new Thread(SumNumbers);
                threads[i].Start(i);
            }

            for (int i = 0; i < numThreads; i++)
            {
                threads[i].Join();
            }

            int totalSum = 0;

            for (int i = 0; i < numThreads; i++)
            {
                totalSum += sums[i];
            }

            Console.WriteLine("Done adding. Total is " + totalSum);
        }

        static void SumYourPortion(object portionNumber)
        {
            long sum = 0;
            int portionNumberAsInt = (int)portionNumber;
            int baseIndex = portionNumberAsInt * portionSize;

            for (int i = baseIndex; i < baseIndex + portionSize; i++)
            {
                sum += values[i];
            }

            portionResults[portionNumberAsInt] = sum;
        }

        private static void GenerateInts()
        {
            Stopwatch sw = new Stopwatch();
            Random rand = new Random(987);
            long total1 = 0;

            sw.Start();


            for (int i = 0; i < values.Length; i++)
            {
                values[i] = (byte)rand.Next(10);
            }

            sw.Stop();

            Console.WriteLine("Random numbers generated..." + sw.Elapsed.TotalSeconds);

            sw.Reset();
            sw.Start();

            for (int i = 0; i < values.Length; i++)
            {
                total1 += values[i];
            }

            sw.Stop();

            Console.WriteLine(total1 + "...Sum of random numbers..." + sw.Elapsed);

            sw.Reset();
            sw.Start();

            Thread[] threads = new Thread[processorCnt];

            for (int i = 0; i < processorCnt; i++)
            {
                threads[i] = new Thread(SumYourPortion);
                threads[i].Start(i);
            }

            for (int i = 0; i < processorCnt; i++)
            {
                threads[i].Join();
            }
            long total2 = 0;
            for (int i = 0; i < processorCnt; i++)
            {
                total2 += portionResults[i];
            }

            sw.Stop();
            Console.WriteLine(total2 + "...Sum of random numbers..." + sw.Elapsed);
        }

        private static async void StartSomethingAsync()
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    Task.Factory.StartNew(() => ExampleMethodAsync(false));

                    for (int j = 0; j < 10; j++)
                    {
                        int length = await ExampleMethodAsync(true);
                        // Note that you could put "await ExampleMethodAsync()" in the next line where
                        // "length" is, but due to when '+=' fetches the value of ResultsTextBox, you
                        // would not see the global side effect of ExampleMethodAsync setting the text.
                        Console.WriteLine("Length: {0}" + length);
                    }
                }



            }
            catch (Exception)
            {
                // Process the exception if one occurs.
            }
        }

        public static async Task<int> ExampleMethodAsync(bool IsUsingAwait)
        {
            int exampleInt = 0;

            Console.WriteLine(string.Format("Start ExampleMethodAsync. Await is {0}", IsUsingAwait));
            var httpClient = new HttpClient();
            if (IsUsingAwait)
            {
                exampleInt = (await httpClient.GetStringAsync("http://msdn.microsoft.com")).Length;
            }
            else
            {
                Loop();
            }
            Console.WriteLine(string.Format("Finish ExampleMethodAsync. Await is {0}", IsUsingAwait));
            // After the following return statement, any method that's awaiting
            // ExampleMethodAsync (in this case, StartSomethingAsync) can get the 
            // integer result.
            return exampleInt;
        }

        private static void Loop()
        {
            string s = "5";
            int t = Convert.ToInt32(s);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void ProduceNumbers()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Random rand = new Random(987);
            for (int i = 0; i < 10; i++)
            {
                int numToEnqueue = rand.Next(10);
                lock (numbers)
                {
                    numbers.Enqueue(numToEnqueue);
                }
                Console.WriteLine("Producing thread adding " + numToEnqueue + " to the queue");
                Thread.Sleep(rand.Next(1000));
            }
            sw.Stop();
            Console.WriteLine("ProducedNumbers: " + sw.Elapsed);
        }

        static void SumNumbers(object threadNumber)
        {
            DateTime startTime = DateTime.Now;
            int mySum = 0;
            Stopwatch sw = new Stopwatch();

            sw.Start();

            while ((DateTime.Now - startTime).Seconds < 11)
            {
                int numToSum = -1;
                lock (numbers.SyncRoot)
                {
                    if (numbers.Count != 0)
                    {
                        numToSum = numbers.Dequeue();
                    }
                }

                if (numToSum != -1)
                {
                    mySum += numToSum;
                    Console.WriteLine("Consuming thread #" + threadNumber + " adding " + numToSum + " to its total sum making " + mySum + " for the thread total.");
                }
            }

            sw.Stop();
            Console.WriteLine("SumNumbers on thread # " + threadNumber + " took " + sw.Elapsed);

            sums[(int)threadNumber] = mySum;
        }
    }
}

class MySchronizedQueue<T>
{
    object baton = new object();
    Queue<T> theQ = new Queue<T>();
    public void Enqueue(T item)
    {

        lock(baton) theQ.Enqueue(item);
    }
    public T Dequeue()
    {
        lock (baton)  return theQ.Dequeue();
    }
    public int Count
    {
        get { lock (baton)  return theQ.Count; }
    }
    public object SyncRoot
    {
        get { return baton; }
    }
}