using LMMailService.Models;

namespace LMMailAPP
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var settings = new MailSettings
            {
                APIKey = "--",
                SecretKey = "--"
            };

            var content = new MailContent
            {
                From = "leomarqz2020@gmail.com",
                FromName = "Leo Marqz",
                To = "leo.marqz.crack@gmail.com",
                Subject = "Test...",
                Body = "Hello World from C# & .NET",
                Files = null
            };

            IMailService service = new MailServiceImpl(settings);
            bool isSend = await service.SendAsync(content);

            Console.WriteLine($"SendMailAsync: {isSend}");

        }
    }
}
