using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ToastmastersGuestBook.UI.Event;
using ToastmastersGuestBook.UI.View.Services;

namespace ToastmastersGuestBook.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private Func<IGuestDetailViewModel> _GuestDetailViewModelCreator;
        private IMessageDialogService _messageDialogService;
        private IDetailViewModel _detailViewModel;

    
        // injecting the guestDataService
        public MainViewModel(
            Func<IGuestDetailViewModel> guestDetailViewModelCreator, 
            INavigationViewModel navigationViewModel, 
            IEventAggregator eventAggregator, 
            IMessageDialogService messageDialogService)
        {
            _eventAggregator                = eventAggregator;

            _eventAggregator
                .GetEvent<OpenDetailViewEvent>()
                .Subscribe(OnOpenDetailView);

            _eventAggregator.GetEvent<AfterDetailDeletedEvent>().Subscribe(AfterDetailDeleted);
            _GuestDetailViewModelCreator    = guestDetailViewModelCreator;
            _messageDialogService           = messageDialogService;

            

            CreateNewDetailCommand = new DelegateCommand<Type>(OnCreateNewDetailExecute);

            NavigationViewModel = navigationViewModel;

        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        public ICommand CreateNewDetailCommand { get; }

        public INavigationViewModel NavigationViewModel { get; }

        public IDetailViewModel DetailViewModel
        {
            get { return _detailViewModel; }
            private set {
                _detailViewModel = value;
                OnPropertyChanged();
            }
        }


        private async void OnOpenDetailView(OpenDetailViewEventArgs args)
        {
            if(DetailViewModel != null && DetailViewModel.HasChanges)
            {
                var result = _messageDialogService.ShowOkCancelDialog("You've made changes. Navigate away?", "Question");

                if(result == MessageDialogResult.Cancel)
                {
                    return;
                }
            }

            switch(args.ViewModelName)
            {
                case nameof(GuestDetailViewModel):
                    DetailViewModel = _GuestDetailViewModelCreator();
                    break;
            }

            await DetailViewModel.LoadAsync(args.Id);


        }

        private void OnCreateNewDetailExecute(Type viewModelType)
        {
            OnOpenDetailView(new OpenDetailViewEventArgs { ViewModelName = viewModelType.Name });
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            DetailViewModel = null;
        }
    }
}
