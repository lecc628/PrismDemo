using System.Collections.ObjectModel;

using Prism.Mvvm;

namespace ModuleB.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        public ObservableCollection<string> Messages { get; } = new();
    }
}
