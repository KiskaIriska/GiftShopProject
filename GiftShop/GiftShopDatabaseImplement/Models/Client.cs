using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;

namespace GiftShopDatabaseImplement.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required]
        public string ClientFIO { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}