using System;
using System.Globalization;
using System.IO;
using NUnit.Framework;

namespace TheLog.Tests {
    [TestFixture]
    public class LogTests : LogTestFixtureBase {
        protected override void SetUp() {
            base.SetUp();
            Log.Settings.ShowMessageTime = false;
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
        public void ShowMessageAtGenericClassTest() {
            using(var stringWriter = new StringWriter()) {
                var instance = new TestGenericClass<int, TestInnerGenericClass<long, TestClass>, string>();
                Console.SetOut(stringWriter);
                Log.ShowMessage(instance, "Test message", MessageType.Default);
                var expectedString = "TestGenericClass<Int32, TestInnerGenericClass<Int64, TestClass>, String> - Test message";
                Assert.AreEqual(expectedString, stringWriter.ToString().Replace(Environment.NewLine, string.Empty));
            }
        }

        [Test]
        public void ShowMessageAtSimpleClassTest() {
            using(var stringWriter = new StringWriter()) {
                var instance = new TestClass();
                Console.SetOut(stringWriter);
                Log.ShowMessage(instance, "Test message", MessageType.Default);
                var expectedString = "TestClass - Test message";
                Assert.AreEqual(expectedString, stringWriter.ToString().Replace(Environment.NewLine, string.Empty));
            }
        }

        [Test]
        public void ShowMessageAtStructTest() {
            using(var stringWriter = new StringWriter()) {
                var instance = new int();
                Console.SetOut(stringWriter);
                Log.ShowMessage(instance, "Test message", MessageType.Default);
                var expectedString = "Int32 - Test message";
                Assert.AreEqual(expectedString, stringWriter.ToString().Replace(Environment.NewLine, string.Empty));
            }
        }

        [Test]
        public void ShowExecutionTimeTest() {
            using(var stringWriter = new StringWriter()) {
                Console.SetOut(stringWriter);
                Log.ShowExecutionTime(() => TestClass.Sleep(1));
                var resultString = stringWriter.ToString();
                var executionTimeString = resultString.Substring(resultString.LastIndexOf('(') + 1);
                executionTimeString = executionTimeString.Remove(executionTimeString.LastIndexOf(')'));
                var executionTime = TimeSpan.ParseExact(executionTimeString, Log.Settings.ExecutionTimeFormat, CultureInfo.InvariantCulture);
                var expectedString = $"() => Sleep(1) ({executionTime.ToString(Log.Settings.ExecutionTimeFormat, CultureInfo.InvariantCulture)})";
                Assert.AreEqual(expectedString, stringWriter.ToString().Replace(Environment.NewLine, string.Empty));
            }
        }
    }
}