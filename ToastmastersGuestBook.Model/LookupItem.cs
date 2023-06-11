namespace ToastmastersGuestBook.Model
{
    public class LookupItem
    {
        public int Id { get; set; }

        public string DisplayGuest { get; set; }
    }

    public class NullLookupItem: LookupItem
    {
        public new int? Id { get { return null; } }
    }
}
