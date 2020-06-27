using GiftShopBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GiftShopBusinessLogic.ViewModels
{
    public class ComponentViewModel : BaseViewModel

    {

        public int Id { get; set; }
        [Column(title: "Компонент", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
        public override List<string> Properties() => new List<string>
        {
           
            "ComponentName"
        };

    }
}
