using GiftShopBusinessLogic.Enums;

using System;

using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using System.Text;

namespace GiftShopDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int GiftSetId { get; set; }
        public int ClientId { get; set; }

        [Required]

        public int Count { get; set; }
  
        [Required]
        public string ClientFIO { get; set; }

        [Required]

        public decimal Sum { get; set; }

        [Required]

        public OrderStatus Status { get; set; }

        [Required]

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }

        public virtual GiftSet GiftSet { get; set; }
    }
}
