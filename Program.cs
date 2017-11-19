using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

using System.Text.RegularExpressions;

using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputMessageContents;
using Telegram.Bot.Types.ReplyMarkups;

namespace TommyBot {
    class Program {
        private static readonly TelegramBotClient bot = new TelegramBotClient("477820301:AAFUaR6zsrnNwKrkdfrLZtnRETv_Dj9xvRs");
        static void Main(string[] args) {
            bot.OnMessage += HandleMessage;
            bot.OnReceiveError += BotOnReceiveError;

            var me = bot.GetMeAsync().Result;

            Console.Title = me.Username;

            Console.WriteLine("Bot started......");
            bot.StartReceiving();
            Console.ReadLine();
            bot.StopReceiving();
            Console.WriteLine("Terminated");

        }
        private static async void HandleMessage(Object sender, MessageEventArgs args) {
            var message = args.Message;
            if(message == null || message.Type != MessageType.TextMessage) {
                return;
            }
            switch(message.Text.ToLower()) {
                case "hi":
                case "hello":
                    await bot.SendTextMessageAsync(message.Chat.Id, "O hai Mark");
                    break;
                case "you hit her":
                case "you hit her!":
                case "did you hit her":
                case "did you hit her?":
                    await bot.SendTextMessageAsync(message.Chat.Id, "I did naaht hit her, ITS NAAHT TRUE, ITS BULLSHIT, I DID NAAHT HIT HER, i did naaht");
                    break;
                case "you are my favorite customer":
                    await bot.SendTextMessageAsync(message.Chat.Id, "O hai Doggy");
                    break;
                case "can you tell me about it?":
                    await bot.SendTextMessageAsync(message.Chat.Id, "I can not tell you. Its Confidential. Anyway, how's your sex life?");
                    break;
                case "how are you?":
                    await bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);
                    const string file = @"Tommy.jpg";
                    var fileName = file.Split('\\').Last();
                    using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read)) {
                        var fts = new FileToSend(fileName, fileStream);
                        await bot.SendPhotoAsync(message.Chat.Id, fts, "This is haw I am");
                    }
                    break;
                default:
                    await bot.SendTextMessageAsync(message.Chat.Id, "I definitely have breast cancer");
                    break;
            }
        }
        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Debugger.Break();
        }
    }
}