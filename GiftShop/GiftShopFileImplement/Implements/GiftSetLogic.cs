using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.Interfaces;
using GiftShopBusinessLogic.ViewModels;
using GiftShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GiftShopFileImplement.Implements
{
    public class GiftSetLogic : IGiftSetLogic
    {
        private readonly FileDataListSingleton source;

        public GiftSetLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(GiftSetBindingModel model)
        {
            GiftSet element = source.GiftSets.FirstOrDefault(rec => rec.GiftSetName ==
           model.GiftSetName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.GiftSets.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.GiftSets.Count > 0 ? source.Components.Max(rec =>
               rec.Id) : 0;
                element = new GiftSet { Id = maxId + 1 };
                source.GiftSets.Add(element);
            }
            element.GiftSetName = model.GiftSetName;
            element.Price = model.Price;
            // удалили те, которых нет в модели
            source.GiftSetComponents.RemoveAll(rec => rec.GiftSetId == model.Id &&
           !model.GiftSetComponents.ContainsKey(rec.ComponentId));
            // обновили количество у существующих записей
            var updateComponents = source.GiftSetComponents.Where(rec => rec.GiftSetId ==
           model.Id && model.GiftSetComponents.ContainsKey(rec.ComponentId));
            foreach (var updateComponent in updateComponents)
            {
                updateComponent.Count =
               model.GiftSetComponents[updateComponent.ComponentId].Item2;
                model.GiftSetComponents.Remove(updateComponent.ComponentId);
            }
            // добавили новые
            int maxPCId = source.GiftSetComponents.Count > 0 ?
           source.GiftSetComponents.Max(rec => rec.Id) : 0;
            foreach (var pc in model.GiftSetComponents)
            {
                source.GiftSetComponents.Add(new GiftSetComponent
                {
                    Id = ++maxPCId,
                    GiftSetId = element.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
        }
        public void Delete(GiftSetBindingModel model)
        {
            // удаяем записи по компонентам при удалении изделия
            source.GiftSetComponents.RemoveAll(rec => rec.GiftSetId == model.Id);
            GiftSet element = source.GiftSets.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.GiftSets.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<GiftSetViewModel> Read(GiftSetBindingModel model)
        {
            return source.GiftSets
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new GiftSetViewModel
            {
                Id = rec.Id,
                GiftSetName = rec.GiftSetName,
                Price = rec.Price,
                GiftSetComponents = source.GiftSetComponents
            .Where(recPC => recPC.GiftSetId == rec.Id)
           .ToDictionary(recPC => recPC.ComponentId, recPC =>
            (source.Components.FirstOrDefault(recC => recC.Id ==
           recPC.ComponentId)?.ComponentName, recPC.Count))
            })
            .ToList();
        }
    }
}
