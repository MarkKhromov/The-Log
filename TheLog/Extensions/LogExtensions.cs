namespace TheLog.Extensions {
    public static class LogExtensions {
        public static void Default<TMessage, TColor>(this TMessage messageText, Log<TMessage, TColor> log) {
            log.ShowMessage(messageText, MessageType.Default);
        }

        public static void Success<TMessage, TColor>(this TMessage messageText, Log<TMessage, TColor> log) {
            log.ShowMessage(messageText, MessageType.Success);
        }

        public static void Error<TMessage, TColor>(this TMessage messageText, Log<TMessage, TColor> log) {
            log.ShowMessage(messageText, MessageType.Error);
        }

        public static void Info<TMessage, TColor>(this TMessage messageText, Log<TMessage, TColor> log) {
            log.ShowMessage(messageText, MessageType.Info);
        }

        public static void Warning<TMessage, TColor>(this TMessage messageText, Log<TMessage, TColor> log) {
            log.ShowMessage(messageText, MessageType.Warning);
        }
    }
}