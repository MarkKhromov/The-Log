using System;
using System.Globalization;
using NUnit.Framework;

namespace TheLog.Tests {
    [TestFixture]
    public class LogTests : LogTestFixtureBase {
        public override void SetUp() {
            base.SetUp();
            Log.Settings.ShowMessageTime = false;
        }

        [Test]
        public void ShowAllMessageTypesTest() {
            foreach(MessageType messageType in Enum.GetValues(typeof(MessageType))) {
                Log.ShowMessage($"Test {messageType} text", messageType);
            }
        }

        [Test]
        public void ShowMessageTest() {
            Log.ShowMessage("Default message", MessageType.Default);
            Assert.AreEqual("Default message", Writer.ToString().Replace(Environment.NewLine, string.Empty));
        }

        [Test]
        public void ShowMessageAtGenericClassTest() {
            var instance = new TestGenericClass<int, TestInnerGenericClass<long, TestClass>, string>();
            Log.ShowMessage(instance, "Test message", MessageType.Default);
            var expectedString = "TestGenericClass<Int32, TestInnerGenericClass<Int64, TestClass>, String> - Test message";
            Assert.AreEqual(expectedString, Writer.ToString().Replace(Environment.NewLine, string.Empty));
        }

        [Test]
        public void ShowMessageAtSimpleClassTest() {
            var instance = new TestClass();
            Log.ShowMessage(instance, "Test message", MessageType.Default);
            var expectedString = "TestClass - Test message";
            Assert.AreEqual(expectedString, Writer.ToString().Replace(Environment.NewLine, string.Empty));
        }

        [Test]
        public void ShowMessageAtStructTest() {
            var instance = new int();
            Log.ShowMessage(instance, "Test message", MessageType.Default);
            var expectedString = "Int32 - Test message";
            Assert.AreEqual(expectedString, Writer.ToString().Replace(Environment.NewLine, string.Empty));
        }
    }
}