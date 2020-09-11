using GiftShopBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GiftShopBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel : BaseViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Column(title: "ФИО клиента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ClientFIO { get; set; }

        [DataMember]
        [Column(title: "Почта", width: 150)]
        public string Email { get; set; }

        [DataMember]
        [Column(title: "Пароль", width: 150)]
        public string Password { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "ClientFIO",
            "Email"
        };
    }
}