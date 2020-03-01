using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.Interfaces;
using GiftShopBusinessLogic.ViewModels;
using GiftShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShopListImplement.Implements
{
    public class ComponentLogic : IComponentLogic
    {
        private readonly DataListSingleton source;
        public ComponentLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(ComponentBindingModel model)
        {
            Component tempComponent = model.Id.HasValue ? null : new Component
            {
                Id = 1
            };
            foreach (var component in source.Components)
            {
                if (component.ComponentName == model.ComponentName && component.Id !=
               model.Id)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (!model.Id.HasValue && component.Id >= tempComponent.Id)
                {
                    tempComponent.Id = component.Id + 1;
                }
                else if (model.Id.HasValue && component.Id == model.Id)
                {
                    tempComponent = component;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempComponent == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempComponent);
            }
            else
            {
                source.Components.Add(CreateModel(model, tempComponent));
            }
        }
        public void Delete(ComponentBindingModel model)
        {
            for (int i = 0; i < source.Components.Count; ++i)
            {
                if (source.Components[i].Id == model.Id.Value)
                {
                    source.Components.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public List<ComponentViewModel> Read(ComponentBindingModel model)
        {
            List<ComponentViewModel> result = new List<ComponentViewModel>();
            foreach (var component in source.Components)
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
        private Component CreateModel(ComponentBindingModel model, Component component)
        {
            component.ComponentName = model.ComponentName;
            return component;
        }
        private ComponentViewModel CreateViewModel(Component component)
        {
            return new ComponentViewModel
            {
                Id = component.Id,
                ComponentName = component.ComponentName
            };
        }
    }
}
