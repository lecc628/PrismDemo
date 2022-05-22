using Prism.Commands;
using Prism.Mvvm;
using System;

namespace ModuleA.ViewModels
{
    public class MessageInputViewModel : BindableBase
    {
        private string _message = String.Empty;

        public MessageInputViewModel()
        {
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
            System.Windows.MessageBox.Show(Message, Message);
        }

        private bool CanSendMessage()
        {
            return (Message.Trim() != String.Empty);
        }
    }
}
