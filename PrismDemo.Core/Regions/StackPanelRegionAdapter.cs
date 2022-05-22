using System.Windows;
using System.Windows.Controls;

using Prism.Regions;

namespace PrismDemo.Core.Regions
{
    public class StackPanelRegionAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        { }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (sender, e) =>
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        {
                            if (e.NewItems is not null)
                            {
                                foreach (UIElement element in e.NewItems)
                                {
                                    regionTarget.Children.Add(element);
                                }
                            }
                            break;
                        }

                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        {
                            if (e.OldItems is not null)
                            {
                                foreach (UIElement element in e.OldItems)
                                {
                                    regionTarget.Children.Remove(element);
                                }
                            }
                            break;
                        }
                }
            };
        }

        /// <summary>
        /// The method can return an instance of these types: SingleActiveRegion, AllActiveRegion, or Region.
        /// </summary>
        /// <returns>Returns an instance of a class that implements the IRegion type.</returns>
        protected override IRegion CreateRegion() => new Region();
    }
}
