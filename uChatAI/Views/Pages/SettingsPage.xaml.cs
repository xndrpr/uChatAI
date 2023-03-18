using System.Windows;
using System.Windows.Controls;
using uChatAI.ViewModels;

namespace uChatAI.Views.Pages
{
    public partial class SettingsPage : Page
    {
        private const string CHANGE = "Change";
        private const string CONFIRM = "Confirm";

        public SettingsPage()
        {
            InitializeComponent();
        }

        private void apiButton_Click(object sender, RoutedEventArgs e)
        {
            if ((string)apiButton.Content == CHANGE)
            {
                apiText.Text = Properties.Settings.Default.API;
                apiButton.Content = CONFIRM;
                apiText.IsReadOnly = false;
            }
            else if ((string)apiButton.Content == CONFIRM)
            {
                Properties.Settings.Default.API = apiText.Text;
                Properties.Settings.Default.Save();

                apiButton.Content = CHANGE;
                MainViewModel.mainPage = new MainPage();
                apiText.IsReadOnly = true;
            }
        }
    }
}
