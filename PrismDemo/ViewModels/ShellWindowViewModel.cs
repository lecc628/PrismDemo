using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using PrismDemo.Core.Commands;
using PrismDemo.Core.Names;

namespace PrismDemo.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public ShellWindowViewModel(IApplicationCommands applicationCommands, IRegionManager regionManager)
        {
            _regionManager = regionManager;

            SaveAllCommand = applicationCommands.SaveAllCommand;
            NavigateCommand = new DelegateCommand<string>(NavigateToView);
        }

        public CompositeCommand SaveAllCommand { get; private set; }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        private void NavigateToView(string uri)
        {
            _regionManager.RequestNavigate(ApplicationRegionNames.BCViewsRegion, uri);
        }
    }
}
