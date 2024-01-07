using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using UtilityBot.Configuration;
using UtilityBot.Services;
using UtilityBoy.Utilities;

namespace UtilityBoy.Services
{
    public class TextHandler : ITextHandler
    {
        private readonly AppSettings _appSettings;
        private readonly ITelegramBotClient _telegramBotClient;

        public TextHandler(ITelegramBotClient telegramBotClient, AppSettings appSettings)
        {
            _appSettings = appSettings;
            _telegramBotClient = telegramBotClient;
        }
        public string Process(string param, string code)
        {
            Console.WriteLine("Начинаем обработку ввода...");
            string result = String.Empty;
            switch (code)
            {
                case "qua": result = "Количество введеных символов - " + param.Length.ToString(); break; 
                case "sum": result = "Сумма введеных символов - " + TextConverter.CountSymbolSum(param); break;
            }
            Console.WriteLine("Ввод обработан");
            return result;
        }
    }
}
