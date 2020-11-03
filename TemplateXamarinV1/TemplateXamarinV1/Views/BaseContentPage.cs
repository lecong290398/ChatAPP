using Prism;
using Prism.DryIoc;
using Prism.Events;
using Xamarin.Forms;

namespace TemplateXamarinV1.Views
{
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            if (PrismApplicationBase.Current is PrismApplication app)
            {
                EventAggregator = (IEventAggregator)app.Container.Resolve(typeof(IEventAggregator));
            }
        }

        protected IEventAggregator EventAggregator { get; }
    }
}
