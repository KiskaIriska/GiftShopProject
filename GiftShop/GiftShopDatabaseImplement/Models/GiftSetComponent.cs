using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GiftShopDatabaseImplement.Models
{
    public class GiftSetComponent
    {
        public int Id { get; set; }
        public int GiftSetId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Component { get; set; }
        public virtual GiftSet GiftSet { get; set; }
    }

}
