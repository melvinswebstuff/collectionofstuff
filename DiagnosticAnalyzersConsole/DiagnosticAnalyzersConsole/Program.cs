using Microsoft.Security.Application;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace DiagnosticAnalyzersConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new B();
            foo();
            StartSomethingAsync();
            foreach (var item in GetDuplicates(new int[] { 3, 5, 5, 8, 9, 9, 9 }))
            {
                Console.WriteLine(item);
            }
           
            Console.Read();
        }

        private static void foo()
        {
            var js = "<script>alert('xss')</script>";
            var jsEncode = Encoder.JavaScriptEncode(js);
            var htmlEncode = Encoder.HtmlEncode(js);
            var bothEncoded = Encoder.HtmlEncode(Encoder.JavaScriptEncode(js));
            
        }

        public class B
        {
            public B() { }
            public string Foo(int pos)
            {
                return null;
            }
        }

        private static async void StartSomethingAsync()
        {
            try
            {
                Task.Factory.StartNew(() => ExampleMethodAsync());
                Console.WriteLine("Set length.\n");
                int length = await ExampleMethodAsync();
                // Note that you could put "await ExampleMethodAsync()" in the next line where
                // "length" is, but due to when '+=' fetches the value of ResultsTextBox, you
                // would not see the global side effect of ExampleMethodAsync setting the text.
                Console.WriteLine(String.Format("Length: {0}\n", length));
            }
            catch (Exception)
            {
                // Process the exception if one occurs.
            }
        }

        public static async Task<int> ExampleMethodAsync(bool )
        {
            Console.WriteLine(string.Format("Preparing to start ExampleMethodAsync.\n", ));
            var httpClient = new HttpClient();            
            int exampleInt = (await httpClient.GetStringAsync("http://msdn.microsoft.com")).Length;
            Console.WriteLine("Preparing to finish ExampleMethodAsync.\n");
            // After the following return statement, any method that's awaiting
            // ExampleMethodAsync (in this case, StartButton_Click) can get the 
            // integer result.
            return exampleInt;
        }

        public static int[] GetDuplicates(int[] a)
        {
            List<int> duplicates = new List<int>();

            foreach (int i in a)
            {
                if (a.Count(number => number == i) > 1 && !duplicates.Contains(i))
                {
                    duplicates.Add(i);
                }
            }
            return duplicates.ToArray();
        }
    }
}
