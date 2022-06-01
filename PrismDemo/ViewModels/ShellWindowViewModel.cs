using Prism.Mvvm;
using Prism.Regions;
using Prism.Commands;
using Prism.Services.Dialogs;

using PrismDemo.Core.Names;
using PrismDemo.Core.Commands;
using PrismDemo.Core.Dialogs;

namespace PrismDemo.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;

        private string _messageReceived = string.Empty;

        public ShellWindowViewModel(IApplicationCommands applicationCommands, IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;

            SaveAllCommand = applicationCommands.SaveAllCommand;
            NavigateCommand = new DelegateCommand<string>(NavigateToView);
            ShowDialogCommand = new DelegateCommand(ShowDialog);
        }

        public string MessageReceived
        {
            get => _messageReceived;
            set => SetProperty(ref _messageReceived, value);
        }

        public CompositeCommand SaveAllCommand { get; private set; }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        private void NavigateToView(string uri)
        {
            _regionManager.RequestNavigate(ApplicationRegionNames.BCViewsRegion, uri);
        }

        public DelegateCommand ShowDialogCommand { get; }

        private void ShowDialog()
        {
            MessageReceived = string.Empty;

            _dialogService.ShowMessageDialog("This is my dialog!", result => {
                if (result.Result == ButtonResult.OK)
                {
                    MessageReceived = result.Parameters.GetValue<string>("MessageOKButtonClicked");
                }
                else
                {
                    MessageReceived = "The dialog was closed.";
                }
            });
        }
    }
}
