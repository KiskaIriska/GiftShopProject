using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.Interfaces;
using GiftShopBusinessLogic.ViewModels;
using GiftShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftShopDatabaseImplement.Implements
{
    public class ImplementerLogic : IImplementerLogic
    {
        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            using (var context = new GiftShopDatabase())
            {
                Implementer element = context.Implementers.FirstOrDefault(rec => rec.ImplementerFIO == model.ImplementerFIO && rec.Id == model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть исполнитель с таким именем");
                }
                if (model.Id.HasValue)
                {
                    element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);

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
                    context.Implementers.Add(element);
                }

                context.SaveChanges();
            }
        }

        public void Delete(ImplementerBindingModel model)
        {
            using (var context = new GiftShopDatabase())
            {
                Implementer element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);

                if (element != null)
                {
                    context.Implementers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<ImplementerViewModel> Read(ImplementerBindingModel model)
        {
            using (var context = new GiftShopDatabase())
            {
                return context.Implementers
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
}