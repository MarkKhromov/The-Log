using System;

namespace TheLog {
    public struct LogHistoryRecord {
        public LogHistoryRecord(DateTime? time, string data, MessageType messageType) {
            Time = time;
            Data = data;
            MessageType = messageType;
        }

        public readonly DateTime? Time;
        public readonly string Data;
        public readonly MessageType MessageType;
    }
}