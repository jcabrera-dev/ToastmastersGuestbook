using Prism.Events;

namespace ToastmastersGuestBook.UI.Event
{
    public class AfterDetailDeletedEvent:PubSubEvent<AfterDetailDeletedEventArgs>
    {
    }

    public class AfterDetailDeletedEventArgs
    {
        public int? Id { get; set; }
        public string ViewModelName { get; set; }
    }
}
