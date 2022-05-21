using Prism.Commands;

namespace PrismDemo.Core.Commands
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveAllCommand { get; }
    }

    public class ApplicationCommands : IApplicationCommands
    {
        public CompositeCommand SaveAllCommand
        {
            get;
        } = new();
    }
}
