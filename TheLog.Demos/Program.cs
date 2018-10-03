using System;
using System.Threading;
using TheLog.Extensions;
using TheLog.Providers;

namespace TheLog.Demos {
    class Program {
        internal static Log<string, ConsoleColor> Log = Log<string, ConsoleColor>.Create(new ConsoleMessageProvider(), new ConsoleColorProvider());

        static void Main(string[] args) {
            "Default message".Default(Log);
            "Success message".Success(Log);
            "Error message".Error(Log);
            "Info message".Info(Log);
            "Warning message".Warning(Log);

            Log.ShowMessage<DataContainer<int, Data<string>>>("Start initializing", MessageType.Info);
            new DataContainer<int, Data<string>>();
            Console.ReadKey();
        }

        static void Sleep(int seconds) { Thread.Sleep(TimeSpan.FromSeconds(seconds)); }
    }
}