using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;

namespace TheLog.Tests {
    [TestFixture]
    public class LogHistoryTests : LogTestFixtureBase {
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
                Assert.AreEqual("Test message 1", Log.History[MessageType.Default][0].Message);
                Assert.AreEqual(2, Log.History[MessageType.Error].Length);
                Assert.AreEqual("Test message 2", Log.History[MessageType.Error][0].Message);
                Assert.AreEqual("Test message 3", Log.History[MessageType.Error][1].Message);
                Assert.AreEqual(1, Log.History[MessageType.Success].Length);
                Assert.AreEqual("Test message 4", Log.History[MessageType.Success][0].Message);
                Assert.AreEqual(1, Log.History[MessageType.Info].Length);
                Assert.AreEqual("Test message 5", Log.History[MessageType.Info][0].Message);
                Assert.AreEqual(1, Log.History[MessageType.Warning].Length);
                Assert.AreEqual("Test message 6", Log.History[MessageType.Warning][0].Message);
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

        [Test]
        public void AddRecordFromSeveralThreadsTest() {
            Log.Settings.ShowMessageTime = false;
            Log.Settings.EnableHistory = true;
            var threads = Enumerable.Range(0, 11).Select(x => {
                return new Thread(() => {
                    var messageType = (x & 1) == 0 ? MessageType.Info : MessageType.Success;
                    Log.ShowMessage($"Test message {x}", messageType);
                });
            }).ToArray();
            threads.ToList().ForEach(x => x.Start());
            foreach(var thread in threads) {
                thread.Join();
            }
            Assert.AreEqual(11, Log.History.Records.Length);
            var infos = Log.History[MessageType.Info];
            Assert.AreEqual(6, infos.Length);
            var successes = Log.History[MessageType.Success];
            Assert.AreEqual(5, successes.Length);
            Assert.IsTrue(infos.Any(x => x.Message == "Test message 0"));
            Assert.IsTrue(infos.Any(x => x.Message == "Test message 2"));
            Assert.IsTrue(infos.Any(x => x.Message == "Test message 4"));
            Assert.IsTrue(infos.Any(x => x.Message == "Test message 6"));
            Assert.IsTrue(infos.Any(x => x.Message == "Test message 8"));
            Assert.IsTrue(infos.Any(x => x.Message == "Test message 10"));
            Assert.IsTrue(successes.Any(x => x.Message == "Test message 1"));
            Assert.IsTrue(successes.Any(x => x.Message == "Test message 3"));
            Assert.IsTrue(successes.Any(x => x.Message == "Test message 5"));
            Assert.IsTrue(successes.Any(x => x.Message == "Test message 7"));
            Assert.IsTrue(successes.Any(x => x.Message == "Test message 9"));
        }
    }
}