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
    public class ImplementerLogic : IImplementerLogic
    {
        private readonly FileDataListSingleton source;

        public ImplementerLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            Implementer element = source.Implementers.FirstOrDefault(c => c.ImplementerFIO == model.ImplementerFIO && c.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть исполнитель с таким именем");
            }
            if (model.Id.HasValue)
            {
                element = source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);

                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                else
                {
                    element.ImplementerFIO = model.ImplementerFIO;
                    element.PauseTime = model.PauseTime;
                    element.WorkingTime = model.WorkingTime;
                }
            }
            else
            {
                element = new Implementer
                {
                    ImplementerFIO = model.ImplementerFIO,
                    PauseTime = model.PauseTime,
                    WorkingTime = model.WorkingTime
                };
                source.Implementers.Add(element);
            }
        }

        public void Delete(ImplementerBindingModel model)
        {
            Implementer element = source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);

            if (element != null)
            {
                source.Implementers.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public List<ImplementerViewModel> Read(ImplementerBindingModel model)
        {
            return source.Implementers
            .Where(
                rec => model == null
                || rec.Id == model.Id
            )
            .Select(rec => new ImplementerViewModel
            {
                Id = rec.Id,
                ImplementerFIO = rec.ImplementerFIO,
                WorkingTime = rec.WorkingTime,
                PauseTime = rec.PauseTime
            })
            .ToList();
        }
    }
}