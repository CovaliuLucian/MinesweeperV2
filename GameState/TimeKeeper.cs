using System;
using System.Diagnostics;

namespace GameState
{
    public class TimeKeeper
    {
        private readonly Stopwatch stopwatch;

        public TimeKeeper()
        {
            stopwatch = new Stopwatch();
        }

        public void Start()
        {
            stopwatch.Start();
        }

        public void Restart()
        {
            stopwatch.Restart();
        }

        public int GetTime()
        {
            var seconds = stopwatch.Elapsed.TotalSeconds;
            return seconds > 999 ? 999 : Convert.ToInt32(seconds);
        }
    }
}