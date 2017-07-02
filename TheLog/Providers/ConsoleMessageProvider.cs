using System;
using TheLog.Providers.Base;

namespace TheLog.Providers {
    public class ConsoleMessageProvider : IMessageProvider<string> {
        string IMessageProvider<string>.CreateMessage(string messageText) {
            return messageText;
        }

        string IMessageProvider<string>.GetMessageText(string message) {
            return message;
        }

        void IMessageProvider<string>.ShowMessage(string message) {
            Console.Write(message);
        }

        void IMessageProvider<string>.ShowMessageLine(string message) {
            Console.WriteLine(message);
        }
    }
}