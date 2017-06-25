using TheLog.Providers;
using TheLog.Providers.Base;

namespace TheLog {
    public sealed class LogSettings {
        internal LogSettings() { }

        public bool ShowMessageTime = true;
        public bool EnableHistory = true;

        public string MessageTimeFormat = @"HH:mm:ss";
        public string ExecutionTimeFormat = @"mm\:ss\.fff";

        public IMessageProvider MessageProvider = new EmptyMessageProvider();
        public IColorProvider ColorProvider = new EmptyColorProvider();
    }
}