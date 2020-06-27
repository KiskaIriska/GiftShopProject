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
            var products = productLogic.Read(null);
            var list = new List<ReportGiftSetComponentViewModel>();

            foreach (var product in products)
            {
                foreach (var gc in product.GiftSetComponents)
                {
                        var record = new ReportGiftSetComponentViewModel
                        {
                            GiftSetName = product.GiftSetName,
                            ComponentName = gc.Value.Item1,
                            Count = gc.Value.Item2,
                        };
                        list.Add(record);
                    }
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
             .Read(new OrderBindingModel
             {
                 DateFrom = model.DateFrom,
                 DateTo = model.DateTo
             })
             .GroupBy(rec => rec.DateCreate.Date)
             .OrderBy(recG => recG.Key)
             .ToList();

            return list;
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
                Title = "Список изделий с компонентами",
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
