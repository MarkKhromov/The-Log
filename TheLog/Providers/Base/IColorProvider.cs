namespace TheLog.Providers.Base {
    public interface IColorProvider {
        object GetColor(MessageType messageType);
        object GetCurrentColor();
        void SetColor(object color);
    }
}