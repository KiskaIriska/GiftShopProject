using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShopBusinessLogic.BingingModels
{
    public class GiftSetBindingModel
    {
        public int Id { get; set; }
        public string GiftSetName { get; set; }
        public decimal Price { get; set; }
        public List<GiftSetComponentBindingModel> ProductComponents { get; set; }
    }
}
