using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GiftShopListImplement.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string ClientFIO { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}