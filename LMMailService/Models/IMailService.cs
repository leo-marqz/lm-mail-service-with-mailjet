using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMMailService.Models
{
    public interface IMailService
    {
        Task<bool> SendAsync(MailContent content);
        Task<bool> SendAsync(MailContent content, string token = default);
        Task<bool> SendAsync(string from, string to, string subject, string body);
        Task<bool> SendAsync(string from, string to, string subject, string body, byte[] file);
        Task<bool> SendAsync(string from, string to, string subject, string body, Stream file);
        Task<bool> SendAsync(string from, string to, string subject, string body, MailAttach[] files);
    }
}
