using System;

namespace NetConfLatamApp.Models
{
    internal class Attendee : NewAttendee
    {
        public int Id { get; set; }
        public string CreationDate { get; set; }
        public string CreationTime { get; set; }
    }
}
