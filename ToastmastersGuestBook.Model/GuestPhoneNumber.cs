using System.ComponentModel.DataAnnotations;

namespace ToastmastersGuestBook.Model
{
    public class GuestPhoneNumber
    {
        public int Id { get; set; }

        [Phone]
        [Required]
        public string Number { get; set; }

        public int GuestId { get; set; }

        public Guest Guest { get; set; }
    }
}
