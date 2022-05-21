using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using System.Windows;
using System.Windows.Controls;
using PrismDemo.Core.Regions;
using Prism.Modularity;

namespace PrismDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindowView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        { }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);

            regionAdapterMappings.RegisterMapping<StackPanel, StackPanelRegionAdapter>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog { ModulePath = @".\Modules" };
        }
    }
}
