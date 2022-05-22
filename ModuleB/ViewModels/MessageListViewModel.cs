using System;
using System.Collections.ObjectModel;

using Prism.Events;
using Prism.Mvvm;

using PrismDemo.Core.Events;

namespace ModuleB.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<MessageSentEvent>().Subscribe(OnMessageSentEvent);
        }

        public ObservableCollection<string> Messages { get; } = new();

        private void OnMessageSentEvent(string message)
        {
            Messages.Add(message);
        }
    }
}
