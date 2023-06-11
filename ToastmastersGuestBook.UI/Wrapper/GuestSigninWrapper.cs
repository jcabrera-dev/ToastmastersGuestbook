using System;
using ToastmastersGuestBook.Model;

namespace ToastmastersGuestBook.UI.Wrapper
{
    public class GuestSigninWrapper : ModelWrapper<GuestSignin>
    {
        public GuestSigninWrapper(GuestSignin model) : base(model)
        {
        }

        public int Id { get { return Model.Id; } }

        public DateTime DateSignin
        {
            get { return GetValue<DateTime>(); }
            set { SetValue(value); }
        }
    }
}
