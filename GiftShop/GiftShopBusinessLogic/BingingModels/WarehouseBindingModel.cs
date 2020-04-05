using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GiftShopBusinessLogic.BingingModels
{
    public class WarehouseBindingModel
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public List<WarehouseComponentBindingModel> WarehouseComponent { get; set; }
    }
}