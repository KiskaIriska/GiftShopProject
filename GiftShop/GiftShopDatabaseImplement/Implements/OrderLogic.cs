using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.Interfaces;
using GiftShopBusinessLogic.ViewModels;
using GiftShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftShopDatabaseImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {

        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new GiftShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Order element = context.Orders.FirstOrDefault(rec =>
                       rec.GiftSetName == model.GiftSetName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть заказ с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.GiftSets.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception(" не найден");
                            }
                        }
                        else
                        {
                            element = new GiftSet();
                            context.GiftSets.Add(element);
                        }
                        element.GiftSetName = model.GiftSetName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var productComponents = context.GiftSetComponents.Where(rec
                           => rec.GiftSetId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели

                            context.GiftSetComponents.RemoveRange(productComponents.Where(rec =>
                            !model.GiftSetComponents.ContainsKey(rec.ComponentId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateComponent in productComponents)
                            {
                                updateComponent.Count =
                               model.GiftSetComponents[updateComponent.ComponentId].Item2;

                                model.GiftSetComponents.Remove(updateComponent.ComponentId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.GiftSetComponents)
                        {
                            context.GiftSetComponents.Add(new GiftSetComponent
                            {
                                GiftSetId = element.Id,
                                ComponentId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new GiftShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {                   
                        context.GiftSets.RemoveRange(context.GiftSets.Where(rec =>
                        rec.Id == model.GiftSetId));
                        GiftSet element = context.GiftSets.FirstOrDefault(rec => rec.Id
                        == model.Id);
                        if (element != null)
                        {
                            context.GiftSets.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Заказ не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new GiftShopDatabase())
            {
                return context.Orders
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new OrderViewModel
               {
                   Id = rec.Id,
                   GiftSetName = context.GiftSets.FirstOrDefault((r) => r.Id ==
                           model.GiftSetId).GiftSetName,
                   Count = rec.Count,
                   Sum = rec.Sum,
                   Status = rec.Status,
                   DateCreate = rec.DateCreate,
                   DateImplement = rec.DateImplement                
               })
               .ToList();
            }
        }      
    }
}
