using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ToastmastersGuestBook.Model
{
    public class Guest
    {

        public Guest()
        {
            GuestNumbers        = new Collection<GuestPhoneNumber>();
            GuestDateSignins    = new Collection<GuestSignin>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string GuestName { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string GuestEmail { get; set; }

        public int? SocialMediaId { get; set; }

        public SocialNetwork SocialMedia { get; set; }

        public ICollection<GuestPhoneNumber> GuestNumbers { get; set; }

        public ICollection<GuestSignin> GuestDateSignins { get; set; }
    }
}
