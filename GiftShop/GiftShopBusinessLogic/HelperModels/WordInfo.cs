using GiftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShopBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ComponentViewModel> Components { get; set; }
    }
}
