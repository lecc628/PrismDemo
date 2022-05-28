using System.Windows.Controls;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

using ModuleA.ViewModels;
using ModuleA.Views;
using PrismDemo.Core.Names;

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
            ViewModelLocationProvider.Register<ViewA, ViewAViewModel>();
            ViewModelLocationProvider.Register<TabView, TabViewModel>();
            ViewModelLocationProvider.Register<MessageInputView, MessageInputViewModel>();

            /* Region navigation. */
            containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>(ApplicationViewNames.ViewB);
            containerRegistry.RegisterForNavigation<ViewC, ViewCViewModel>(ApplicationViewNames.ViewC);
            containerRegistry.RegisterForNavigation<PersonDetailView, PersonDetailViewModel>(ApplicationViewNames.PersonDetailView);
            containerRegistry.RegisterForNavigation<PersonListView, PersonListViewModel>(ApplicationViewNames.PersonListView);
            containerRegistry.RegisterForNavigation<PersonDetailWithJournalView, PersonDetailWithJournalViewModel>(ApplicationViewNames.PersonDetailWithJournalView);
            containerRegistry.RegisterForNavigation<PersonListWithJournalView, PersonListWithJournalViewModel>(ApplicationViewNames.PersonListWithJournalView);
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            /* View composition using view discovery. */

            _regionManager.RegisterViewWithRegion<ViewA>(ApplicationRegionNames.ContentRegion);
            _regionManager.RegisterViewWithRegion<MessageInputView>(ApplicationRegionNames.MessageInputRegion);

            /******************************************/


            /* View composition using view injection. */

            var contentRegion = _regionManager.Regions[ApplicationRegionNames.ContentRegion];

            var view1 = containerProvider.Resolve<ViewA>();
            contentRegion.Add(view1);

            var view2 = containerProvider.Resolve<ViewA>();
            var tb = (TextBlock)(((Panel)(view2.Content)).Children[2]);
            tb.FontSize = 12;
            contentRegion.Add(view2);

            /******************************************/

            var tabRegion = _regionManager.Regions[ApplicationRegionNames.TabRegion];

            var tabView1 = containerProvider.Resolve<TabView>();
            ((TabViewModel)tabView1.DataContext).Title = "Tab A";
            tabRegion.Add(tabView1);
            var tabView2 = containerProvider.Resolve<TabView>();
            ((TabViewModel)tabView2.DataContext).Title = "Tab B";
            tabRegion.Add(tabView2);
            var tabView3 = containerProvider.Resolve<TabView>();
            ((TabViewModel)tabView3.DataContext).Title = "Tab C";
            tabRegion.Add(tabView3);

            /******************************************/

            _regionManager.RequestNavigate(ApplicationRegionNames.PersonRegion, ApplicationViewNames.PersonListView);

            /******************************************/

            _regionManager.RequestNavigate(ApplicationRegionNames.PersonWithNavigationJournalRegion, ApplicationViewNames.PersonListWithJournalView);
        }
    }
}
