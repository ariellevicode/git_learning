using System;
using System.Threading;
namespace multithreading
{
	class Program
	{
		public static void Main(string[] args)
		{
			Thread mainThread = Thread.CurrentThread;
			mainThread.Name = "main";
			Console.WriteLine(mainThread.Name);
			Thread t1 = new Thread(Countdown);
			Thread t2 = new Thread(Countup);
			t1.Start();
			t2.Start();

            Console.WriteLine(mainThread.Name + " is complete!");

            Console.ReadKey();
        }
		public static void Countup()
		{
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("timer #1:" + i + "seconds");
				Thread.Sleep(1000);
			}
			Console.WriteLine("timer #1 complete");


		}
        public static void Countdown()
        {
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine("timer #2:" + i + "seconds");
                Thread.Sleep(1000);
            }
            Console.WriteLine("timer #2 complete");


        }
    }

}