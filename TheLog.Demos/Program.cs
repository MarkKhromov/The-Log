using System;
using TheLog.Extensions;

namespace TheLog.Demos {
    class Program {
        static void Main(string[] args) {
            "Default message".Default();
            "Success message".Success();
            "Error message".Error();
            "Info message".Info();
            "Warning message".Warning();

            Log.Settings.ShowMessageTime = false;
            Log.ShowMessage<DataContainer<int, Data<string>>>("Start initializing", MessageType.Info);
            new DataContainer<int, Data<string>>();
            Console.ReadKey();
        }
    }
}