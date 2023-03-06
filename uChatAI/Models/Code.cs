using ICSharpCode.AvalonEdit.Document;

namespace uChatAI.Models
{
    public class Code
    {
        public int Id { get; set; }
        public TextDocument? Document { get; set; }
        public string? Text { get; set; }
        public string? Title { get; set; }
        public string? Language { get; set; }
    }
}
