using System;
using TheLog.Providers.Base;

namespace TheLog.Providers {
    public class ConsoleMessageProvider : IMessageProvider {
        void IMessageProvider.ShowMessage(string message) {
            Console.Write(message);
        }

        void IMessageProvider.ShowMessageLine(string message) {
            Console.WriteLine(message);
        }
    }
}