using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using UtilityBoy.Services;
using UtilityBot.Services;
using UtilityBot.Configuration;

namespace UtilityBot.Controllers
{
    public class TextMessageController
    {
        private readonly IStorage _memoryStorage; // Добавим это
        private readonly ITelegramBotClient _telegramClient;
        private readonly AppSettings _appSetting;

        public TextMessageController(ITelegramBotClient telegramBotClient, IStorage memoryStorage, AppSettings appSettings)
        {
            _telegramClient = telegramBotClient;
            _memoryStorage = memoryStorage; // и это
            _appSetting = appSettings;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                case "/start":

                    // Объект, представляющий кноки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($" Подсчитать символы" , $"qua"),
                        InlineKeyboardButton.WithCallbackData($" Сложить цифры" , $"sum"),
                    });

                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"<b>  Наш бот считает символы.</b> {Environment.NewLine}" +
                        $"{Environment.NewLine}или складывает цифры.{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));

                    break;
                default:
                    string userChoiceCode = _memoryStorage.GetSession(message.Chat.Id).ChoiceCode; // Здесь получим язык из сессии пользователя
                    var TH = new TextHandler(_telegramClient, _appSetting);
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, TH.Process(message.Text, userChoiceCode), cancellationToken: ct);
                    break;
            }
        }
    }
}
