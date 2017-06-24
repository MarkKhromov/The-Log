using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;

namespace TheLog {
    public static class Log {
        public static readonly LogSettings Settings = new LogSettings();
        public static readonly LogHistory History = new LogHistory();

        public static void ShowMessage<T>(T obj, string message, MessageType messageType) {
            ShowMessage<T>(message, messageType);
        }

        public static void ShowMessage<T>(string message, MessageType messageType) {
            ShowMessage($"{StringConverter.ConvertToString<T>()} - {message}", messageType);
        }

        public static void ShowMessage(string message, MessageType messageType) {
            switch(messageType) {
                case MessageType.Default:
                    ShowMessageCore(message, Console.ForegroundColor, messageType);
                    break;
                case MessageType.Error:
                    ShowMessageCore(message, ConsoleColor.Red, messageType);
                    break;
                case MessageType.Info:
                    ShowMessageCore(message, ConsoleColor.Cyan, messageType);
                    break;
                case MessageType.Success:
                    ShowMessageCore(message, ConsoleColor.Green, messageType);
                    break;
                case MessageType.Warning:
                    ShowMessageCore(message, ConsoleColor.Yellow, messageType);
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
            ShowMessage($"{actionString} ({stopWatch.Elapsed.ToString(Settings.ExecutionTimeFormat, CultureInfo.InvariantCulture)})", MessageType.Default);
        }

        // TODO: Refactoring. May be I can create something like a IColorProvider
        static void ShowMessageCore(string message, ConsoleColor consoleColor, MessageType messageType) {
            var oldConsoleColor = Console.ForegroundColor;
            DateTime? now = null;
            if(Settings.ShowMessageTime) {
                Console.Write($"{(now = DateTime.Now).Value.ToString(Settings.MessageTimeFormat, CultureInfo.InvariantCulture)}: ");
            }
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(message);
            if(Settings.EnableHistory) {
                History.Add(now, message, messageType);
            }
            Console.ForegroundColor = oldConsoleColor;
        }
    }
}