using System;
using System.Threading;
using TheLog.Extensions;

namespace TheLog.Demos {
    class Program {
        static void Main(string[] args) {
            "Default message".Default();
            "Success message".Success();
            "Error message".Error();
            "Info message".Info();
            "Warning message".Warning();

            Log.ShowMessage<DataContainer<int, Data<string>>>("Start initializing", MessageType.Info);
            new DataContainer<int, Data<string>>();
            Log.ShowExecutionTime(() => Sleep(1));
            Console.ReadKey();
        }

        static void Sleep(int seconds) { Thread.Sleep(TimeSpan.FromSeconds(seconds)); }
    }
}