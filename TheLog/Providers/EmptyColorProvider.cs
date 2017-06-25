using TheLog.Providers.Base;

namespace TheLog.Providers {
    public class EmptyColorProvider : IColorProvider {
        object IColorProvider.GetColor(MessageType messageType) { return null; }
        object IColorProvider.GetCurrentColor() { return null; }
        void IColorProvider.SetColor(object color) { }
    }
}