using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShopBusinessLogic.ViewModels
{
    public class ReportGiftSetComponentViewModel
    {
        public string ComponentName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> GiftSets { get; set; }
    }
}
