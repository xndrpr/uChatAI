using System.Threading.Tasks;
using OpenAI.GPT3;
using System;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using System.Collections.Generic;
using OpenAI.GPT3.ObjectModels;
using uChatAI.Models;
using System.Linq;
using DotNetEnv;

namespace uChatAI.Services
{
    public class OpenAiService
    {
        private readonly OpenAIService openAiService;

        public OpenAiService()
        {
            Env.Load();
            openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = Env.GetString("API")
            });
        }

        public async Task<Message?> SendMessage(Message message, List<ChatMessage> history)
        {
            try
            {
                var messages = new List<ChatMessage>()
                {
                    ChatMessage.FromUser(message.Text!)
                };
                history = history.Concat(messages).ToList();
                var completionResult = await openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
                {
                    Messages = history,
                    Model = OpenAI.GPT3.ObjectModels.Models.ChatGpt3_5Turbo
                });

                if (completionResult.Successful)
                {
                    return new Message()
                    {
                        Text = message.Text,
                        BotResponse = completionResult.Choices.First().Message.Content
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                return new Message()
                {
                    BotResponse = $"Something went wrong due to exception: {ex.Message}"
                };
            }
        }
    }
}
