using System;
using System.IO;
using NUnit.Framework;

namespace TheLog.Tests {
    [TestFixture]
    public class LogTests {
        [SetUp]
        protected void SetUp() {
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }

        [Test]
        public void ShowAllMessageTypesTest() {
            foreach(MessageType messageType in Enum.GetValues(typeof(MessageType))) {
                Log.ShowMessage($"Test {messageType} text", messageType);
            }
        }

        [Test]
        public void ShowMessageTest() {
            using(var stringWriter = new StringWriter()) {
                Console.SetOut(stringWriter);
                Log.ShowMessage("Default message", MessageType.Default);
                Assert.AreEqual("Default message", stringWriter.ToString().Replace(Environment.NewLine, string.Empty));
            }
        }

        [Test]
        public void SuccessTest() {
            using(var stringWriter = new StringWriter()) {
                Console.SetOut(stringWriter);
                Log.Success("Success message");
                Assert.AreEqual("Success message", stringWriter.ToString().Replace(Environment.NewLine, string.Empty));
            }
        }

        [Test]
        public void ErrorTest() {
            using(var stringWriter = new StringWriter()) {
                Console.SetOut(stringWriter);
                Log.Error("Error message");
                Assert.AreEqual("Error message", stringWriter.ToString().Replace(Environment.NewLine, string.Empty));
            }
        }

        [Test]
        public void WarningTest() {
            using(var stringWriter = new StringWriter()) {
                Console.SetOut(stringWriter);
                Log.Warning("Warning message");
                Assert.AreEqual("Warning message", stringWriter.ToString().Replace(Environment.NewLine, string.Empty));
            }
        }

        [Test]
        public void InfoTest() {
            using(var stringWriter = new StringWriter()) {
                Console.SetOut(stringWriter);
                Log.Info("Info message");
                Assert.AreEqual("Info message", stringWriter.ToString().Replace(Environment.NewLine, string.Empty));
            }
        }
    }
}