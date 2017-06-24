using System;
using System.IO;
using NUnit.Framework;

namespace TheLog.Tests {
    [TestFixture]
    public class LogHistoryTests {
        [Test]
        public void GetLogRecordsByMessageTypeTest() {
            using(var stringWriter = new StringWriter()) {
                Console.SetOut(stringWriter);
                Log.ShowMessage("Test message 1", MessageType.Default);
                Log.ShowMessage("Test message 2", MessageType.Error);
                Log.ShowMessage("Test message 3", MessageType.Error);
                Log.ShowMessage("Test message 4", MessageType.Success);
                Log.ShowMessage("Test message 5", MessageType.Info);
                Log.ShowMessage("Test message 6", MessageType.Warning);
                Assert.AreEqual(1, Log.History[MessageType.Default].Length);
                Assert.AreEqual("Test message 1", Log.History[MessageType.Default][0].Data);
                Assert.AreEqual(2, Log.History[MessageType.Error].Length);
                Assert.AreEqual("Test message 2", Log.History[MessageType.Error][0].Data);
                Assert.AreEqual("Test message 3", Log.History[MessageType.Error][1].Data);
                Assert.AreEqual(1, Log.History[MessageType.Success].Length);
                Assert.AreEqual("Test message 4", Log.History[MessageType.Success][0].Data);
                Assert.AreEqual(1, Log.History[MessageType.Info].Length);
                Assert.AreEqual("Test message 5", Log.History[MessageType.Info][0].Data);
                Assert.AreEqual(1, Log.History[MessageType.Warning].Length);
                Assert.AreEqual("Test message 6", Log.History[MessageType.Warning][0].Data);
            }
        }

        [Test]
        public void ClearLogHistoryTest() {
            using(var stringWriter = new StringWriter()) {
                Console.SetOut(stringWriter);
                Log.ShowMessage("Test message 1", MessageType.Default);
                Log.ShowMessage("Test message 2", MessageType.Error);
                Assert.AreEqual(2, Log.History.Records.Length);
                Log.History.Clear();
                Assert.AreEqual(0, Log.History.Records.Length);
            }
        }
    }
}