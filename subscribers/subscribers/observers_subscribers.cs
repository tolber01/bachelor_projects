using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace subscribers
{
    public interface ISubscriber
    {
        public void Notify(string msg);
    }

    public class Countdown
    {
        private List<ISubscriber> subscribersList;
        public Countdown()
        {
            subscribersList = new List<ISubscriber>();
        }

        public void RunTimer(string timerMsg, int timeMilliseconds)
        {
            if (timeMilliseconds <= 0)
                throw new ArgumentOutOfRangeException("Countdown time should be positive integer (time in ms)!");

            Console.WriteLine($"Running timer: {timeMilliseconds} ms...");
            Thread.Sleep(timeMilliseconds);

            foreach (var subs in subscribersList)
            {
                subs.Notify($"Notification: time ({timeMilliseconds} ms) is up! Message: '{timerMsg}'");
            }
        }

        public void AddSubscriber(ISubscriber newSubs)
        {
            if (!subscribersList.Contains(newSubs))
                subscribersList.Add(newSubs);
        }

        public void RemoveSubscriber(ISubscriber removeSubs)
        {
            if (subscribersList.Contains(removeSubs))
                subscribersList.Remove(removeSubs);
        }
    }

    public class Logger : ISubscriber
    {
        private List<string> logs;

        public Logger()
        {
            logs = new List<string>();
        }

        void ISubscriber.Notify(string msg)
        {
            logs.Add(msg);
        }

        public void PrintLogs()
        {
            foreach (var log in logs)
            {
                Console.WriteLine(log);
            }
        }
    }

    public class FileWriter : ISubscriber
    {
        private StreamWriter fileWriter;
        private string writeFilePath;
        private bool toRewrite;
        public FileWriter(string filePath, bool rewrite = true)
        {
            writeFilePath = filePath;
            toRewrite = rewrite;
            fileWriter = new StreamWriter(writeFilePath, !toRewrite);
        }
        void ISubscriber.Notify(string msg)
        {
            fileWriter.WriteLine(msg);
        }

        public string ReadFile()
        {
            fileWriter.Close();
            string contents = File.ReadAllText(writeFilePath);
            fileWriter = new StreamWriter(writeFilePath, !toRewrite);
            return contents;
        }
    }
}
