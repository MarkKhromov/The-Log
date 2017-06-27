using TheLog.Providers.Base;

namespace TheLog.Providers {
    public class EmptyColorProvider : IColorProvider<object> {
        object IColorProvider<object>.GetColor(MessageType messageType) { return default(object); }
        object IColorProvider<object>.GetCurrentColor() { return default(object); }
        void IColorProvider<object>.SetColor(object color) { }
    }
}