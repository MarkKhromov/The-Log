using System;
using System.Threading;
using TheLog.Extensions;
using TheLog.Providers;

namespace TheLog.Demos {
    class Program {
        internal static Log<ConsoleColor> Log = Log<ConsoleColor>.Create(new ConsoleMessageProvider(), new ConsoleColorProvider());

        static void Main(string[] args) {
            "Default message".Default<ConsoleColor>();
            "Success message".Success<ConsoleColor>();
            "Error message".Error<ConsoleColor>();
            "Info message".Info<ConsoleColor>();
            "Warning message".Warning<ConsoleColor>();

            Log.ShowMessage<DataContainer<int, Data<string>>>("Start initializing", MessageType.Info);
            new DataContainer<int, Data<string>>();
            Log.ShowExecutionTime(() => Sleep(1));
            Console.ReadKey();
        }

        static void Sleep(int seconds) { Thread.Sleep(TimeSpan.FromSeconds(seconds)); }
    }
}