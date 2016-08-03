using System;

namespace AccessModifiers
{
    public class publicClass<a, b, c, d, e>
    {
        private a _private;
        protected b _protected;
        internal c _internal;
        protected internal d _protectedInternal;
        public e _public;

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
        static void Main(string[] args)
        {
            publicClass<string, string, int, int, bool> pc = new publicClass<string, string, int, int, bool>("a", "b", 1, 2);
            pc._internal = 9;
            pc._protectedInternal = 10;
            pc._public = true;

            Console.WriteLine(pc._internal);
            Console.WriteLine(pc._protectedInternal);
            Console.ReadKey();
        }
    }
}