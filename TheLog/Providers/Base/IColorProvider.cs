namespace TheLog.Providers.Base {
    public interface IColorProvider<TColor> {
        TColor GetColor(MessageType messageType);
        TColor GetCurrentColor();
        void SetColor(TColor color);
    }
}