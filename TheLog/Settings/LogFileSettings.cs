namespace TheLog.Settings {
    public sealed class LogFileSettings {
        internal LogFileSettings() { }

        public bool AllowWriteToFile = false;
        public string FileName = "actions.log";
    }
}