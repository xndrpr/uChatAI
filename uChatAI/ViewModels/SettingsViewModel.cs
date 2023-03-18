using DevExpress.Mvvm;
using System.Windows.Input;
using uChatAI.Services;

namespace uChatAI.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        private readonly PageService _pageService;

        public string? API { get; set; } = Properties.Settings.Default.API;

        public SettingsViewModel(PageService pageService)
        {
            _pageService = pageService;
        }

        public ICommand BackCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _pageService.Navigate(MainViewModel.mainPage);
                });
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Properties.Settings.Default.API = string.Empty;
                    Properties.Settings.Default.Save();

                    _pageService.Navigate(MainViewModel.authorizationPage);
                });
            }
        }
    }
}
