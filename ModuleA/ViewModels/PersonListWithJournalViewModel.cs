using System.Collections.ObjectModel;

using Prism.Regions;
using Prism.Mvvm;
using Prism.Commands;

using PrismDemo.Core.Model;
using PrismDemo.Core.Names;

namespace ModuleA.ViewModels
{
    public class PersonListWithJournalViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager _regionManager;
        private IRegionNavigationJournal? _navigationJournal = null;

        public PersonListWithJournalViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            CreatePersonList();
            PersonSelectedCommand = new DelegateCommand<Person>(ShowPersonDetail);
            GoForwardCommand = new DelegateCommand(GoForward, CanGoForward);
        }

        public ObservableCollection<Person> People
        {
            get;
        } = new();

        public DelegateCommand<Person> PersonSelectedCommand
        {
            get;
        }

        private void ShowPersonDetail(Person person)
        {
            var navigationParameters = new NavigationParameters
            {
                { "person", person }
            };

            _regionManager.RequestNavigate(ApplicationRegionNames.PersonWithNavigationJournalRegion, ApplicationViewNames.PersonDetailWithJournalView, navigationParameters);
        }

        public DelegateCommand GoForwardCommand
        {
            get;
        }

        private void GoForward()
        {
            _navigationJournal?.GoForward();
        }

        private bool CanGoForward() => ((_navigationJournal is not null) && _navigationJournal.CanGoForward);

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _navigationJournal = navigationContext.NavigationService.Journal;
            GoForwardCommand.RaiseCanExecuteChanged();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        { }

        private void CreatePersonList()
        {
            People.Add(new Person { FirstName = "FirstName 0", LastName = "LastName 0", Age = 0 });
            People.Add(new Person { FirstName = "FirstName 1", LastName = "LastName 1", Age = 1 });
            People.Add(new Person { FirstName = "FirstName 2", LastName = "LastName 2", Age = 2 });
            People.Add(new Person { FirstName = "FirstName 3", LastName = "LastName 3", Age = 3 });
        }
    }
}
