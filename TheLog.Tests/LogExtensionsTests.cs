using System;
using System.IO;
using NUnit.Framework;
using TheLog.Extensions;

namespace TheLog.Tests {
    [TestFixture]
    public class LogExtensionsTests : LogTestFixtureBase {
        protected override void SetUp() {
            base.SetUp();
            Log.Settings.ShowMessageTime = false;
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }

        [Test]
        public void DefaultTest() {
            CheckShowMessageViaMethod("Default message", LogExtensions.Default<ConsoleColor>);
        }

        [Test]
        public void SuccessTest() {
            CheckShowMessageViaMethod("Success message", LogExtensions.Success<ConsoleColor>);
        }

        [Test]
        public void ErrorTest() {
            CheckShowMessageViaMethod("Error message", LogExtensions.Error<ConsoleColor>);
        }

        [Test]
        public void InfoTest() {
            CheckShowMessageViaMethod("Info message", LogExtensions.Info<ConsoleColor>);
        }

        [Test]
        public void WarningTest() {
            CheckShowMessageViaMethod("Warning message", LogExtensions.Warning<ConsoleColor>);
        }

        void CheckShowMessageViaMethod(string message, Action<string> showMessage) {
            using(var stringWriter = new StringWriter()) {
                Console.SetOut(stringWriter);
                showMessage(message);
                Assert.AreEqual(message, stringWriter.ToString().Replace(Environment.NewLine, string.Empty));
            }
        }
    }
}