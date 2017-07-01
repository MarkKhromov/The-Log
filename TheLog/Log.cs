using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using TheLog.Providers.Base;

namespace TheLog {
    public sealed class Log<TMessage, TColor> {
        public static Log<TMessage, TColor> Get() {
            if(Instance == null) {
                throw new InvalidOperationException();
            }
            return Instance;
        }

        public static Log<TMessage, TColor> Create(IMessageProvider<TMessage> messageProvider, IColorProvider<TColor> colorProvider) {
            return Instance = new Log<TMessage, TColor>(messageProvider, colorProvider);
        }

        static Log<TMessage, TColor> Instance;

        Log(IMessageProvider<TMessage> messageProvider, IColorProvider<TColor> colorProvider) {
            this.messageProvider = messageProvider;
            this.colorProvider = colorProvider;
            Instance = this;
        }

        public readonly LogSettings Settings = new LogSettings();
        public readonly LogHistory History = new LogHistory();

        readonly IMessageProvider<TMessage> messageProvider;
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

        // TODO: Refactoring.
        void ShowMessageCore(out DateTime? time, string messageText, TColor color) {
            time = null;
            var currentColor = colorProvider.GetCurrentColor();
            if(Settings.ShowMessageTime) {
                var message = messageProvider.CreateMessage($"{(time = DateTime.Now).Value.ToString(Settings.MessageTimeFormat, CultureInfo.InvariantCulture)}: ");
                messageProvider.ShowMessage(message);
            }
            colorProvider.SetColor(color);
            messageProvider.ShowMessageLine(messageProvider.CreateMessage(messageText));
            colorProvider.SetColor(currentColor);
        }
    }
}