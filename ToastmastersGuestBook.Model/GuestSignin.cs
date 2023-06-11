using System;
using System.ComponentModel.DataAnnotations;

namespace ToastmastersGuestBook.Model
{
    public class GuestSignin
    {
        public int Id { get; set; }
        
        [Required]
        public DateTime DateSignin { get; set; }

        public int GuestId { get; set; }

        public Guest Guest { get; set; }
    }    
}
