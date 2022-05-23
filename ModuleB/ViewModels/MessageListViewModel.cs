using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

using PrismDemo.Core.Events;

namespace ModuleB.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        public const string Word_Luis = "Luis";

        private bool _isSubscribed = true;
        private readonly MessageSentEvent _messageSentEvent;

        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            SubscribedCommand = new DelegateCommand(SubUnsubEvent, () => true)
                .ObservesProperty(() => IsSubscribed);

            _messageSentEvent = eventAggregator.GetEvent<MessageSentEvent>();
            SubUnsubEvent();
        }

        public bool IsSubscribed
        {
            get => _isSubscribed;
            set => SetProperty(ref _isSubscribed, value);
        }

        public DelegateCommand SubscribedCommand { get; private set; }

        public ObservableCollection<string> Messages { get; } = new();

        private void OnMessageSentEvent(string message)
        {
            Messages.Add(message);
        }

        private void SubUnsubEvent()
        {
            if (IsSubscribed)
            {
                _messageSentEvent.Subscribe(OnMessageSentEvent, ThreadOption.PublisherThread, false,
                    message => message.Contains(Word_Luis));
            }
            else
            {
                _messageSentEvent.Unsubscribe(OnMessageSentEvent);
            }
        }
    }
}
