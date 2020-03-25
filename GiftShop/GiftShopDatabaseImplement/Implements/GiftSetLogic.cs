using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.Interfaces;
using GiftShopDatabaseImplement.Models;
using GiftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GiftShopDatabaseImplement;
using Microsoft.EntityFrameworkCore;


namespace GiftShopDatabaseImplement.Implements
{
    public class GiftSetLogic : IGiftSetLogic
    {
        public void CreateOrUpdate(GiftSetBindingModel model)
        {
            using (var context = new GiftShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        GiftSet element = context.GiftSets.FirstOrDefault(rec =>
                       rec.GiftSetName == model.GiftSetName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть изделие с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.GiftSets.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
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
        public void Delete(GiftSetBindingModel model)
        {
            using (var context = new GiftShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.GiftSetComponents.RemoveRange(context.GiftSetComponents.Where(rec =>
                        rec.GiftSetId == model.Id));
                        GiftSet element = context.GiftSets.FirstOrDefault(rec => rec.Id
                        == model.Id);
                        if (element != null)
                        {
                            context.GiftSets.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
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
        public List<GiftSetViewModel> Read(GiftSetBindingModel model)
        {
            using (var context = new GiftShopDatabase())
            {
                return context.GiftSets
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new GiftSetViewModel
               {
                   Id = rec.Id,
                   GiftSetName = rec.GiftSetName,
                   Price = rec.Price,
                   GiftSetComponents = context.GiftSetComponents
                .Include(recPC => recPC.Component)
               .Where(recPC => recPC.GiftSetId == rec.Id)
               .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
               })
               .ToList();
            }
        }
    }
}