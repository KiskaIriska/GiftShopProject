using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.Interfaces;
using GiftShopBusinessLogic.ViewModels;
using GiftShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShopListImplement.Implements
{
    public class GiftSetLogic : IGiftSetLogic
    {
        private readonly DataListSingleton source;

        public GiftSetLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(GiftSetBindingModel model)
        {
            GiftSet tempGiftSet = model.Id.HasValue ? null : new GiftSet { Id = 1 };
            foreach (var product in source.GiftSets)
            {
                if (product.GiftSetName == model.GiftSetName && product.Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
                if (!model.Id.HasValue && product.Id >= tempGiftSet.Id)
                {
                    tempGiftSet.Id = product.Id + 1;
                }
                else if (model.Id.HasValue && product.Id == model.Id)
                {
                    tempGiftSet = product;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempGiftSet == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempGiftSet);
            }
            else
            {
                source.GiftSets.Add(CreateModel(model, tempGiftSet));
            }
        }
        public void Delete(GiftSetBindingModel model)
        {
            // удаляем записи по компонентам при удалении изделия
            for (int i = 0; i < source.GiftSetComponents.Count; ++i)
            {
                if (source.GiftSetComponents[i].GiftSetId == model.Id)
                {
                    source.GiftSetComponents.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.GiftSets.Count; ++i)
            {
                if (source.GiftSets[i].Id == model.Id)
                {
                    source.GiftSets.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private GiftSet CreateModel(GiftSetBindingModel model, GiftSet product)
        {
            product.GiftSetName = model.GiftSetName;
            product.Price = model.Price;
            //обновляем существуюущие компоненты и ищем максимальный идентификатор
            int maxPCId = 0;
            for (int i = 0; i < source.GiftSetComponents.Count; ++i)
            {
                if (source.GiftSetComponents[i].Id > maxPCId)
                {
                    maxPCId = source.GiftSetComponents[i].Id;
                }
                if (source.GiftSetComponents[i].GiftSetId == product.Id)
                {
                    // если в модели пришла запись компонента с таким id
                    if
                    (model.GiftSetComponents.ContainsKey(source.GiftSetComponents[i].ComponentId))
                    {
                        // обновляем количество
                        source.GiftSetComponents[i].Count =
                        model.GiftSetComponents[source.GiftSetComponents[i].ComponentId].Item2;
                        // из модели убираем эту запись, чтобы остались только не
                        //    просмотренные

                        model.GiftSetComponents.Remove(source.GiftSetComponents[i].ComponentId);
                    }
                    else
                    {
                        source.GiftSetComponents.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            foreach (var pc in model.GiftSetComponents)
            {
                source.GiftSetComponents.Add(new GiftSetComponent
                {
                    Id = ++maxPCId,
                    GiftSetId = product.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
            return product;
        }
        public List<GiftSetViewModel> Read(GiftSetBindingModel model)
        {
            List<GiftSetViewModel> result = new List<GiftSetViewModel>();
            foreach (var component in source.GiftSets)
            {
                if (model != null)
                {
                    if (component.Id == model.Id)
                    {
                        result.Add(CreateViewModel(component));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(component));
            }
            return result;
        }
        private GiftSetViewModel CreateViewModel(GiftSet product)
        {
            // требуется дополнительно получить список компонентов для изделия с
            //  названиями и их количество
            Dictionary<int, (string, int)> productComponents = new Dictionary<int,
    (string, int)>();
            foreach (var pc in source.GiftSetComponents)
            {
                if (pc.GiftSetId == product.Id)
                {
                    string componentName = string.Empty;
                    foreach (var component in source.Components)
                    {
                        if (pc.ComponentId == component.Id)
                        {
                            componentName = component.ComponentName;
                            break;
                        }
                    }
                    productComponents.Add(pc.ComponentId, (componentName, pc.Count));
                }
            }
            return new GiftSetViewModel
            {
                Id = product.Id,
                GiftSetName = product.GiftSetName,
                Price = product.Price,
                GiftSetComponents = productComponents
            };
        }
    }
}