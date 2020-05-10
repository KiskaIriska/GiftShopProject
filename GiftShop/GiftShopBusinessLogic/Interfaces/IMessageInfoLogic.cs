using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShopBusinessLogic.Interfaces
{
    public interface IMessageInfoLogic
    {
        List<MessageInfoViewModel> Read(MessageInfoBindingModel model);
        void Create(MessageInfoBindingModel model);
    }
}
