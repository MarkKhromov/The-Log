namespace TheLog {
    public sealed class LogSettings {
        internal LogSettings() { }

        public bool ShowMessageTime = true;
        public bool EnableHistory = true;

        public string MessageTimeFormat = @"HH:mm:ss";
        public string ExecutionTimeFormat = @"mm\:ss\.fff";
    }
}