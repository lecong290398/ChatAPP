using Prism;
using Prism.Ioc;
using TemplateXamarinV1.ViewModels;
using TemplateXamarinV1.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using TemplateXamarinV1.Models;

namespace TemplateXamarinV1
{
    public partial class App
    {
        public App()
            : base(null)
        {
        }

        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            base.OnStart();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            base.OnSleep();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            base.OnResume();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<InitParam>();


            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<MainPage>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //LocalAccountHelper.LoadUser();
            //var saveUser = LocalAccountHelper.UserInfo;

            //if (saveUser == null)
            //{
            //    await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(LoginPage)}");
            //}
            //else
            //{
                await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(Views.MainPage)}");
            //}
        }
    }
}
