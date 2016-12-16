using log4net;
using NLog;
using System;
using System.IO;
using System.Threading;

namespace AccessModifiers
{
    public class publicClass<a, b, c, d, e>
    {
        private a _private;
        private b _protected;
        private c _internal;
        private d _protectedInternal;
        private e _public;

        private a myprivate
        {
            get { return _private; }
            set { _private = value; Console.WriteLine(value); }
        }
        protected b myprotected
        {
            get { return _protected; }
            set { _protected = value; Console.WriteLine(value); }
        }
        internal c myinternal
        {
            get { return _internal; }
            set { _internal = value; Console.WriteLine(value); }
        }
        protected internal d myprotectedInternal
        {
            get { return _protectedInternal; }
            set { _protectedInternal = value; Console.WriteLine(value); }
        }
        public e mypublic
        {
            get { return _public; }
            set { _public = value; Console.WriteLine(value); }
        }

        public publicClass()
        {

        }

        public publicClass(a priv, b prot, c inter, d protinter)
        {
            _private = priv;
            _protected = prot;
            _internal = inter;
            _protectedInternal = protinter;

            Console.WriteLine(_private);
            Console.WriteLine(_protected);
            Console.WriteLine(_internal);
            Console.WriteLine(_protectedInternal);
            Console.WriteLine(_public);
        }
    }



    class Program
    {
        private static ILog logger1 = log4net.LogManager.GetLogger(typeof(Program));
        private static ILogger logger2 = NLog.LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            TimeSpan log4netTime, nlogTime;

            publicClass<string, string, int, int, bool> pc = new publicClass<string, string, int, int, bool>("a", "b", 1, 2);
            pc.myinternal = 9;
            pc.myprotectedInternal = 10;
            pc.mypublic = true;

            Console.WriteLine(pc.myinternal);
            Console.WriteLine(pc.myprotectedInternal);

            sw.Start();

            for (int i = 0; i < 1; i++)
            {
                logger1.Debug("log4net logging");
                logger1.Info("log4net logging");
            }

            sw.Stop();
            log4netTime = sw.Elapsed;
            sw.Restart();


            for (int i = 0; i < 1; i++)
            {
                logger2.Debug("nlog logging");
                logger2.Info("nlog logging");
            }

            sw.Stop();
            nlogTime = sw.Elapsed;

            Console.WriteLine(log4netTime);
            Console.WriteLine(nlogTime);

            using (StreamWriter swriter = new StreamWriter(File.Create("StreamWritten.File.txt")))
            {
                swriter.WriteLine("Hello World!!!");
                Thread.Sleep(60000);
                swriter.Flush();
            }

            Console.ReadKey();
            bool result = StringHelper.IsValidPostalCode("asdfad");
            bool result2 = "asdfadf".IsValidPostalCode(); //Extension
            //IEnumerable<string> data;
            //data.ToList();//Available under the System.Linq namespace, this is an extension method




        }
    }

    static class StringHelper
    {
        public static bool IsValidPostalCode(this string postalCode)
        {
            return postalCode.Length == 5 || postalCode.Length == 9;
        }
    }
}