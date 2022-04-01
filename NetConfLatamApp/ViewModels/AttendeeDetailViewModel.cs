using NetConfLatamApp.Models;

namespace NetConfLatamApp.ViewModels
{
    internal class AttendeeDetailViewModel : DetailBaseViewModel<Attendee, Session>
    {
        public AttendeeDetailViewModel(string controller, string subcontroller, Attendee attendee) 
            : base(controller, subcontroller, attendee)
        {

        }
    }
}
