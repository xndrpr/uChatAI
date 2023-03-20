using System;
using System.Windows;
using System.Windows.Controls;
using uChatAI.Models;
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

            ocrLanguage.SelectedIndex = Properties.Settings.Default.OcrLanguage;
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

        private void ocrLanguage_Loaded(object sender, RoutedEventArgs e)
        {
            ocrLanguage.SelectedIndex = Properties.Settings.Default.OcrLanguage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default["OcrLanguage"] = ocrLanguage.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.AutoTranslate = Convert.ToBoolean(autoTranslate.SelectedIndex);
            Properties.Settings.Default.Save();
        }

        private void autoTranslate_Loaded(object sender, RoutedEventArgs e)
        {
            autoTranslate.SelectedIndex = Properties.Settings.Default.AutoTranslate == true ? 1 : 0;
        }
    }
}
