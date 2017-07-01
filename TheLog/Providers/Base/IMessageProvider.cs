namespace TheLog.Providers.Base {
    public interface IMessageProvider<TMessage> {
        TMessage CreateMessage(string messageText);
        void ShowMessage(TMessage message);
        void ShowMessageLine(TMessage message);
    }
}