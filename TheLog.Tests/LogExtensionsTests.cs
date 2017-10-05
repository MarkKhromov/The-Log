using System;
using NUnit.Framework;
using TheLog.Extensions;

namespace TheLog.Tests {
    [TestFixture]
    public class LogExtensionsTests : LogTestFixtureBase {
        public override void SetUp() {
            base.SetUp();
            Log.Settings.ShowMessageTime = false;
        }

        [Test]
        public void DefaultTest() {
            CheckShowMessageViaMethod("Default message", LogExtensions.Default);
        }

        [Test]
        public void SuccessTest() {
            CheckShowMessageViaMethod("Success message", LogExtensions.Success);
        }

        [Test]
        public void ErrorTest() {
            CheckShowMessageViaMethod("Error message", LogExtensions.Error);
        }

        [Test]
        public void InfoTest() {
            CheckShowMessageViaMethod("Info message", LogExtensions.Info);
        }

        [Test]
        public void WarningTest() {
            CheckShowMessageViaMethod("Warning message", LogExtensions.Warning);
        }

        void CheckShowMessageViaMethod(string message, Action<string, Log<string, ConsoleColor>> showMessage) {
            showMessage(message, Log);
            Assert.AreEqual(message, Writer.ToString().Replace(Environment.NewLine, string.Empty));
        }
    }
}