using System;

namespace TheLog {
    public struct LogHistoryRecord<TMessage> {
        public LogHistoryRecord(DateTime? time, TMessage message, MessageType messageType) {
            Time = time;
            Message = message;
            MessageType = messageType;
        }

        public readonly DateTime? Time;
        public readonly TMessage Message;
        public readonly MessageType MessageType;
    }
}