using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.Enums;
using GiftShopBusinessLogic.Interfaces;
using GiftShopBusinessLogic.ViewModels;
using GiftShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftShopFileImplement.Implements
{
    public class MainLogic : IMainLogic
    {
        private readonly FileDataListSingleton source;

        public MainLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<OrderViewModel> GetOrders()
        {
            List<OrderViewModel> result = source.Orders.Select(rec => new OrderViewModel
            {       Id = rec.Id,
                    GiftSetId = rec.GiftSetId,
                    GiftSetName = source.GiftSets.FirstOrDefault()?.GiftSetName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    Status = rec.Status
              })
            .ToList();
            return result;
        }


        public void CreateOrder(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
        
            source.Orders.Add(new Order
            {
                Id = maxId + 1,
                GiftSetId = model.GiftSetId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });
        }


        public void TakeOrderInWork(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Status
           != OrderStatus.Принят);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element != null)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            element.DateImplement = DateTime.Now;
            element.Status = OrderStatus.Выполняется;
        }


        public void FinishOrder(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Status
          != OrderStatus.Выполняется);
           
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element != null)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = OrderStatus.Готов;
        }


        public void PayOrder(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Status
           != OrderStatus.Готов );
   
            if (element  == null)
            {
                throw new Exception("Элемент не найден");
            }

            if (element != null)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }

           element.DateImplement = DateTime.Now;
           element.Status = OrderStatus.Оплачен;
        }
    }
}
