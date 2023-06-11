using Prism.Events;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ToastmastersGuestBook.UI.Data.Lookups;
using ToastmastersGuestBook.UI.Event;

namespace ToastmastersGuestBook.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IGuestLookupDataService _guestLookupService;

        private IEventAggregator _eventAggregator;

        public NavigationViewModel(IGuestLookupDataService guestLookupService, IEventAggregator eventAggregator)
        {
            _guestLookupService = guestLookupService;

            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AfterDetailSavedEvent>().Subscribe(AfterDetailSaved);
            _eventAggregator.GetEvent<AfterDetailDeletedEvent>().Subscribe(AfterDetailDeleted);

            Guests = new ObservableCollection<NavigationItemViewModel>();
        }

        public async Task LoadAsync()
        {
            var lookup = await _guestLookupService.GetGuestLookupAsync();
            Guests.Clear();

            foreach (var item in lookup)
            {
                Guests.Add(new NavigationItemViewModel(item.Id, item.DisplayGuest, nameof(GuestDetailViewModel), _eventAggregator));
            }
        }

        public ObservableCollection<NavigationItemViewModel> Guests { get; }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            switch(args.ViewModelName)
            {
                case nameof(GuestDetailViewModel):
                    var guest = Guests.SingleOrDefault(g => g.Id == args.Id);

                    if (guest != null)
                    {
                        Guests.Remove(guest);
                    }

                    break;
            }
        }



        private void AfterDetailSaved(AfterDetailSavedEventArgs obj)
        {
            switch (obj.ViewModelName)
            {
                case nameof(GuestDetailViewModel):
                    var lookupItem = Guests.SingleOrDefault(g => g.Id == obj.Id);

                    if (lookupItem == null)
                    {
                        Guests.Add(new NavigationItemViewModel(obj.Id, obj.DisplayGuest, nameof(GuestDetailViewModel), _eventAggregator));
                    }
                    else
                    {
                        lookupItem.DisplayGuest = obj.DisplayGuest;
                    }
                    break;
            }
        }
    }
}
