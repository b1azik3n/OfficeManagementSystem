using DomainLayer.ViewModels;

namespace TaskManagementSystem.Delegates
{
    public class AdditionalEventArgs : EventArgs
    {
        public CommonNotification _commonNotification { get; set; }
        public AdditionalEventArgs(CommonNotification response)
        {
            _commonNotification = response;
        }
    }
}
