using Prism.Commands;
using Prism.Mvvm;
using System;

namespace ModuleA.ViewModels
{
    public class TabViewModel : BindableBase
    {
        private string _title = "Tab name";
        private bool _canSave = false;
        private string _resultText = String.Empty;

        public TabViewModel()
        {
            SaveCommand = new DelegateCommand(Save)
                .ObservesCanExecute(() => CanSave);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public bool CanSave
        {
            get => _canSave;
            set => SetProperty(ref _canSave, value);
        }

        public string ResultText
        {
            get => _resultText;
            set => SetProperty(ref _resultText, value);
        }

        public DelegateCommand SaveCommand { get; private set; }

        private void Save()
        {
            ResultText = $"Saved at {DateTime.Now}";
        }
    }
}
