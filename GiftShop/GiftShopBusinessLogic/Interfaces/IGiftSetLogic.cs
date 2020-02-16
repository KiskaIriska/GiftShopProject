using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShopBusinessLogic.Interfaces
{
    public interface IGiftSetLogic
    {
        List<GiftSetViewModel> GetList();
        GiftSetViewModel GetElement(int id);
        void AddElement(GiftSetBindingModel model);
        void UpdElement(GiftSetBindingModel model);
        void DelElement(int id);
    }
}
