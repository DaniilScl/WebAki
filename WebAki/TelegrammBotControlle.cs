using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using WebAki.Enttines;

namespace WebAki
{
    [ApiController]
    [Route("api/message")]
    public class TelegrammBotControlle : ControllerBase
    {
        private readonly TelegramBotClient _telegramBotClient;
        private readonly DataContext _context;
        
        public TelegrammBotControlle(TelegrammBot telegramBot, DataContext context)
        {
            _context = context;
            _telegramBotClient = telegramBot.GetBot().Result;
        }


        [HttpPost("update")]
        public async Task<IActionResult> Update(Update update)
        {
            // /start : Регистрация пользователя в базу данных

            var upd = JsonConvert.DeserializeObject<Update>(update.ToString()!);
            var chat = update.Message?.Chat;

            if (chat == null)
            {
                return Ok();
            }
            
            var appUser = new AppUser()
            {
                Username = chat?.Username,
                ChatId = chat!.Id,
                FirstName = chat.FirstName,
                LastName = chat.LastName
            };

            var result = await _context.Users.AddAsync(appUser);
            await _context.SaveChangesAsync();

            await _telegramBotClient.SendTextMessageAsync(chat.Id, "Вы успешно зарегистрировались!", (int?) ParseMode.Markdown);
            
            
            return Ok();
        }
    }

   
}