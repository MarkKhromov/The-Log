using System;
using System.Collections.Generic;
using System.Linq;

namespace TheLog {
    public sealed class LogHistory<TMessage> {
        internal LogHistory() { }

        public LogHistoryRecord<TMessage>[] this[MessageType messageType] {
            get { return records.Where(x => x.MessageType == messageType).ToArray(); }
        }

        readonly IList<LogHistoryRecord<TMessage>> records = new List<LogHistoryRecord<TMessage>>();
        public LogHistoryRecord<TMessage>[] Records {
            get { return records.ToArray(); }
        }

        public void Clear() {
            records.Clear();
        }

        internal void Add(DateTime? time, TMessage message, MessageType messageType) {
            records.Add(new LogHistoryRecord<TMessage>(time, message, messageType));
        }
    }
}