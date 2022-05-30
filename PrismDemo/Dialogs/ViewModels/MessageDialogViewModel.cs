using System;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace PrismDemo.Dialogs.ViewModels
{
    public class MessageDialogViewModel : BindableBase, IDialogAware
    {
        private string _message = string.Empty;
        public event Action<IDialogResult> RequestClose = _ => { };

        public MessageDialogViewModel()
        {
            OKDialogCommand = new DelegateCommand(CloseDialog);
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public DelegateCommand OKDialogCommand { get; }

        private void CloseDialog()
        {
            var dialogParameters = new DialogParameters
            {
                { "MessageOKButtonClicked", "The dialog was closed by clicking the \"OK\" button." }
            };

            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, dialogParameters));
        }

        public string Title => "My Message Dialog";

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("Message");
        }

        public void OnDialogClosed()
        { }
    }
}
