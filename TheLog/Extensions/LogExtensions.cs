namespace TheLog.Extensions {
    public static class LogExtensions {
        public static void Default<TColor>(this string message) {
            Log<TColor>.Get().ShowMessage(message, MessageType.Default);
        }

        public static void Success<TColor>(this string message) {
            Log<TColor>.Get().ShowMessage(message, MessageType.Success);
        }

        public static void Error<TColor>(this string message) {
            Log<TColor>.Get().ShowMessage(message, MessageType.Error);
        }

        public static void Info<TColor>(this string message) {
            Log<TColor>.Get().ShowMessage(message, MessageType.Info);
        }

        public static void Warning<TColor>(this string message) {
            Log<TColor>.Get().ShowMessage(message, MessageType.Warning);
        }
    }
}