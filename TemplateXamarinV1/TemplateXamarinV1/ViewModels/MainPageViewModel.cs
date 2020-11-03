using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TemplateXamarinV1.Models;

namespace TemplateXamarinV1.ViewModels
{
    internal class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(InitParam initParam) : base(initParam)
        {
            TitleBindProp = "Giới Thiệu / Liên Hệ";
        }

    }
}
