﻿using System;
using System.Globalization;
using System.IO;
using System.Text;
using TheLog.Providers.Base;
using TheLog.Settings;

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
        public readonly LogHistory<TMessage> History = new LogHistory<TMessage>();

        readonly IMessageProvider<TMessage> messageProvider;
        readonly IColorProvider<TColor> colorProvider;

        public void ShowMessage<T>(T obj, TMessage message, MessageType messageType) {
            ShowMessage<T>(message, messageType);
        }

        public void ShowMessage<T>(TMessage message, MessageType messageType) {
            var messageText = messageProvider.GetMessageText(message);
            ShowMessage(messageProvider.CreateMessage($"{StringConverter.ConvertToString<T>()} - {messageText}"), messageType);
        }

        public void ShowMessage(TMessage message, MessageType messageType) {
            lock(this) {
                DateTime? time = null;
                var color = colorProvider.GetColor(messageType);
                var currentColor = colorProvider.GetCurrentColor();
                if(Settings.ShowMessageTime) {
                    time = DateTime.Now;
                    var timeString = time.Value.ToString(Settings.MessageTimeFormat, CultureInfo.InvariantCulture);
                    var timeMessage = messageProvider.CreateMessage($"{timeString}{Settings.MessageTimeSeparator}");
                    messageProvider.ShowMessage(timeMessage);
                }
                colorProvider.SetColor(color);
                messageProvider.ShowMessageLine(message);
                colorProvider.SetColor(currentColor);
                if(Settings.EnableHistory) {
                    History.Add(time, message, messageType);
                }
                if(Settings.FileSettings.AllowWriteToFile) {
                    using(var streamWriter = new StreamWriter(Settings.FileSettings.FileName, true, Encoding.UTF8))
                    using(var synchronizedTextWriter = TextWriter.Synchronized(streamWriter)) {
                        synchronizedTextWriter.WriteLine(message);
                    }
                }
            }
        }
    }
}