using DevExpress.Mvvm;
using OpenAI.GPT3.ObjectModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
                        var message = new Message()
                        {
                            Text = Message,
                            Icon = "M12,19.2C9.5,19.2 7.29,17.92 6,16C6.03,14 10,12.9 12,12.9C14,12.9 17.97,14 18,16C16.71,17.92 14.5,19.2 12,19.2M12,5A3,3 0 0,1 15,8A3,3 0 0,1 12,11A3,3 0 0,1 9,8A3,3 0 0,1 12,5M12,2A10,10 0 0,0 2,12A10,10 0 0,0 12,22A10,10 0 0,0 22,12C22,6.47 17.5,2 12,2Z"
                        };
                        Messages.Add(message);
                        Message = string.Empty;

                        var response = await _openAIService.SendMessage(message, ChatMessages);

                        StringBuilder stringBuilder = new StringBuilder();
                        int counter = 0;
                        foreach (char c in response.BotResponse!)
                        {
                            stringBuilder.Append(c);
                            counter++;
                            if (counter % 100 == 0 && counter != 0)
                            {
                                stringBuilder.Append("\n");
                            }
                        }
                        response.Text = stringBuilder.ToString();

                        ChatMessages.Add(ChatMessage.FromUser(message.Text));
                        ChatMessages.Add(ChatMessage.FromAssistance(response.BotResponse));

                        Messages.Add(response);
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
                    }
                });
            }
        }
    }
}
