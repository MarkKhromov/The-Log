using TheLog.Providers.Base;

namespace TheLog.Providers {
    public class EmptyMessageProvider : IMessageProvider {
        void IMessageProvider.ShowMessage(string message) { }
        void IMessageProvider.ShowMessageLine(string message) { }
    }
}