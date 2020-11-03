using Prism.Events;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateXamarinV1.Models
{
    internal class InitParam
    {
        public InitParam(
            INavigationService navigationService,
            IPageDialogService dialogService,
            IEventAggregator eventAggregator
        )
        {
            NavigationService = navigationService;
            DialogService = dialogService;
            EventAggregator = eventAggregator;
        }

        public INavigationService NavigationService { get; private set; }
        public IPageDialogService DialogService { get; private set; }
        public IEventAggregator EventAggregator { get; private set; }

        public void CleanUp()
        {
            NavigationService = null;
            DialogService = null;
            EventAggregator = null;
        }
    }
}
