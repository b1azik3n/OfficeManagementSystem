using DomainLayer.ViewModels;

namespace TaskManagementSystem.Delegates.Publisher
{
    public class PublisherMail
    {
        public delegate void EmailSender(object source, AdditionalEventArgs project);
        public event EmailSender CriticalChanges;

        public void SendNotification(CommonNotification request)
        {
            OnCriticalChanges(request);

        }
        protected virtual void OnCriticalChanges(CommonNotification response)
        {
            if (CriticalChanges != null)
            {
                CriticalChanges(this, new AdditionalEventArgs(response));
            }
        }
    }
}
