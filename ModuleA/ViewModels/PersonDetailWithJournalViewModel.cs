using Prism.Regions;
using Prism.Mvvm;
using Prism.Commands;

using PrismDemo.Core.Model;

namespace ModuleA.ViewModels
{
    public class PersonDetailWithJournalViewModel : BindableBase, INavigationAware
    {
        private IRegionNavigationJournal? _navigationJournal = null;
        private Person? _selectedPerson = null;

        public PersonDetailWithJournalViewModel()
        {
            GoBackCommand = new DelegateCommand(GoBack, CanGoBack);
        }

        public Person? SelectedPerson
        {
            get => _selectedPerson;
            set => SetProperty(ref _selectedPerson, value);
        }

        public DelegateCommand GoBackCommand
        {
            get;
        }

        private void GoBack()
        {
            _navigationJournal?.GoBack();
        }

        private bool CanGoBack() => ((_navigationJournal is not null) && _navigationJournal.CanGoBack);

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _navigationJournal = navigationContext.NavigationService.Journal;
            GoBackCommand.RaiseCanExecuteChanged();

            SelectedPerson = navigationContext.Parameters.GetValue<Person>("person");
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        { }
    }
}
