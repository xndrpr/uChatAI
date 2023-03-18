using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace uChatAI.Controls
{
    public partial class CodePreview : UserControl
    {
        public TextDocument Document
        {
            get { return (TextDocument)GetValue(DocumentProperty); }
            set { SetValue(DocumentProperty, value); }
        }

        public static readonly DependencyProperty DocumentProperty =
            DependencyProperty.Register("Document", typeof(TextDocument), typeof(CodePreview), new PropertyMetadata(null));

        public string Background
        {
            get { return (string)GetValue(BackgroundPropertry); }
            set { SetValue(BackgroundPropertry, value); }
        }

        public static readonly DependencyProperty BackgroundPropertry =
            DependencyProperty.Register("Background", typeof(string), typeof(CodePreview), new PropertyMetadata("#B9B9B9"));

        public CodePreview()
        {
            InitializeComponent();
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var s = combobox.SelectedItem.ToString()!.Replace("System.Windows.Controls.ComboBoxItem: ", "");
            code.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition(s);
        }
    }
}
