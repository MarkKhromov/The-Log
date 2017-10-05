using System;
using System.Globalization;
using System.Linq;
using NUnit.Framework;

namespace TheLog.Tests {
    [TestFixture]
    public class LogSettingsTests : LogTestFixtureBase {
        [Test]
        public void ShowMessageTimeTest() {
            Log.Settings.ShowMessageTime = true;
            Log.ShowMessage("Test message with time", MessageType.Default);
            var resultString = Writer.ToString().Replace(Environment.NewLine, string.Empty);
            var timeString = DateTime.ParseExact(new string(resultString.Take(8).ToArray()), Log.Settings.MessageTimeFormat, CultureInfo.InvariantCulture);
            Assert.AreEqual($"{timeString.ToString(Log.Settings.MessageTimeFormat, CultureInfo.InvariantCulture)}: Test message with time", resultString);
        }

        [Test]
        public void MessageTimeSeparatorTest() {
            Log.Settings.MessageTimeSeparator = " - TEST - ";
            Log.ShowMessage("Test message", MessageType.Default);
            var resultString = Writer.ToString().Replace(Environment.NewLine, string.Empty);
            var timeString = DateTime.ParseExact(new string(resultString.Take(8).ToArray()), Log.Settings.MessageTimeFormat, CultureInfo.InvariantCulture);
            Assert.AreEqual($"{timeString.ToString(Log.Settings.MessageTimeFormat, CultureInfo.InvariantCulture)} - TEST - Test message", resultString);
        }
    }
}