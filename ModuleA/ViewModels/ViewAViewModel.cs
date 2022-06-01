using Prism.Mvvm;
using Prism.Commands;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _title = "Hello from ViewAViewModel";
        private bool _canExecute = false;

        public ViewAViewModel()
        {
            ClickCommand = new DelegateCommand(Click, CanClick)
                .ObservesProperty<bool>(() => CanExecute);
        }

        private void Click()
        {
            Title = "You clicked the button!";
        }

        private bool CanClick()
        {
            return CanExecute;
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public bool CanExecute
        {
            get => _canExecute;
            set => SetProperty(ref _canExecute, value);
        }

        public DelegateCommand ClickCommand
        {
            get;
            private set;
        }
    }
}
