using NUnit.Framework;
using TheLog.Providers;

namespace TheLog.Tests {
    [TestFixture]
    public abstract class LogTestFixtureBase {
        [SetUp]
        protected virtual void SetUp() {
            Log.Settings.MessageProvider = new ConsoleMessageProvider();
            Log.Settings.ColorProvider = new ConsoleColorProvider();
        }

        [TearDown]
        protected virtual void TearDown() {
            Log.Settings.MessageProvider = new EmptyMessageProvider();
            Log.Settings.ColorProvider = new EmptyColorProvider();
            Log.History.Clear();
        }
    }
}