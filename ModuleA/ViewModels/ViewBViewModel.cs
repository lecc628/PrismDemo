using System;
using System.Windows;

using Prism.Mvvm;
using Prism.Regions;

namespace ModuleA.ViewModels
{
    public class ViewBViewModel : BindableBase, IConfirmNavigationRequest
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

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            var result = true;

            if (MessageBox.Show("Do you want to navigate?", "Navigate?", MessageBoxButton.YesNo,
                MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.No)
            {
                result = false;
            }

            continuationCallback(result);
        }
    }
}
