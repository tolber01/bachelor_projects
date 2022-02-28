using NUnit.Framework;
using System.Collections.Generic;

namespace tests
{
    public class Tests
    {
        string filePath;

        [SetUp]
        public void Setup()
        {
            filePath = "C:\\users\\ov4t\\desktop\\logs.txt";
        }

        [Test]
        public void TestAddRemoveSubscribers()
        {
            var timer = new subscribers.Countdown();

            var subs1 = new subscribers.Logger();
            var subs2 = new subscribers.Logger();
            var subs3 = new subscribers.Logger();

            timer.AddSubscriber(subs1);
            Assert.AreEqual(timer.SubsList.Count, 1);
            Assert.IsTrue(timer.SubsList.Contains(subs1));

            timer.AddSubscriber(subs2);
            timer.AddSubscriber(subs3);
            timer.RemoveSubscriber(subs1);
            Assert.AreEqual(timer.SubsList.Count, 2);
            Assert.IsFalse(timer.SubsList.Contains(subs1));
        }

        [Test]
        public void TestLogger()
        {
            var timer = new subscribers.Countdown();
            var logger = new subscribers.Logger();

            timer.AddSubscriber(logger);
            timer.RunTimer("Test message 1", 100);
            timer.RunTimer("Test message 2", 200);
            timer.RemoveSubscriber(logger);
            timer.RunTimer("Test message 3", 100);

            Assert.AreEqual(logger.LogsList, new List<string> {
                "Notification: time (100 ms) is up! Message: 'Test message 1'",
                "Notification: time (200 ms) is up! Message: 'Test message 2'"
            });
        }

        [Test]
        public void TestFileLogger()
        {
            var timer = new subscribers.Countdown();
            var fileLogger = new subscribers.FileWriter(filePath, rewrite: true);

            timer.AddSubscriber(fileLogger);
            timer.RunTimer("Test message 1", 100);
            timer.RunTimer("Test message 2", 100);
            timer.RemoveSubscriber(fileLogger);

            Assert.AreEqual(
                fileLogger.ReadFile(),
                "Notification: time (100 ms) is up! Message: 'Test message 1'\r\nNotification: time (100 ms) is up! Message: 'Test message 2'\r\n"
            );
        }
    }
}