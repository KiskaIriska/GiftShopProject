using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShopBusinessLogic.BingingModels
{
    public class GiftSetComponentBindingModel
    {
        public int Id { get; set; }
        public int GiftSetId { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }
    }
}
