using System;
using NUnit.Framework;
using TheLog.Providers;

namespace TheLog.Tests {
    [TestFixture]
    public abstract class LogTestFixtureBase {
        protected Log<ConsoleColor> Log;

        [SetUp]
        protected virtual void SetUp() {
            Log = Log<ConsoleColor>.Create(new ConsoleMessageProvider(), new ConsoleColorProvider());
        }

        [TearDown]
        protected virtual void TearDown() {
            Log = null;
        }
    }
}