using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GiftShopBusinessLogic.ViewModels
{
    public class GiftSetViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название подарочного набора")]
        public string GiftSetName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> GiftSetComponents { get; set; }
    }
}
