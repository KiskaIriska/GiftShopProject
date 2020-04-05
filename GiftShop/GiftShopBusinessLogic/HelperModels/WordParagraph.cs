using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShopBusinessLogic.HelperModels
{
    class WordParagraph
    {
        public List<string> Texts { get; set; }
        public List<string> TextGiftSetName{ get; set; }
        public List<string> TextPrice { get; set; }
        public WordParagraphProperties TextProperties { get; set; }
        public WordParagraphProperties TextProperties2 { get; set; }
    }
}
