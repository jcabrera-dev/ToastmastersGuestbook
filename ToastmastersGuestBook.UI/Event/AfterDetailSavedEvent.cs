using Prism.Events;

namespace ToastmastersGuestBook.UI.Event
{
    public class AfterDetailSavedEvent:PubSubEvent<AfterDetailSavedEventArgs>
    {
    }

    public class AfterDetailSavedEventArgs
    {
        public int Id { get; set; }
        
        public string DisplayGuest{ get; set; }

        public string ViewModelName { get; set; }
    }
}
