using GiftShopBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace GiftShopBusinessLogic.ViewModels
{
    [DataContract]
    public class GiftSetViewModel : BaseViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [Column(title: "Название подарочного набора", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string GiftSetName { get; set; }

        [Column(title: "Цена", width: 50)]
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> GiftSetComponents { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "GiftSetName",
            "Price"
        };    }
}
