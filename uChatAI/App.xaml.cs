using System.Windows;
using uChatAI.Services;

namespace uChatAI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ViewModelLocator.Init();

            base.OnStartup(e);
        }
    }
}
