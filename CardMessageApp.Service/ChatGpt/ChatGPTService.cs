using OpenAI_API.Chat;
using OpenAI_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardMessageApp.Model;

namespace CardMessageApp.Service.ChatGpt
{
    public interface IChatGPTService
    {
        ChatResult AskChatGPT(string question, int maxTokenCount = 100);
    }
    public class ChatGPTService: IChatGPTService
    {
        private string APIKey = "";
        private OpenAIAPI openApi;
        private IAppSettingsService _appSettingsService;

        public ChatGPTService(IAppSettingsService appSettingsService)
        {
            _appSettingsService = appSettingsService;
            APIKey = _appSettingsService.GetSetting(EAppSetting.ChatGptToken);
            openApi = new OpenAI_API.OpenAIAPI(APIKey);
        }
        public ChatResult AskChatGPT(string question, int maxTokenCount = 100)
        {


            ChatResult chatResult = openApi.Chat.CreateChatCompletionAsync(new ChatRequest()
            {
                Model = OpenAI_API.Models.Model.ChatGPTTurbo,
                Temperature = 0.1,// high the number the more risker thing it my say 
                MaxTokens = maxTokenCount,
                Messages = new ChatMessage[]
                {
                    new ChatMessage(ChatMessageRole.User, question)
                }
            }).Result;

            //string result =  openApi.Completions.CreateCompletionAsync(Cr).Result;
            //Conversation conversation = openApi.Chat.CreateConversation();
            //conversation.AppendUserInput("Is this an animal? Dog");
            //string result = conversation.GetResponseFromChatbotAsync().Result;

            //ChatGptResponseDto responseModel = new ChatGptResponseDto();
            // responseModel.Response = chatResult;

            return chatResult;
        }
    }
}
