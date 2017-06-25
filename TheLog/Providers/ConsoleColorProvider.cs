using System;
using TheLog.Providers.Base;

namespace TheLog.Providers {
    public class ConsoleColorProvider : IColorProvider {
        object IColorProvider.GetColor(MessageType messageType) {
            switch(messageType) {
                case MessageType.Default:
                    return ((IColorProvider)this).GetCurrentColor();
                case MessageType.Error:
                    return ConsoleColor.Red;
                case MessageType.Info:
                    return ConsoleColor.Cyan;
                case MessageType.Success:
                    return ConsoleColor.Green;
                case MessageType.Warning:
                    return ConsoleColor.Yellow;
                default:
                    throw new NotImplementedException();
            }
        }

        object IColorProvider.GetCurrentColor() {
            return Console.ForegroundColor;
        }

        void IColorProvider.SetColor(object color) {
            Console.ForegroundColor = (ConsoleColor)color;
        }
    }
}