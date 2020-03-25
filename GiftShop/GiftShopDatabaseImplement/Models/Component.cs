using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GiftShopDatabaseImplement.Models
{
        public class Component
        {
            public int Id { get; set; }

            [Required]
            public string ComponentName { get; set; }

            [ForeignKey("ComponentId")]
            public virtual List<GiftSetComponent> GiftSetComponents { get; set; }
        }  
}
