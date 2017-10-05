using System;
using System.IO;
using NUnit.Framework;
using TheLog.Providers;

namespace TheLog.Tests {
    [TestFixture]
    public abstract class LogTestFixtureBase {
        protected Log<string, ConsoleColor> Log;
        protected StringWriter Writer;

        [SetUp]
        public virtual void SetUp() {
            Log = Log<string, ConsoleColor>.Create(new ConsoleMessageProvider(), new ConsoleColorProvider());
            Writer = CreateWriter();
            Console.SetOut(Writer);
        }

        [TearDown]
        public virtual void TearDown() {
            DestroyWriter(Writer);
            Log = null;
        }

        protected virtual StringWriter CreateWriter() {
            return new StringWriter();
        }

        protected virtual void DestroyWriter(StringWriter writer) {
            writer.Dispose();
        }
    }
}