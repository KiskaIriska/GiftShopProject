using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace GiftShopBusinessLogic.ViewModels
{
    [DataContract]
    public class GiftSetViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DisplayName("Название подарочного набора")]
        [DataMember]
        public string GiftSetName { get; set; }
        [DisplayName("Цена")]
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> GiftSetComponents { get; set; }
    }
}
