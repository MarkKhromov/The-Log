﻿using System;
using System.Globalization;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace TheLog.Tests {
    [TestFixture]
    public class LogSettingsTests {
        [Test]
        public void ShowMessageTimeTest() {
            using(var stringWriter = new StringWriter()) {
                Console.SetOut(stringWriter);
                Log.Settings.ShowMessageTime = true;
                Log.ShowMessage("Test message with time", MessageType.Default);
                var resultString = stringWriter.ToString().Replace(Environment.NewLine, string.Empty);
                var timeString = DateTime.ParseExact(new string(resultString.Take(8).ToArray()), "HH:mm:ss", CultureInfo.InvariantCulture);
                Assert.AreEqual($"{timeString.ToString("HH:mm:ss", CultureInfo.InvariantCulture)}: Test message with time", resultString);
            }
        }
    }
}