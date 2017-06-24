using NUnit.Framework;

namespace TheLog.Tests {
    [TestFixture]
    public abstract class LogTestFixtureBase {
        [SetUp]
        protected virtual void SetUp() { }

        [TearDown]
        protected virtual void TearDown() {
            Log.History.Clear();
        }
    }
}