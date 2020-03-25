using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShopBusinessLogic.Interfaces
{
    public interface IGiftSetLogic
    {
        List<GiftSetViewModel> Read(GiftSetBindingModel model);
        void CreateOrUpdate(GiftSetBindingModel model);
        void Delete(GiftSetBindingModel model);
    }
}
