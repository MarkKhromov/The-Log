using System;
using System.Collections.Generic;
using System.Linq;

namespace TheLog {
    public sealed class LogHistory {
        internal LogHistory() { }

        public LogHistoryRecord[] this[MessageType messageType] {
            get { return records.Where(x => x.MessageType == messageType).ToArray(); }
        }

        readonly IList<LogHistoryRecord> records = new List<LogHistoryRecord>();
        public LogHistoryRecord[] Records {
            get { return records.ToArray(); }
        }

        public void Clear() {
            records.Clear();
        }

        internal void Add(DateTime? time, string message, MessageType messageType) {
            records.Add(new LogHistoryRecord(time, message, messageType));
        }
    }
}