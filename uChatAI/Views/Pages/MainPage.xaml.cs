using System.Linq;
using System.Windows;
using System.Windows.Controls;
using uChatAI.ViewModels;

namespace uChatAI.Views.Pages
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ScrollViewer_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                ((MainViewModel)DataContext).DragFile(files.First());
            }
        }
    }
}
