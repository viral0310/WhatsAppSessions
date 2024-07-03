using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Models/WhatsAppSession.cs
namespace WhatsAppSessionApi.Models
{
    public class WhatsAppSession
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public string SessionPath { get; set; }
        public bool IsLoggedIn { get; set; }
        public string QrCodeFilePath { get; set; }
    }
}
