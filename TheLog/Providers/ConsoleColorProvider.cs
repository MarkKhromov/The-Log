using System;
using TheLog.Providers.Base;

namespace TheLog.Providers {
    public class ConsoleColorProvider : IColorProvider<ConsoleColor> {
        ConsoleColor IColorProvider<ConsoleColor>.GetColor(MessageType messageType) {
            switch(messageType) {
                case MessageType.Default:
                    return ((IColorProvider<ConsoleColor>)this).GetCurrentColor();
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

        ConsoleColor IColorProvider<ConsoleColor>.GetCurrentColor() {
            return Console.ForegroundColor;
        }

        void IColorProvider<ConsoleColor>.SetColor(ConsoleColor color) {
            Console.ForegroundColor = (ConsoleColor)color;
        }
    }
}