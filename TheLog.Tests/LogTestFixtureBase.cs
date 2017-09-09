using System;
using NUnit.Framework;
using TheLog.Providers;

namespace TheLog.Tests {
    [TestFixture]
    public abstract class LogTestFixtureBase {
        protected Log<string, ConsoleColor> Log;

        [SetUp]
        public virtual void SetUp() {
            Log = Log<string, ConsoleColor>.Create(new ConsoleMessageProvider(), new ConsoleColorProvider());
        }

        [TearDown]
        public virtual void TearDown() {
            Log = null;
        }
    }
}