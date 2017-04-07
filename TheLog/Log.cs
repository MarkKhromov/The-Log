using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;

namespace TheLog {
    public static class Log {
        public static readonly LogSettings Settings = new LogSettings();

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
                    ShowMessageCore(message, ConsoleColor.Red);
                    break;
                case MessageType.Info:
                    ShowMessageCore(message, ConsoleColor.Cyan);
                    break;
                case MessageType.Success:
                    ShowMessageCore(message, ConsoleColor.Green);
                    break;
                case MessageType.Warning:
                    ShowMessageCore(message, ConsoleColor.Yellow);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public static void ShowExecutionTime(Expression<Action> action) {
            var stopWatch = Stopwatch.StartNew();
            action.Compile()();
            stopWatch.Stop();
            var actionString = StringConverter.ConvertToString(action);
            ShowMessage($"{actionString} ({stopWatch.Elapsed.ToString(@"mm\:ss\.fff", CultureInfo.InvariantCulture)})", MessageType.Default);
        }

        static void ShowMessageCore(string message, ConsoleColor consoleColor) {
            var oldConsoleColor = Console.ForegroundColor;
            if(Settings.ShowMessageTime) {
                Console.Write($"{DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture)}: ");
            }
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            Console.ForegroundColor = oldConsoleColor;
        }
    }
}