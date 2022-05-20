using Prism.Commands;
using Prism.Mvvm;
using System;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _title;

        public ViewAViewModel()
        {
            _title = "Hello from ViewAViewModel";
            ClickCommand = new DelegateCommand(Click, CanClick);
        }

        private void Click()
        {
            Title = "You clicked the button!";
        }

        private bool CanClick()
        {
            return true;
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public DelegateCommand ClickCommand
        {
            get;
            private set;
        }
    }
}
