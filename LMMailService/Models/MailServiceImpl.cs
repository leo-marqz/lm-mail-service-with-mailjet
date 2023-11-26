using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LMMailService.Models
{
    public class MailServiceImpl : IMailService
    {
        private readonly MailSettings _settings;
        private readonly MailjetClient _client;

        public MailServiceImpl(MailSettings mailSettings)
        {
            _settings = mailSettings;
            _client = new MailjetClient(_settings.APIKey, _settings.SecretKey);
            _client.Version = ApiVersion.V3_1;
        }

        public async Task<bool> SendAsync(MailContent content)
        {
            try
            {
                var request = new MailjetRequest
                {
                    Resource = Send.Resource
                }
                .Property(Send.Messages, new JArray {
                    new JObject {
                        {"From", new JObject {
                                {"Email", content.From },
                                {"Name", content.FromName}
                            }
                        },
                        {"To", new JArray {
                                new JObject {
                                    {"Email", content.To},
                                    {"Name", content.ToName }
                                }
                            }
                        },
                        {"Subject", content.Subject},
                        {"HTMLPart", content.Body}
                    }
                });


                MailjetResponse response = await _client.PostAsync(request);

                var error = response.GetErrorMessage();
                Console.WriteLine(error);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception("Error, el mail no fue enviado");
            }
        }

        public Task<bool> SendAsync(MailContent content, string token = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendAsync(string from, string to, string subject, string body)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendAsync(string from, string to, string subject, string body, byte[] file)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendAsync(string from, string to, string subject, string body, Stream file)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendAsync(string from, string to, string subject, string body, MailAttach[] files)
        {
            throw new NotImplementedException();
        }
    }
}
