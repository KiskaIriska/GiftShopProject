using GiftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShopBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportGiftSetComponentViewModel> GiftSetComponents { get; set; }
    }
}
