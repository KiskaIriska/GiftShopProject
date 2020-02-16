using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GiftShopBusinessLogic.ViewModels
{
    public class GiftSetComponentViewModel
    {
        public int Id { get; set; }
        public int GiftSetId { get; set; }
        public int ComponentId { get; set; }
        [DisplayName("Компонент")]
        public string ComponentName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
