using Prism.Mvvm;
using Prism.Regions;

using PrismDemo.Core.Model;

namespace ModuleA.ViewModels
{
    public class PersonDetailViewModel : BindableBase, INavigationAware
    {
        private Person? _selectedPerson = null;

        public Person? SelectedPerson
        {
            get => _selectedPerson;
            set => SetProperty(ref _selectedPerson, value);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var person = navigationContext.Parameters.GetValue<Person>("person");

            if ((SelectedPerson is not null) && (person is not null) && (SelectedPerson.LastName == person.LastName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            SelectedPerson = navigationContext.Parameters.GetValue<Person>("person");
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        { }
    }
}
