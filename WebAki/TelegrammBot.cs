using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;

namespace WebAki
{
    
    public class TelegrammBot
    {
        private class Dei
        {
            
        }

        private readonly IConfiguration _configuration;

        public TelegrammBot(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        
        public async Task<TelegramBotClient> GetBot()
        {
            var telegramBot = new TelegramBotClient(_configuration["Token"]);


            var hooc = $"{_configuration["Url"]} api/message/update";
            await telegramBot.SetWebhookAsync(hooc);
            return telegramBot;
        }

      
    }

    
}