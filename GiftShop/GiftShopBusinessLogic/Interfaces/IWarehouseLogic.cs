using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GiftShopBusinessLogic.Interfaces
{
    public interface IWarehouseLogic
    {
        List<WarehouseViewModel> GetList();
        WarehouseViewModel GetElement(int id);
        void AddElement(WarehouseBindingModel model);
        void UpdElement(WarehouseBindingModel model);
        void DelElement(int id);
        void AddComponent(WarehouseComponentBindingModel model);
    }
}