using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.HelperModels;
using GiftShopBusinessLogic.Interfaces;
using GiftShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftShopBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IComponentLogic componentLogic;
        private readonly IGiftSetLogic productLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IGiftSetLogic productLogic, IComponentLogic componentLogic,
       IOrderLogic orderLLogic)
        {
            this.productLogic = productLogic;
            this.componentLogic = componentLogic;
            this.orderLogic = orderLLogic;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportGiftSetComponentViewModel> GetGiftSetComponent()
        {
            var components = componentLogic.Read(null);
            var products = productLogic.Read(null);
            var list = new List<ReportGiftSetComponentViewModel>();

            foreach (var product in products)
            {
                foreach (var component in components)
                {
                    if (product.GiftSetComponents.ContainsKey(component.Id))
                    {
                        var record = new ReportGiftSetComponentViewModel
                        {
                            GiftSetName = product.GiftSetName,
                            ComponentName = component.ComponentName,
                            Count = product.GiftSetComponents[component.Id].Item2
                        };

                        list.Add(record);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                GiftSetName = x.GiftSetName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
            .ToList();
        }
        /// <summary>
        /// Сохранение изделий в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveGiftSetsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список наборов:",
                GiftSets = productLogic.Read(null)
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveGiftSetComponentToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список издлий с компонентами",
                GiftSetComponents = GetGiftSetComponent()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            var a = GetOrders(model);

            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }
    }
}
