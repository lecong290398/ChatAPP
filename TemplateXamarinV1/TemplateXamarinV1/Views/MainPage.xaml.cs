using Xamarin.Forms.Xaml;

namespace TemplateXamarinV1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            //this.ToolbarItems.Remove(tbiLogout);
        }
    }
}
