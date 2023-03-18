using DevExpress.Mvvm;
using System.Windows.Input;
using System.Windows;
using uChatAI.Services;
using uChatAI.Views.Pages;

namespace uChatAI.ViewModels
{
    public class AuthorizationViewModel : BindableBase
    {
        private readonly PageService _pageService;

        public string API { get; set; }

        public AuthorizationViewModel(PageService pageService)
        {
            _pageService = pageService;
        }


        public ICommand ContinueCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Properties.Settings.Default["API"] = API;
                    Properties.Settings.Default.Save();

                    _pageService.Navigate(new MainPage());
                });
            }
        }
    }
}
