using GiftShopBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace GiftShopBusinessLogic.ViewModels
{
    public class ImplementerViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ImplementerFIO { get; set; }

        [Column(title: "Время на заказ", width: 100)] 
        public int WorkingTime { get; set; }
       
        [Column(title: "Время на перерыв", width: 100)]
        public int PauseTime { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "ImplementerFIO",
            "WorkingTime",
            "PauseTime"
        };
    }
}
