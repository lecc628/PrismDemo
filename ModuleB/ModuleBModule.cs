using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

using ModuleB.Views;
using ModuleB.ViewModels;

using PrismDemo.Core.Names;

namespace ModuleB
{
    public class ModuleBModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleBModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<MessageListView, MessageListViewModel>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            /* View composition using view discovery. */

            _regionManager.RegisterViewWithRegion<MessageListView>(ApplicationRegionNames.MessageListRegion);
        }
    }
}
