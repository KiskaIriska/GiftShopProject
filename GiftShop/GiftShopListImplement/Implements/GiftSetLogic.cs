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
            List<GiftSetComponentViewModel> giftSetComponents = new List<GiftSetComponentViewModel>();
                for (int j = 0; j < source.GiftSetComponents.Count; ++j)
                {
                    if (source.GiftSetComponents[j].GiftSetId == source.GiftSets[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Components.Count; ++k)
                        {
                            if (source.GiftSetComponents[j].ComponentId ==
                           source.Components[k].Id)
                            {
                                componentName = source.Components[k].ComponentName;
                                break;
                            }
                        }
                        giftSetComponents.Add(new GiftSetComponentViewModel
                        {
                            Id = source.GiftSetComponents[j].Id,
                            GiftSetId = source.GiftSetComponents[j].GiftSetId,
                            ComponentId = source.GiftSetComponents[j].ComponentId,
                            ComponentName = componentName,
                            Count = source.GiftSetComponents[j].Count
                        });
                    }
                }
                result.Add(new GiftSetViewModel
                {
                    Id = source.GiftSets[i].Id,
                    GiftSetName = source.GiftSets[i].GiftSetName,
                    Price = source.GiftSets[i].Price,
                    GiftSetComponents = giftSetComponents
                });
            }
            return result;
        }
        public GiftSetViewModel GetElement(int id)
        {
            for (int i = 0; i < source.GiftSets.Count; ++i)
            {
                // требуется дополнительно получить список компонентов для изделия и их количество
            List<GiftSetComponentViewModel> giftSetComponents = new List<GiftSetComponentViewModel>();
                for (int j = 0; j < source.GiftSetComponents.Count; ++j)
                {
                    if (source.GiftSetComponents[j].GiftSetId == source.GiftSets[i].Id)
                    {
                        string componentName = string.Empty;
                        for (int k = 0; k < source.Components.Count; ++k)
                        {
                            if (source.GiftSetComponents[j].ComponentId ==
                           source.Components[k].Id)
                            {
                                componentName = source.Components[k].ComponentName;
                                break;
                            }
                        }
                        giftSetComponents.Add(new GiftSetComponentViewModel
                        {
                            Id = source.GiftSetComponents[j].Id,

                            GiftSetId = source.GiftSetComponents[j].GiftSetId,
                            ComponentId = source.GiftSetComponents[j].ComponentId,
                            ComponentName = componentName,
                            Count = source.GiftSetComponents[j].Count
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
                        GiftSetComponents = giftSetComponents
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
            for (int i = 0; i < source.GiftSetComponents.Count; ++i)
            {
                if (source.GiftSetComponents[i].Id > maxPCId)
                {
                    maxPCId = source.GiftSetComponents[i].Id;
                }
            }
            // убираем дубли по компонентам
            for (int i = 0; i < model.GiftSetComponents.Count; ++i)
            {
                for (int j = 1; j < model.GiftSetComponents.Count; ++j)
                {
                    if (model.GiftSetComponents[i].ComponentId ==
                    model.GiftSetComponents[j].ComponentId)
                    {
                        model.GiftSetComponents[i].Count +=
                        model.GiftSetComponents[j].Count;
                        model.GiftSetComponents.RemoveAt(j--);
                    }
                }
               
            }
            // добавляем компоненты
            for (int i = 0; i < model.GiftSetComponents.Count; ++i)
            {
                source.GiftSetComponents.Add(new GiftSetComponent
                {
                    Id = ++maxPCId,
                    GiftSetId = maxId + 1,
                    ComponentId = model.GiftSetComponents[i].ComponentId,
                    Count = model.GiftSetComponents[i].Count
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
            for (int i = 0; i < source.GiftSetComponents.Count; ++i)
            {
                if (source.GiftSetComponents[i].Id > maxPCId)
                {
                    maxPCId = source.GiftSetComponents[i].Id;
                }
            }
            // обновляем существуюущие компоненты
            for (int i = 0; i < source.GiftSetComponents.Count; ++i)
            {
                if (source.GiftSetComponents[i].GiftSetId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.GiftSetComponents.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.GiftSetComponents[i].Id ==
                        model.GiftSetComponents[j].Id)
                        {
                            source.GiftSetComponents[i].Count =
                           model.GiftSetComponents[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                     source.GiftSetComponents.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for (int i = 0; i < model.GiftSetComponents.Count; ++i)
            {
                if (model.GiftSetComponents[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.GiftSetComponents.Count; ++j)
                    {
                        if (source.GiftSetComponents[j].GiftSetId == model.Id &&
                        source.GiftSetComponents[j].ComponentId ==
                       model.GiftSetComponents[i].ComponentId)
                        {
                            source.GiftSetComponents[j].Count +=
                           model.GiftSetComponents[i].Count;
                            model.GiftSetComponents[i].Id =
                           source.GiftSetComponents[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.GiftSetComponents[i].Id == 0)
                    {
                        source.GiftSetComponents.Add(new GiftSetComponent
                        {
                            Id = ++maxPCId,
                            GiftSetId = model.Id,
                            ComponentId = model.GiftSetComponents[i].ComponentId,
                            Count = model.GiftSetComponents[i].Count
                        });
                    }
                }
            }
        }
        public void DelElement(int id)
        {
            // удаляем записи по компонентам при удалении изделия
            for (int i = 0; i < source.GiftSetComponents.Count; ++i)
            {
                if (source.GiftSetComponents[i].GiftSetId == id)
                {
                    source.GiftSetComponents.RemoveAt(i--);
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