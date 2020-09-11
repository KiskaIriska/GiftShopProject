using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShopRestApi.Models
{
    public class GiftSetModel
    {
        public int Id { get; set; }
        public string GiftSetName { get; set; }
        public decimal Price { get; set; }
    }
}
