using System;

using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

using PrismDemo.Core.Events;

namespace ModuleA.ViewModels
{
    public class MessageInputViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private string _message = String.Empty;

        public MessageInputViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

            SendMessageCommand = new DelegateCommand(SendMessage, CanSendMessage)
                .ObservesProperty(() => Message);
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public DelegateCommand SendMessageCommand { get; private set; }

        private void SendMessage()
        {
            _eventAggregator.GetEvent<MessageSentEvent>().Publish(Message);
        }

        private bool CanSendMessage()
        {
            return (Message.Trim() != String.Empty);
        }
    }
}
