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

        [Test]
        public void AllowWriteToFileTest() {
            File.Delete(Log.Settings.FileSettings.FileName);
            Log.Settings.ShowMessageTime = false;
            Log.Settings.FileSettings.AllowWriteToFile = false;
            Log.ShowMessage("Test message 1", MessageType.Default);
            FileAssert.DoesNotExist(Log.Settings.FileSettings.FileName);
            Log.Settings.FileSettings.AllowWriteToFile = true;
            Log.ShowMessage("Test message 2", MessageType.Default);
            FileAssert.Exists(Log.Settings.FileSettings.FileName);
            var lines = File.ReadAllLines(Log.Settings.FileSettings.FileName);
            Assert.AreEqual(1, lines.Length);
            Assert.AreEqual("Test message 2", lines[0]);
            File.Delete(Log.Settings.FileSettings.FileName);
        }

        [Test]
        public void FileNameTest() {
            var fileName = "test.log";
            Log.Settings.FileSettings.FileName = fileName;
            File.Delete(fileName);
            Log.Settings.FileSettings.AllowWriteToFile = true;
            FileAssert.DoesNotExist(fileName);
            Log.ShowMessage("Test", MessageType.Default);
            FileAssert.Exists(fileName);
            File.Delete(fileName);
            fileName = "test_1.log";
            File.Delete(fileName);
            Log.Settings.FileSettings.FileName = fileName;
            FileAssert.DoesNotExist(fileName);
            Log.ShowMessage("Test", MessageType.Default);
            FileAssert.Exists(fileName);
            File.Delete(fileName);
        }
    }
}