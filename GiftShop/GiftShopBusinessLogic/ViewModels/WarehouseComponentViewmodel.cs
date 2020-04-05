using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace GiftShopBusinessLogic.ViewModels
{
    public class WarehouseComponentViewModel
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int ComponentId { get; set; }
        [DisplayName("Компонент")]
        public string ComponentName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}