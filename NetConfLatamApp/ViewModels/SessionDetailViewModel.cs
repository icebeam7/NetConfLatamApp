using NetConfLatamApp.Models;

namespace NetConfLatamApp.ViewModels
{
    internal class SessionDetailViewModel : DetailBaseViewModel<Session, Attendee>
    {
        public SessionDetailViewModel(string controller, string subcontroller, Session session)
            : base(controller, subcontroller, session)
        {

        }
    }
}
