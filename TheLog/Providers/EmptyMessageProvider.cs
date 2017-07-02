using TheLog.Providers.Base;

namespace TheLog.Providers {
    public class EmptyMessageProvider : IMessageProvider<object> {
        object IMessageProvider<object>.CreateMessage(string messageText) { return null; }
        string IMessageProvider<object>.GetMessageText(object message) { return null; }
        void IMessageProvider<object>.ShowMessage(object message) { }
        void IMessageProvider<object>.ShowMessageLine(object message) { }
    }
}