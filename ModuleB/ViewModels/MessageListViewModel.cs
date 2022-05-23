using System.Collections.ObjectModel;

using Prism.Events;
using Prism.Mvvm;

using PrismDemo.Core.Events;

namespace ModuleB.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        public const string Word_Luis = "Luis";

        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<MessageSentEvent>().Subscribe(OnMessageSentEvent, ThreadOption.PublisherThread, false, 
                message => message.Contains(Word_Luis));
        }

        public ObservableCollection<string> Messages { get; } = new();

        private void OnMessageSentEvent(string message)
        {
            Messages.Add(message);
        }
    }
}
