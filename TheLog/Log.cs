using System;

namespace TheLog {
    public static class Log {
        public static void ShowMessage<T>(T obj, string message, MessageType messageType) {
            ShowMessage<T>(message, messageType);
        }

        public static void ShowMessage<T>(string message, MessageType messageType) {
            ShowMessage($"{StringConverter.ConvertToString<T>()} - {message}", messageType);
        }

        public static void ShowMessage(string message, MessageType messageType) {
            switch(messageType) {
                case MessageType.Default:
                    ShowMessageCore(message, ConsoleColor.Gray);
                    break;
                case MessageType.Error:
                    Error(message);
                    break;
                case MessageType.Info:
                    Info(message);
                    break;
                case MessageType.Success:
                    Success(message);
                    break;
                case MessageType.Warning:
                    Warning(message);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public static void Success(string message) {
            ShowMessageCore(message, ConsoleColor.Green);
        }

        public static void Warning(string message) {
            ShowMessageCore(message, ConsoleColor.Yellow);
        }

        public static void Error(string message) {
            ShowMessageCore(message, ConsoleColor.Red);
        }

        public static void Info(string message) {
            ShowMessageCore(message, ConsoleColor.Cyan);
        }

        static void ShowMessageCore(string message, ConsoleColor consoleColor) {
            var oldConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ForegroundColor = oldConsoleColor;
        }
    }
}