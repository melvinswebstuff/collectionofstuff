using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            StartSomethingAsync();
            Console.Read();
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
                        Console.WriteLine(String.Format("Length: {0}", length));
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
    }
}
