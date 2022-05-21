using Prism.Ioc;
using Prism.Modularity;
using PrismDemo.Core.Commands;

namespace PrismDemo.Core
{
    public class PrismDemo : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }
    }
}
