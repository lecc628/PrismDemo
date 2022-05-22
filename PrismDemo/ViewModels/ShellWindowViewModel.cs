using Prism.Commands;
using Prism.Mvvm;

using PrismDemo.Core.Commands;

namespace PrismDemo.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {
        public ShellWindowViewModel(IApplicationCommands applicationCommands)
        {
            SaveAllCommand = applicationCommands.SaveAllCommand;
        }

        public CompositeCommand SaveAllCommand { get; private set; }
    }
}
