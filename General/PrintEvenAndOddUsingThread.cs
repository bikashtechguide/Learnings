using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Study
{
    public class PrintEvenAndOddUsingThread
    {
        public delegate void testDelegate();
        public delegate void testDelegate1(int a);

        PrintEvenAndOddUsingThread t = new PrintEvenAndOddUsingThread();

       // testDelegate1 evenNumber = new testDelegate1(t.EvenNumbers1);
        Thread evenThread = new Thread(EvenNumbers);
        Thread oddThread = new Thread(OddNumbers);

        static void EvenNumbers()
        {
            for (int i = 10; i > 0; i--)
            {
                if (i % 2 == 0)
                    Console.WriteLine($"Even number {i}");
            }
        }

        static void OddNumbers()
        {
            for (int i = 10; i > 0; i--)
            {
                if (i % 2 != 0)
                    Console.WriteLine($"Odd number {i}");
            }
        }
        public void EvenNumbers1(int a)
        {
            for (int i = 10; i > 0; i--)
            {
                if (i % 2 == 0)
                    Console.WriteLine($"Even number {i}");
            }
        }
    }

}
