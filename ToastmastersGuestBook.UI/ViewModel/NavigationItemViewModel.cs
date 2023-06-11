using Prism.Commands;
using Prism.Events;
using System.Windows.Input;
using ToastmastersGuestBook.UI.Event;

namespace ToastmastersGuestBook.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayGuest;
        private IEventAggregator _eventAggregator;
        private string _detailViewModelName;

        public NavigationItemViewModel(int id, string displayGuest, string detailViewModelName, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _detailViewModelName = detailViewModelName;
            Id = id;
            DisplayGuest = displayGuest;
            OpenDetailViewCommand = new DelegateCommand(OnOpenDetailViewExecute);
        }

        

        public int Id { get; }

        public string DisplayGuest
        {
            get { return _displayGuest; }
            set {
                _displayGuest = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenDetailViewCommand { get; }

        private void OnOpenDetailViewExecute()
        {
            _eventAggregator
                    .GetEvent<OpenDetailViewEvent>()
                    .Publish(new OpenDetailViewEventArgs {
                        Id = Id,
                        ViewModelName = _detailViewModelName
                    });
        }
    }
}