using System;
using TheLog.Providers;

namespace TheLog {
    public static class DefaultLogs {
        static DefaultLogs() {
            Console = Log<string, ConsoleColor>.Create(new ConsoleMessageProvider(), new ConsoleColorProvider());
        }

        public static Log<string, ConsoleColor> Console { get; }
    }
}