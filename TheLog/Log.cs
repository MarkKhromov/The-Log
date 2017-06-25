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
            DateTime? time;
            var color = Settings.ColorProvider.GetColor(messageType);
            ShowMessageCore(out time, message, color);
            if(Settings.EnableHistory) {
                History.Add(time, message, messageType);
            }
        }

        public static void ShowExecutionTime(Expression<Action> action) {
            var stopWatch = Stopwatch.StartNew();
            action.Compile()();
            stopWatch.Stop();
            var actionString = StringConverter.ConvertToString(action);
            ShowMessage($"{actionString} ({stopWatch.Elapsed.ToString(Settings.ExecutionTimeFormat, CultureInfo.InvariantCulture)})", MessageType.Default);
        }

        // TODO: Make color as generic template type
        static void ShowMessageCore(out DateTime? time, string message, object color) {
            time = null;
            var currentColor = Settings.ColorProvider.GetCurrentColor();
            if(Settings.ShowMessageTime) {
                Settings.MessageProvider.ShowMessage($"{(time = DateTime.Now).Value.ToString(Settings.MessageTimeFormat, CultureInfo.InvariantCulture)}: ");
            }
            Settings.ColorProvider.SetColor(color);
            Settings.MessageProvider.ShowMessageLine(message);
            Settings.ColorProvider.SetColor(currentColor);
        }
    }
}