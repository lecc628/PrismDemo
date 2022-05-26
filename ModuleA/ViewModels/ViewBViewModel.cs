using Prism.Mvvm;
using Prism.Regions;

namespace ModuleA.ViewModels
{
    public class ViewBViewModel : BindableBase, INavigationAware
    {
        private int _pageViewedCount = 0;
        private string _pageViewedCountAsString = string.Empty;

        public ViewBViewModel()
        {
            _pageViewedCountAsString = _pageViewedCount.ToString();
        }

        public string PageViewedCountAsString
        {
            get { return _pageViewedCountAsString; }
            private set { SetProperty(ref _pageViewedCountAsString, value); }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            PageViewedCountAsString = $"{++_pageViewedCount}";
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        { }
    }
}
