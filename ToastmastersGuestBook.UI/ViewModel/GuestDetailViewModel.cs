using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ToastmastersGuestBook.Model;
using ToastmastersGuestBook.UI.Data.Lookups;
using ToastmastersGuestBook.UI.Data.Respositories;
using ToastmastersGuestBook.UI.Event;
using ToastmastersGuestBook.UI.View.Services;
using ToastmastersGuestBook.UI.Wrapper;

namespace ToastmastersGuestBook.UI.ViewModel
{
    public class GuestDetailViewModel : DetailViewModelBase, IGuestDetailViewModel
    {
        private IMessageDialogService _messageDialogService;
        private ISocialNetworkLookupDataService _socialNetworkLookupDataService;
        private IGuestRespository _guestRepository;

        private GuestWrapper _guest;
        private GuestPhoneNumberWrapper _selectedPhoneNumber;
        private GuestSigninWrapper _guestSignin;

        public ICommand AddGuestNumberCommand { get; }
        public ICommand RemoveGuestNumberCommand { get; }
        public ICommand AddGuestSigninCommand { get; }

        public ObservableCollection<LookupItem> SocialNetworks { get; }
        public ObservableCollection<GuestPhoneNumberWrapper> GuestNumbers { get; }
        public ObservableCollection<GuestSigninWrapper> GuestSignins { get; }

        public GuestDetailViewModel(
            IGuestRespository guestRepository, 
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService, 
            ISocialNetworkLookupDataService socialNetworkLookupDataService) : base(eventAggregator)
        {
            _guestRepository                    = guestRepository;
            _messageDialogService               = messageDialogService;
            _socialNetworkLookupDataService     = socialNetworkLookupDataService;


            AddGuestNumberCommand               = new DelegateCommand(OnAddPhoneNumberExecute);
            RemoveGuestNumberCommand            = new DelegateCommand(OnRemovePhoneNumberExecute, OnRemovePhoneNumberCanExecute);
            AddGuestSigninCommand               = new DelegateCommand(OnGuestSigninExecute);

            GuestSignins                        = new ObservableCollection<GuestSigninWrapper>();
            SocialNetworks                      = new ObservableCollection<LookupItem>();
            GuestNumbers                        = new ObservableCollection<GuestPhoneNumberWrapper>();
        }

        

        private bool OnRemovePhoneNumberCanExecute()
        {
            return SelectedPhoneNumber != null;
        }

        private void OnRemovePhoneNumberExecute()
        {
            SelectedPhoneNumber.PropertyChanged -= GuestPhoneNumberWrapper_PropertyChanged;
            _guestRepository.RemovePhoneNumber(SelectedPhoneNumber.Model);
            GuestNumbers.Remove(SelectedPhoneNumber);
            SelectedPhoneNumber = null;
            HasChanges = _guestRepository.HasChanges();
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        private void OnAddPhoneNumberExecute()
        {
            var newNumber = new GuestPhoneNumberWrapper(new GuestPhoneNumber());
                newNumber.PropertyChanged += GuestPhoneNumberWrapper_PropertyChanged;
                GuestNumbers.Add(newNumber);
                Guest.Model.GuestNumbers.Add(newNumber.Model);
                newNumber.Number = "";
        }

        private void OnGuestSigninExecute()
        {
            var newGuestSignin = new GuestSigninWrapper(new GuestSignin());
                newGuestSignin.PropertyChanged += GuestSigninWrapper_PropertyChanged;
                // fix this here need to connect to model GuestSign not GuestSignins!
                GuestSignins.Add(newGuestSignin);
                Guest.Model.GuestDateSignins.Add(newGuestSignin.Model);
                newGuestSignin.DateSignin = DateTime.Now;
        }

        protected override async void OnSaveExecute()
        {
            await _guestRepository.SaveAsync();
            HasChanges = _guestRepository.HasChanges();
            RaiseDetailSavedEvent(Guest.Id, $"{Guest.GuestName}");
        }

        protected override bool OnSaveCanExecute()
        {
            // TODO: Check in addition if guest has changes
            return Guest != null
                && !Guest.HasErrors
                && GuestNumbers.All(gn => !gn.HasErrors)
                && GuestSignins.All(gs => !gs.HasErrors)
                && HasChanges;
        }

        protected override async void OnDeleteExecute()
        {
            var result = _messageDialogService.ShowOkCancelDialog($"Do you really want to delete { Guest.GuestName } from the guest list?", "Question");

            if(result == MessageDialogResult.OK)
            {
                _guestRepository.Remove(Guest.Model);
                await _guestRepository.SaveAsync();
                RaisDetailDeletedEvent(Guest.Id);
            }            
        }

        private async void OnOpenDetailView(OpenDetailViewEventArgs args)
        {
            await LoadAsync(args.Id);
        }

        public override async Task LoadAsync(int? guestId)
        {
            var guest = guestId.HasValue ? await _guestRepository.GetByIdAsync(guestId.Value) : CreateNewGuest();

            InitializeGuest(guest);

            InitializeGuestPhoneNumbers(guest.GuestNumbers);

            InitializeGuestSignins(guest.GuestDateSignins);

            await LoadSocialNetworksLookupAsync();
        }

        private void InitializeGuest(Guest guest)
        {
            Guest = new GuestWrapper(guest);
            Guest.PropertyChanged += (s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _guestRepository.HasChanges();
                }

                if (e.PropertyName == nameof(Guest.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };

            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            if (Guest.Id == 0)
            {
                Guest.GuestName = "";
            }
        }

        private void InitializeGuestPhoneNumbers(ICollection<GuestPhoneNumber> guestNumbers)
        {
            foreach(var wrapper in GuestNumbers)
            {
                wrapper.PropertyChanged -= GuestPhoneNumberWrapper_PropertyChanged;
            }

            GuestNumbers.Clear();

            foreach(var guestPhoneNumber in guestNumbers)
            {
                var wrapper = new GuestPhoneNumberWrapper(guestPhoneNumber);
                GuestNumbers.Add(wrapper);
                wrapper.PropertyChanged += GuestPhoneNumberWrapper_PropertyChanged;
            }
        }

        private void InitializeGuestSignins(ICollection<GuestSignin> guestSignins)
        {
            foreach (var wrapper in GuestSignins)
            {
                wrapper.PropertyChanged -= GuestSigninWrapper_PropertyChanged;
            }

            GuestSignins.Clear();

            foreach(var guestSignin in guestSignins)
            {
                var wrapper = new GuestSigninWrapper(guestSignin);
                GuestSignins.Add(wrapper);
                wrapper.PropertyChanged += GuestPhoneNumberWrapper_PropertyChanged;
            }
        }

        private void GuestPhoneNumberWrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(!HasChanges)
            {
                HasChanges = _guestRepository.HasChanges();
            }

            if(e.PropertyName == nameof(GuestPhoneNumberWrapper.HasErrors))
            {
                ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }

        private void GuestSigninWrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(!HasChanges)
            {
                HasChanges = _guestRepository.HasChanges();
            }

            if(e.PropertyName == nameof(GuestSigninWrapper.HasErrors))
            {
                ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }

        private async Task LoadSocialNetworksLookupAsync()
        {
            SocialNetworks.Clear();
            SocialNetworks.Add(new NullLookupItem { DisplayGuest = " - " });
            var lookup = await _socialNetworkLookupDataService.GetSocialNetWorkLookupAsync();

            foreach (var lookupItem in lookup)
            {
                SocialNetworks.Add(lookupItem);
            }            
        }

        public GuestWrapper Guest
        {
            get { return _guest; }
            private set {
                _guest = value;
                OnPropertyChanged();                
            }
        }

        private Guest CreateNewGuest()
        {
            var guest = new Guest();
            _guestRepository.Add(guest);
            return guest;
        }

        public GuestPhoneNumberWrapper SelectedPhoneNumber
        {
            get { return _selectedPhoneNumber; }
            set
            {
                _selectedPhoneNumber = value;
                OnPropertyChanged();
                ((DelegateCommand)RemoveGuestNumberCommand).RaiseCanExecuteChanged();
            }
        }

        public GuestSigninWrapper SelectedGuestSignin
        {
            get { return _guestSignin; }
            private set
            {
                _guestSignin = value;
                OnPropertyChanged();
            }
        }
    }
}
