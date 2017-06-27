using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using TheLog.Providers.Base;

namespace TheLog {
    public sealed class Log<TColor> {
        public static Log<TColor> Get() {
            if(Instance == null) {
                throw new InvalidOperationException();
            }
            return Instance;
        }

        public static Log<TColor> Create(IMessageProvider messageProvider, IColorProvider<TColor> colorProvider) {
            return Instance = new Log<TColor>(messageProvider, colorProvider);
        }

        static Log<TColor> Instance;

        Log(IMessageProvider messageProvider, IColorProvider<TColor> colorProvider) {
            this.messageProvider = messageProvider;
            this.colorProvider = colorProvider;
            Instance = this;
        }

        public readonly LogSettings Settings = new LogSettings();
        public readonly LogHistory History = new LogHistory();

        readonly IMessageProvider messageProvider;
        readonly IColorProvider<TColor> colorProvider;

        public void ShowMessage<T>(T obj, string message, MessageType messageType) {
            ShowMessage<T>(message, messageType);
        }

        public void ShowMessage<T>(string message, MessageType messageType) {
            ShowMessage($"{StringConverter.ConvertToString<T>()} - {message}", messageType);
        }

        public void ShowMessage(string message, MessageType messageType) {
            DateTime? time;
            var color = colorProvider.GetColor(messageType);
            ShowMessageCore(out time, message, color);
            if(Settings.EnableHistory) {
                History.Add(time, message, messageType);
            }
        }

        public void ShowExecutionTime(Expression<Action> action) {
            var stopWatch = Stopwatch.StartNew();
            action.Compile()();
            stopWatch.Stop();
            var actionString = StringConverter.ConvertToString(action);
            ShowMessage($"{actionString} ({stopWatch.Elapsed.ToString(Settings.ExecutionTimeFormat, CultureInfo.InvariantCulture)})", MessageType.Default);
        }

        void ShowMessageCore(out DateTime? time, string message, TColor color) {
            time = null;
            var currentColor = colorProvider.GetCurrentColor();
            if(Settings.ShowMessageTime) {
                messageProvider.ShowMessage($"{(time = DateTime.Now).Value.ToString(Settings.MessageTimeFormat, CultureInfo.InvariantCulture)}: ");
            }
            colorProvider.SetColor(color);
            messageProvider.ShowMessageLine(message);
            colorProvider.SetColor(currentColor);
        }
    }
}