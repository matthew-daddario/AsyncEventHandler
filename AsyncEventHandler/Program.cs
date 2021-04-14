using System;
using System.Threading.Tasks;

namespace AsyncEventHandler
{
    class Program
    {
        static event AsyncEventHandler MyEvent;

        static async Task Main(string[] _)
        {
            MyEvent += OnMyEvent;
            await MyEvent.InvokeAndWaitAsync();
            Console.WriteLine("All delegates have completed.");

            Console.ReadLine();
        }

        private static async Task OnMyEvent()
        {
            Console.WriteLine("Delegate is invoked");
            await Task.Delay(5_000);
            Console.WriteLine("Async operation in delegate is completed");
        }
    }
}
