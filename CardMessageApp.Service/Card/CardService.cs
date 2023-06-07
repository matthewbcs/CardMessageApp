using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardMessageApp.Model;
using CardMessageApp.Model.Dto;
using CardMessageApp.Service.ChatGpt;
using OpenAI_API.Chat;

namespace CardMessageApp.Service.Card
{
    public interface ICardService
    {
        ChatResponse GetCardMessage(CardMessageRequestModel model);
    }
    public class CardService: ICardService
    {
        private IChatGPTService iChatGptService;

        public CardService(IChatGPTService iChatGptService)
        {
            this.iChatGptService = iChatGptService;
        }

        public ChatResponse GetCardMessage(CardMessageRequestModel model)
        {
            StringBuilder s = new StringBuilder();
            s.Append($"Can you write a message for a {model.Occasion.Name} card for my {model.Relation.Name}, named {model.Name}. ");

            if (model.Occasion.Occasion == EOccasion.Birthday)
                s.AppendLine($"The age of the person is {model.Age.Name}.");

            //attributes 
            if (model.AtrributesListing.Count(x => x.IsChecked) > 0)
            {
                List<string> toggleItems = model.AtrributesListing.Where(x => x.IsChecked == true).Select(x => x.Name).ToList();

                string personalityTraits = string.Join(", ", toggleItems);

                s.AppendLine(
                    $" here are some of the personality traits a love about this person to help write the message. ");
                s.AppendLine(personalityTraits + " ");
            }

            if (model.Poetic)
            {
                s.AppendLine("Could you also make the message poetic.");
            }
            s.AppendLine(" Also can you return your response in Json format");

            ChatResult chatResult = iChatGptService.AskChatGPT(s.ToString());

            ChatResponse response = new ChatResponse();
            response.Message = chatResult.Choices[0].Message.Content;
            response.WasSuccess = true;
            return response;

        }

    }
}
