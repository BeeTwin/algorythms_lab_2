using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace algorythms_lab_2
{
    public class TimeAnalizer
    {
        public Action Actions;

        public double Analyze()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            Actions();
            stopwatch.Stop();

            return stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}
