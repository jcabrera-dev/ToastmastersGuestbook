using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastmastersGuestBook.Model;

namespace ToastmastersGuestBook.UI.Wrapper
{
    public class GuestPhoneNumberWrapper : ModelWrapper<GuestPhoneNumber>
    {
        public GuestPhoneNumberWrapper(GuestPhoneNumber model) : base(model)
        {

        }

        public string Number
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
