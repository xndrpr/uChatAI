using DevExpress.Mvvm;
using OpenAI.GPT3.ObjectModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using uChatAI.Models;
using uChatAI.Services;
using uChatAI.Views.Pages;

namespace uChatAI.ViewModels
{ 
    public class MainViewModel : BindableBase
    {
        public static MainPage mainPage = new MainPage();

        private readonly PageService _pageService;
        private readonly OpenAiService _openAIService;
        private readonly List<ChatMessage> ChatMessages = new List<ChatMessage>();

        public Page CurrentPage { get; set; }
        public ObservableCollection<Message> Messages { get; set; } = new ObservableCollection<Message>();
        public ObservableCollection<Code> Codes { get; set; } = new ObservableCollection<Code>();
        public Message SelectedMessage { get; set; }
        public string Message { get; set; }

        public MainViewModel(PageService pageService)
        {
            _pageService = pageService;
            _pageService.OnPageChanged += page => CurrentPage = page;
            CurrentPage = mainPage;

            _openAIService = new OpenAiService();
        }

        public ICommand SendMessageCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    try
                    {
                        if (Message.Length < 2) return;
                        var message = new Message()
                        {
                            Text = Message,
                            Icon = "M12,19.2C9.5,19.2 7.29,17.92 6,16C6.03,14 10,12.9 12,12.9C14,12.9 17.97,14 18,16C16.71,17.92 14.5,19.2 12,19.2M12,5A3,3 0 0,1 15,8A3,3 0 0,1 12,11A3,3 0 0,1 9,8A3,3 0 0,1 12,5M12,2A10,10 0 0,0 2,12A10,10 0 0,0 12,22A10,10 0 0,0 22,12C22,6.47 17.5,2 12,2Z"
                        };
                        var messageWords = message!.Text!.Split(" ");
                        string messageResult = "";

                        for (int i = 0; i < messageWords.Length; i++)
                        {
                            if (i > 0 && i % 14 == 0)
                            {
                                messageResult += "\n";
                            }
                            messageResult += messageWords[i] + " ";
                        }
                        message!.Text = messageResult;
                        Messages.Add(message);
                        Message = string.Empty;

                        var response = await _openAIService.SendMessage(message, ChatMessages);

                        var responseWords = response!.BotResponse!.Split(" ");
                        string responseResult = "";

                        for (int i = 0; i < responseWords.Length; i++) 
                        { 
                            if (i > 0 && i % 14 == 0) 
                            {
                                responseResult += "\n"; 
                            }
                            responseResult += responseWords[i] + " "; 
                        }
                        response!.Text = responseResult;

                        ChatMessages.Add(ChatMessage.FromUser(message.Text));
                        ChatMessages.Add(ChatMessage.FromAssistance(response.BotResponse));

                        Messages.Add(response);

                        List<int> indexes = new List<int>();
                        int index = response.BotResponse.IndexOf("```");

                        while (index != -1)
                        {
                            indexes.Add(index);
                            index = response.BotResponse.IndexOf("```", index + 1);
                        }

                        for (int i = 0; i < indexes.Count;)
                        {
                            if (indexes.Count >= i + 1)
                            {
                                string directory = response!.BotResponse!.Substring(indexes[i] + "```".Length, indexes[i + 1] - (indexes[i] + "```".Length));

                                if (directory.StartsWith("python"))
                                    directory.Remove(6);
                                else if (directory.StartsWith("xml"))
                                    directory.Remove(2);
                                else if (directory.StartsWith("csharp"))
                                    directory.Remove(6);
                                else if (directory.StartsWith("html"))
                                    directory.Remove(4);
                                else if (directory.StartsWith("js"))
                                    directory.Remove(2);
                                else if (directory.StartsWith("javascript"))
                                    directory.Remove(10);
                                else if (directory.StartsWith("go"))
                                    directory.Remove(2);
                                else if (directory.StartsWith("golang"))
                                    directory.Remove(6);
                                else if (directory.StartsWith("rust"))
                                    directory.Remove(4);
                                else if (directory.StartsWith("cpp"))
                                    directory.Remove(3);
                                else if (directory.StartsWith("c++"))
                                    directory.Remove(3);
                                else if (directory.StartsWith("c"))
                                    directory.Remove(1);
                                else if (directory.StartsWith("java"))
                                    directory.Remove(4);

                                Codes.Add(new Code()
                                {
                                    Id = Codes.Count + 1,
                                    Text = directory,
                                    Title = message.Text
                                });
                            }
                            if (indexes.Count >= i + 2)
                            {
                                i += 2;
                            }
                        }

                        //int start_index = response!.BotResponse!.IndexOf("```") + "```".Length;
                        //int end_index = response!.BotResponse!.LastIndexOf("```");
                        //int length = end_index - start_index;
                        //string directory = response!.BotResponse!.Substring(start_index, length);

                        //Codes.Add(new Code()
                        //{
                        //    Id = Codes.Count + 1,
                        //    Text = directory,
                        //    Title = message.Text
                        //});
                    }
                    catch (Exception ex)
                    {
                        Messages.Add(new Message()
                        {
                            BotResponse = $"Something went wrong due to exception: {ex.Message}"
                        });
                    }
                });
            }
        }

        public ICommand ClearChatCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var result = MessageBox.Show("Are you sure you want to the chat? All messages will be delated forever.", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        Messages.Clear();
                        Codes.Clear();
                    }
                });
            } 
        }

        public ICommand DeleteChatCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var result = MessageBox.Show("Are you sure you want to the chat? All messages will be delated forever.", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        Messages.Clear();
                        ChatMessages.Clear();
                        Codes.Clear();
                    }
                });
            }
        }

        public ICommand CopyMessageCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    try
                    {
                        Clipboard.SetText(SelectedMessage.Text);
                    }
                    catch { }
                });
            }
        }
    }
}
