using System;
using System.Collections.Generic;
using ToastmastersGuestBook.Model;

namespace ToastmastersGuestBook.UI.Wrapper
{
    // 1 pass in ModelWrapper and Guest Model
    public class GuestWrapper : ModelWrapper<Guest>
    {
        // constructor
        public GuestWrapper(Guest model) : base(model)
        {

        }

        public int Id { get { return Model.Id; } }

        public string GuestName {
            // 2 GetValue is passing in the value entered 
            get { return GetValue<string>(nameof(GuestName)); }
            set {
                SetValue(value);
            }
        }

        public string GuestEmail
        {
            get { return Model.GuestEmail; }
            set {
                SetValue(value);
            }
        }

        public int? SocialMediaId
        {
            get { return GetValue<int?>(); }
            set { SetValue(value); }
        }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(GuestName):
                    if (string.Equals(GuestName, "Jose Cabrera", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return "Jose Cabrera can not be added.";
                    }
                    break;
            }
        }
        }
}
