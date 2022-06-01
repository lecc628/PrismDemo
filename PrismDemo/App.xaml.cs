using System.Windows;
using System.Windows.Controls;

using Prism.Ioc;
using Prism.Unity;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

using PrismDemo.Core.Names;
using PrismDemo.Core.Commands;
using PrismDemo.Dialogs.Views;
using PrismDemo.Dialogs.ViewModels;
using PrismDemo.Views;
using PrismDemo.ViewModels;

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
        {
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();

            ViewModelLocationProvider.Register<ShellWindowView, ShellWindowViewModel>();

            containerRegistry.RegisterDialog<MessageDialogView, MessageDialogViewModel>(ApplicationViewNames.MessageDialogView);
        }

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
