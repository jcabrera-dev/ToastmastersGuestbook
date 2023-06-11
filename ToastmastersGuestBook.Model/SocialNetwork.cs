using System.ComponentModel.DataAnnotations;

namespace ToastmastersGuestBook.Model
{
    public class SocialNetwork
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
