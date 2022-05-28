using System.Collections.ObjectModel;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Regions;

using PrismDemo.Core.Model;
using PrismDemo.Core.Names;

namespace ModuleA.ViewModels
{
    public class PersonListViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public PersonListViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            CreatePersonList();
            PersonSelectedCommand = new DelegateCommand<Person>(ShowPersonDetail);
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
            NavigationParameters navigationParameters = new()
            {
                { "person", person }
            };

            _regionManager.RequestNavigate(ApplicationRegionNames.PersonDetailRegion, ApplicationViewNames.PersonDetailView, navigationParameters);
        }

        private void CreatePersonList()
        {
            People.Add(new Person { FirstName = "FirstName 0", LastName = "LastName 0", Age = 0 });
            People.Add(new Person { FirstName = "FirstName 1", LastName = "LastName 1", Age = 1 });
            People.Add(new Person { FirstName = "FirstName 2", LastName = "LastName 2", Age = 2 });
            People.Add(new Person { FirstName = "FirstName 3", LastName = "LastName 3", Age = 3 });
        }
    }
}
