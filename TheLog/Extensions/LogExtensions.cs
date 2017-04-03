namespace TheLog.Extensions {
    public static class LogExtensions {
        public static void Default(this string message) {
            Log.ShowMessage(message, MessageType.Default);
        }

        public static void Success(this string message) {
            Log.ShowMessage(message, MessageType.Success);
        }

        public static void Error(this string message) {
            Log.ShowMessage(message, MessageType.Error);
        }

        public static void Info(this string message) {
            Log.ShowMessage(message, MessageType.Info);
        }

        public static void Warning(this string message) {
            Log.ShowMessage(message, MessageType.Warning);
        }
    }
}