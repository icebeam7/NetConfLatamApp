using System;

namespace NetConfLatamApp.Models
{
    internal class NewSessionDateTime
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
