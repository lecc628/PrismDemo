using Prism.Mvvm;

using PrismDemo.Core.Model;

namespace ModuleA.ViewModels
{
    public class PersonDetailViewModel : BindableBase
    {
        private Person _selectedPerson = Person.PersonByDefault;

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { SetProperty(ref _selectedPerson, value); }
        }
    }
}
