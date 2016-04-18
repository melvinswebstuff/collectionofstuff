using System;
using System.Threading;

namespace PublicRestroom
{
    class BathroomStall
    {
        object baton = new object();
        public void BeUsed()
        {
            lock (baton)
            {
                Console.WriteLine("Doing our thing...");

            }
        }

        public void FlushToilet()
        {
            lock (baton)
            {
                Console.WriteLine("Flushing the toilet...");
            }
        }
    }
    class PublicRestroom
    {
        object batonStall1 = new object();
        object batonStall2 = new object();
        object batonSink1 = new object();
        object batonSink2 = new object();
        public void UseStall1()
        {
            lock (batonStall1)
            {
                Console.WriteLine("In stall 1 ");
                Thread.Sleep(2000);
            }
        }
        public void UseStall2()
        {
            lock (batonStall2)
            {
                Console.WriteLine("In stall 2 ");
                Thread.Sleep(2000);
            }
        }
        public void UseSink1()
        {
            lock (batonSink1)
            {
                Console.WriteLine("In sink 1 ");
                Thread.Sleep(2000);
            }
        }
        public void UseSink2()
        {
            lock (batonSink2)
            {
                Console.WriteLine("In sink 2 ");
                Thread.Sleep(2000);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PublicRestroom pr = new PublicRestroom();
            new Thread(pr.UseStall1).Start();
            new Thread(pr.UseStall2).Start();
            new Thread(pr.UseSink1).Start();
            new Thread(pr.UseSink2).Start();
            Console.Read();
        }
    }
}
