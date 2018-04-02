using System;

namespace MathForProgrammers
{
    class Program
    {
        static void Main(string[] args)
        {
            uint x = 4000000000;
            uint y = 4000000000;
            uint z = x + y;
            long a = x;
            long b = y;
            long c = a + b;

            Console.WriteLine("x = " + x);
            Console.WriteLine("y = " + y);
            Console.WriteLine("z = " + z);

            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("c = " + c);
            Console.WriteLine(100 - (-100));
            Console.Read();

            var l = new byte[] { 255, 0, 3, 4, 5, 6, 7, 8 };
            int h = 16 >> 4; //shifting
        }

        private string AddValuesAndDescribeResult(byte b1, byte b2)
        {
            ushort result = (ushort)(b1 + b2);
            if (result > byte.MaxValue || result > byte.MinValue)
            {
                return "The sum is out of range for the byte";
            }

            return "Result is " + (byte)result;
        }
    }
}
