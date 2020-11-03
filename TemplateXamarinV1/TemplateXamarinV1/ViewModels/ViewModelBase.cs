using Prism.AppModel;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TemplateXamarinV1.Attributes;
using TemplateXamarinV1.Models;

namespace TemplateXamarinV1.ViewModels
{

    internal class ViewModelBase : BindableBase, INavigationAware, IDestructible, IApplicationLifecycleAware
    {
        private ViewModelBase()
        {
            var thisType = GetType();

            do
            {
                if (thisType == null)
                {
                    break;
                }

                var methods = thisType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(h => h.GetCustomAttributes<InitializeAttribute>().Any())
                    .ToList();

                foreach (var method in methods)
                {
                    method.Invoke(this, null);
                }

                if (thisType == typeof(BindableBase))
                {
                    break;
                }

                thisType = thisType.BaseType;
            } while (true);
        }

        public ViewModelBase(InitParam initParam) : this()
        {
            NavigationService = initParam.NavigationService;
            DialogService = initParam.DialogService;
            EventAggregator = initParam.EventAggregator;

            initParam.CleanUp();
        }

        protected INavigationService NavigationService { get; private set; }
        protected IPageDialogService DialogService { get; private set; }
        protected IEventAggregator EventAggregator { get; private set; }

        public virtual void Destroy()
        {
            NavigationService = null;
            DialogService = null;
            EventAggregator = null;
        }


        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        protected async Task HandleError(Exception ex)
        {
            await DialogService.DisplayAlertAsync(
                "Lỗi",
                "Đã có lỗi trong quá trình xử lý. Vui lòng liên hệ nhà quản trị.",
                "Đóng"
            );
        }

        public virtual void OnResume()
        {

        }

        public virtual void OnSleep()
        {

        }

        #region TitleBindProp

        private string _titleBindProp = "";

        public string TitleBindProp
        {
            get => _titleBindProp;
            set => SetProperty(ref _titleBindProp, value);
        }

        #endregion

        #region IsBusyBindProp

        private bool _isBusyBindProp;

        public bool IsBusyBindProp
        {
            get => _isBusyBindProp;
            set
            {
                SetProperty(ref _isBusyBindProp, value);
                IsNotBusyBindProp = !IsBusyBindProp;
            }
        }

        #endregion

        #region IsNotBusyBindProp

        private bool _isNotBusyBindProp = true;

        public bool IsNotBusyBindProp
        {
            get => _isNotBusyBindProp;
            private set => SetProperty(ref _isNotBusyBindProp, value);
        }

        #endregion

    }
}
