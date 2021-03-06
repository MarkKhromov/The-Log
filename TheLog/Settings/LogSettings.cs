﻿namespace TheLog.Settings {
    public sealed class LogSettings {
        internal LogSettings() { }

        public bool ShowMessageTime = true;
        public bool EnableHistory = true;

        public string MessageTimeSeparator = ": ";

        public string MessageTimeFormat = @"HH:mm:ss";

        public readonly LogFileSettings FileSettings = new LogFileSettings();
    }
}