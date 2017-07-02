namespace TheLog.Providers.Base {
    public interface IMessageProvider<TMessage> {
        TMessage CreateMessage(string messageText);
        string GetMessageText(TMessage message);
        void ShowMessage(TMessage message);
        void ShowMessageLine(TMessage message);
    }
}