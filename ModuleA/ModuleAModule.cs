using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Windows.Controls;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ModuleAModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            /* View composition using view discovery. */

            _regionManager.RegisterViewWithRegion<ViewA>("ContentRegion");

            /******************************************/


            /* View composition using view injection. */

            var contentRegion = _regionManager.Regions["ContentRegion"];

            var view1 = containerProvider.Resolve<ViewA>();
            contentRegion.Add(view1);

            var view2 = containerProvider.Resolve<ViewA>();
            var tb = (TextBlock)(((Panel)(view2.Content)).Children[2]);
            tb.FontSize = 18;
            contentRegion.Add(view2);

            /******************************************/
        }
    }
}
