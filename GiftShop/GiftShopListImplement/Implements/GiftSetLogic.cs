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
        public List<GiftSetViewModel> GetList()
        {
            List<GiftSetViewModel> result = new List<GiftSetViewModel>();
            for (int i = 0; i < source.GiftSets.Count; ++i)
            {
             
            // требуется дополнительно получить список компонентов для изделия и их количество
            List<GiftSetComponentViewModel> productComponents = new List<GiftSetComponentViewModel>();
                for (int j = 0; j < source.ProductComponents.Count; ++j)
                {
                    if (source.ProductComponents[j].GiftSetId == source.GiftSets[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Components.Count; ++k)
                        {
                            if (source.ProductComponents[j].ComponentId ==
                           source.Components[k].Id)
                            {
                                componentName = source.Components[k].ComponentName;
                                break;
                            }
                        }
                        productComponents.Add(new GiftSetComponentViewModel
                        {
                            Id = source.ProductComponents[j].Id,
                            GiftSetId = source.ProductComponents[j].GiftSetId,
                            ComponentId = source.ProductComponents[j].ComponentId,
                            ComponentName = componentName,
                            Count = source.ProductComponents[j].Count
                        });
                    }
                }
                result.Add(new GiftSetViewModel
                {
                    Id = source.GiftSets[i].Id,
                    GiftSetName = source.GiftSets[i].GiftSetName,
                    Price = source.GiftSets[i].Price,
                    GiftSetComponents = productComponents
                });
            }
            return result;
        }
        public GiftSetViewModel GetElement(int id)
        {
            for (int i = 0; i < source.GiftSets.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
            List<GiftSetComponentViewModel> productComponents = new List<GiftSetComponentViewModel>();
                for (int j = 0; j < source.ProductComponents.Count; ++j)
                {
                    if (source.ProductComponents[j].GiftSetId == source.GiftSets[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Components.Count; ++k)
                        {
                            if (source.ProductComponents[j].ComponentId ==
                           source.Components[k].Id)
                            {
                                componentName = source.Components[k].ComponentName;
                                break;
                            }
                        }
                        productComponents.Add(new GiftSetComponentViewModel
                        {
                            Id = source.ProductComponents[j].Id,

                            GiftSetId = source.ProductComponents[j].GiftSetId,
                            ComponentId = source.ProductComponents[j].ComponentId,
                            ComponentName = componentName,
                            Count = source.ProductComponents[j].Count
                        });
                    }
                }
                if (source.GiftSets[i].Id == id)
                {
                    return new GiftSetViewModel
                    {
                        Id = source.GiftSets[i].Id,
                        GiftSetName = source.GiftSets[i].GiftSetName,
                        Price = source.GiftSets[i].Price,
                        GiftSetComponents = productComponents
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(GiftSetBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.GiftSets.Count; ++i)
            {
                if (source.GiftSets[i].Id > maxId)
                {
                    maxId = source.GiftSets[i].Id;
                }
                if (source.GiftSets[i].GiftSetName == model.GiftSetName)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            source.GiftSets.Add(new GiftSet
            {
                Id = maxId + 1,
                GiftSetName = model.GiftSetName,
                Price = model.Price
            });
            // компоненты для изделия
            int maxPCId = 0;
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].Id > maxPCId)
                {
                    maxPCId = source.ProductComponents[i].Id;
                }
            }
            // убираем дубли по компонентам
            for (int i = 0; i < model.ProductComponents.Count; ++i)
            {
                for (int j = 1; j < model.ProductComponents.Count; ++j)
                {
                    if (model.ProductComponents[i].ComponentId ==
                    model.ProductComponents[j].ComponentId)
                    {
                        model.ProductComponents[i].Count +=
                        model.ProductComponents[j].Count;
                        model.ProductComponents.RemoveAt(j--);
                    }
                }
               
            }
            // добавляем компоненты
            for (int i = 0; i < model.ProductComponents.Count; ++i)
            {
                source.ProductComponents.Add(new GiftSetComponent
                {
                    Id = ++maxPCId,
                    GiftSetId = maxId + 1,
                    ComponentId = model.ProductComponents[i].ComponentId,
                    Count = model.ProductComponents[i].Count
                });
            }
        }
        public void UpdElement(GiftSetBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.GiftSets.Count; ++i)
            {
                if (source.GiftSets[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.GiftSets[i].GiftSetName == model.GiftSetName &&
                source.GiftSets[i].Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.GiftSets[index].GiftSetName = model.GiftSetName;
            source.GiftSets[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].Id > maxPCId)
                {
                    maxPCId = source.ProductComponents[i].Id;
                }
            }
            // обновляем существуюущие компоненты
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].GiftSetId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.ProductComponents.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.ProductComponents[i].Id ==
                        model.ProductComponents[j].Id)
                        {
                            source.ProductComponents[i].Count =
                           model.ProductComponents[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                     source.ProductComponents.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for (int i = 0; i < model.ProductComponents.Count; ++i)
            {
                if (model.ProductComponents[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.ProductComponents.Count; ++j)
                    {
                        if (source.ProductComponents[j].GiftSetId == model.Id &&
                        source.ProductComponents[j].ComponentId ==
                       model.ProductComponents[i].ComponentId)
                        {
                            source.ProductComponents[j].Count +=
                           model.ProductComponents[i].Count;
                            model.ProductComponents[i].Id =
                           source.ProductComponents[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.ProductComponents[i].Id == 0)
                    {
                        source.ProductComponents.Add(new GiftSetComponent
                        {
                            Id = ++maxPCId,
                            GiftSetId = model.Id,
                            ComponentId = model.ProductComponents[i].ComponentId,
                            Count = model.ProductComponents[i].Count
                        });
                    }
                }
            }
        }
        public void DelElement(int id)
        {
            // удаляем записи по компонентам при удалении изделия
            for (int i = 0; i < source.ProductComponents.Count; ++i)
            {
                if (source.ProductComponents[i].GiftSetId == id)
                {
                    source.ProductComponents.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.GiftSets.Count; ++i)
            {
                if (source.GiftSets[i].Id == id)
                {
                    source.GiftSets.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}