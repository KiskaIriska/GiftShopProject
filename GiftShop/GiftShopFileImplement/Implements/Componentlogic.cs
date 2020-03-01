using GiftShopBusinessLogic.BingingModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using GiftShopBusinessLogic.ViewModels;
using GiftShopFileImplement.Models;
using GiftShopBusinessLogic.Interfaces;

namespace GiftShopFileImplement.Implements
{
    public class ComponentLogic : IComponentLogic
    {
        private readonly FileDataListSingleton source;
        public ComponentLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(ComponentBindingModel model)
        {
            Component element = source.Components.FirstOrDefault(rec => rec.ComponentName
           == model.ComponentName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Components.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Components.Count > 0 ? source.Components.Max(rec =>
               rec.Id) : 0;
                element = new Component { Id = maxId + 1 };
                source.Components.Add(element);
            }
            element.ComponentName = model.ComponentName;
        }
        public void Delete(ComponentBindingModel model)
        {
            Component element = source.Components.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Components.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<ComponentViewModel> Read(ComponentBindingModel model)
        {
            return source.Components
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new ComponentViewModel
            {
                Id = rec.Id,
                ComponentName = rec.ComponentName
            })
            .ToList();
        }
    }
}

