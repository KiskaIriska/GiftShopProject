using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.Interfaces;
using GiftShopBusinessLogic.ViewModels;
using GiftShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftShopFileImplement.Implements
{
    public class GiftSetLogic : IGiftSetLogic
    {
        private readonly FileDataListSingleton source;
        public GiftSetLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<GiftSetViewModel> GetList()
        {
            List<GiftSetViewModel> result = source.GiftSets
            .Select(rec => new GiftSetViewModel
            {
                Id = rec.Id,
                GiftSetName = rec.GiftSetName,
                Price = rec.Price,
                GiftSetComponents = source.GiftSetComponents
            .Where(recPC => recPC.GiftSetId == rec.Id)
           .Select(recPC => new GiftSetComponentViewModel
           {
               Id = recPC.Id,
               GiftSetId = recPC.GiftSetId,
               ComponentId = recPC.ComponentId,
               ComponentName = source.Components.FirstOrDefault(recC =>
    recC.Id == recPC.ComponentId)?.ComponentName,
               Count = recPC.Count
           })
           .ToList()
            })
            .ToList();
            return result;
        }


        public GiftSetViewModel GetElement(int id)
        {
            GiftSet element = source.GiftSets.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new GiftSetViewModel
                {
                    Id = element.Id,
                    GiftSetName = element.GiftSetName,
                    Price = element.Price,
                    GiftSetComponents = source.GiftSetComponents
                .Where(recPC => recPC.GiftSetId == element.Id)
               .Select(recPC => new GiftSetComponentViewModel
               {
                   Id = recPC.Id,
                   GiftSetId = recPC.GiftSetId,
                   ComponentId = recPC.ComponentId,
                   ComponentName = source.Components.FirstOrDefault(recC =>
    recC.Id == recPC.ComponentId)?.ComponentName,
                   Count = recPC.Count
               })
               .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(GiftSetBindingModel model)
        {
            GiftSet element = source.GiftSets.FirstOrDefault(rec => rec.GiftSetName ==
           model.GiftSetName);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            int maxId = source.GiftSets.Count > 0 ? source.GiftSets.Max(rec => rec.Id) :
           0;
            source.GiftSets.Add(new GiftSet
            {
                Id = maxId + 1,
                GiftSetName = model.GiftSetName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = source.GiftSetComponents.Count > 0 ?
           source.GiftSetComponents.Max(rec => rec.Id) : 0;
            // убираем дубли по компонентам
            var groupComponents = model.GiftSetComponents
            .GroupBy(rec => rec.ComponentId)
           .Select(rec => new
           {
               ComponentId = rec.Key,
               Count = rec.Sum(r => r.Count)
           });
            // добавляем компоненты
            foreach (var groupComponent in groupComponents)
            {
                source.GiftSetComponents.Add(new GiftSetComponent
                {
                    Id = ++maxPCId,
                    GiftSetId = maxId + 1,
                    ComponentId = groupComponent.ComponentId,
                    Count = groupComponent.Count
                });
            }
        }
        public void UpdElement(GiftSetBindingModel model)
        {
            GiftSet element = source.GiftSets.FirstOrDefault(rec => rec.GiftSetName ==
           model.GiftSetName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            element = source.GiftSets.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.GiftSetName = model.GiftSetName;
            element.Price = model.Price;
            int maxPCId = source.GiftSetComponents.Count > 0 ?
           source.GiftSetComponents.Max(rec => rec.Id) : 0;
            // обновляем существуюущие компоненты
            var compIds = model.GiftSetComponents.Select(rec =>
           rec.ComponentId).Distinct();
            var updateComponents = source.GiftSetComponents.Where(rec => rec.GiftSetId ==
           model.Id && compIds.Contains(rec.ComponentId));
            foreach (var updateComponent in updateComponents)
            {
                updateComponent.Count = model.GiftSetComponents.FirstOrDefault(rec =>
               rec.Id == updateComponent.Id).Count;
            }
            source.GiftSetComponents.RemoveAll(rec => rec.GiftSetId == model.Id &&
           !compIds.Contains(rec.ComponentId));
            // новые записи
            var groupComponents = model.GiftSetComponents
            .Where(rec => rec.Id == 0)
           .GroupBy(rec => rec.ComponentId)
           .Select(rec => new
           {
               ComponentId = rec.Key,
               Count = rec.Sum(r => r.Count)
           });
            foreach (var groupComponent in groupComponents)
            {
                GiftSetComponent elementPC = source.GiftSetComponents.FirstOrDefault(rec
               => rec.GiftSetId == model.Id && rec.ComponentId == groupComponent.ComponentId);
                if (elementPC != null)
                {
                    elementPC.Count += groupComponent.Count;
                }
                else
                {
                    source.GiftSetComponents.Add(new GiftSetComponent
                    {
                        Id = ++maxPCId,
                        GiftSetId = model.Id,
                        ComponentId = groupComponent.ComponentId,
                        Count = groupComponent.Count
                    });
                }
            }
        }
        public void DelElement(int id)
        {
            GiftSet element = source.GiftSets.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // удаяем записи по компонентам при удалении изделия
                source.GiftSetComponents.RemoveAll(rec => rec.GiftSetId == id);
                source.GiftSets.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}