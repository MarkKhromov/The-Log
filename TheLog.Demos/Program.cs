using System;

namespace TheLog.Demos {
    class Program {
        static void Main(string[] args) {
            Log.ShowMessage("Default message", MessageType.Default);
            Log.ShowMessage("Success message", MessageType.Success);
            Log.ShowMessage("Error message", MessageType.Error);
            Log.ShowMessage("Info message", MessageType.Info);
            Log.ShowMessage("Warning message", MessageType.Warning);

            Log.Settings.ShowMessageTime = false;
            Log.ShowMessage<DataContainer<int, Data<string>>>("Start initializing", MessageType.Info);
            new DataContainer<int, Data<string>>();
            Console.ReadKey();
        }
    }
}