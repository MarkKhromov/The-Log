using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace TheLog {
    public sealed class LogHistory<TMessage> {
        internal LogHistory() {
            records = new Collection<LogHistoryRecord<TMessage>>();
        }

        public LogHistoryRecord<TMessage>[] this[MessageType messageType] {
            get { return records.Where(x => x.MessageType == messageType).ToArray(); }
        }

        readonly Collection<LogHistoryRecord<TMessage>> records;
        public LogHistoryRecord<TMessage>[] Records {
            get { return records.ToArray(); }
        }

        public void Clear() {
            lock(this) {
                records.Clear();
            }
        }

        internal void Add(DateTime? time, TMessage message, MessageType messageType) {
            lock(this) {
                records.Add(new LogHistoryRecord<TMessage>(time, message, messageType));
            }
        }
    }
}