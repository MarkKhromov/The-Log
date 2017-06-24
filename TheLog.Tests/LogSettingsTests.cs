using System;
using System.Globalization;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace TheLog.Tests {
    [TestFixture]
    public class LogSettingsTests : LogTestFixtureBase {
        [Test]
        public void ShowMessageTimeTest() {
            using(var stringWriter = new StringWriter()) {
                Console.SetOut(stringWriter);
                Log.Settings.ShowMessageTime = true;
                Log.ShowMessage("Test message with time", MessageType.Default);
                var resultString = stringWriter.ToString().Replace(Environment.NewLine, string.Empty);
                var timeString = DateTime.ParseExact(new string(resultString.Take(8).ToArray()), Log.Settings.MessageTimeFormat, CultureInfo.InvariantCulture);
                Assert.AreEqual($"{timeString.ToString(Log.Settings.MessageTimeFormat, CultureInfo.InvariantCulture)}: Test message with time", resultString);
            }
        }
    }
}