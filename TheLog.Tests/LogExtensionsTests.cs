using System;
using System.IO;
using NUnit.Framework;
using TheLog.Extensions;

namespace TheLog.Tests {
    [TestFixture]
    public class LogExtensionsTests {
        [SetUp]
        protected void SetUp() {
            Log.Settings.ShowMessageTime = false;
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
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

        void CheckShowMessageViaMethod(string message, Action<string> showMessage) {
            using(var stringWriter = new StringWriter()) {
                Console.SetOut(stringWriter);
                showMessage(message);
                Assert.AreEqual(message, stringWriter.ToString().Replace(Environment.NewLine, string.Empty));
            }
        }
    }
}