namespace TheLog.Providers.Base {
    public interface IMessageProvider {
        void ShowMessage(string message);
        void ShowMessageLine(string message);
    }
}