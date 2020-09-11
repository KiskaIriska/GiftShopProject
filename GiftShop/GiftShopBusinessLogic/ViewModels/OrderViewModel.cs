using GiftShopBusinessLogic.Attributes;
using GiftShopBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace GiftShopBusinessLogic.ViewModels
{
    [DataContract]
    public class OrderViewModel : BaseViewModel

    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int GiftSetId { get; set; }

        [DataMember]
        [Column(title: "Id исполнителя", width: 50)]
        public int? ImplementerId { get; set; }

        [Column(title: "Клиент", width: 150)]
        [DataMember]
        public string ClientFIO { get; set; }

        [Column(title: "Исполнитель", width: 100)]
        [DataMember]
        public string ImplementerFIO { get; set; }

        [Column(title: "Изделие", width: 100)]
        [DataMember]
        public string GiftSetName { get; set; }

        [Column(title: "Количество", width: 100)]
        [DataMember]
        public int Count { get; set; }


        [Column(title: "Сумма", width: 50)]
        [DataMember]
        public decimal Sum { get; set; }
        
        [Column(title: "Статус", width: 100)]
        [DataMember]
        [DisplayName("Статус")]
        public OrderStatus Status { get; set; }

        [Column(title: "Дата создания", width: 100)]
        [DataMember]
        public DateTime DateCreate { get; set; }

        [Column(title: "Дата выполнения", width: 100)]
        [DataMember]
        public DateTime? DateImplement { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "ImplementerId",
            "ClientFIO",
            "GiftSetName",
            "ImplementerFIO",
            "Count",
            "Sum",
            "Status",
            "DateCreate",
            "DateImplement"
        };
    }

}