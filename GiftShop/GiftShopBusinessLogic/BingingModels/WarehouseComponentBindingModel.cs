
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GiftShopBusinessLogic.BingingModels
{
    public class WarehouseComponentBindingModel
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }
    }
}