using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.Enums;
using GiftShopBusinessLogic.HelperModels;
using GiftShopBusinessLogic.Interfaces;
using MailKit.Net.Pop3;
using MailKit.Security;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopBusinessLogic.BusinessLogics
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;

        private readonly IClientLogic clientLogic;

        private readonly object locker = new object();

        public MainLogic(IOrderLogic orderLogic, IClientLogic clientLogic)
        {
            this.orderLogic = orderLogic;
            this.clientLogic = clientLogic;
        }

        public void CreateOrder(CreateOrderBindingModel model)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                GiftSetId = model.GiftSetId,
                ClientId = model.ClientId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят
            });

            MailLogic.MailSendAsync(new MailSendInfo
            {
                MailAddress = clientLogic.Read(new ClientBindingModel {
               Id = model.ClientId }
                )?[0]?.Email,
                Subject = $"Новый заказ",
                Text = $"Заказ принят."
            });
        }

        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                var order = orderLogic.Read(new OrderBindingModel { 
               Id = model.OrderId })?[0];

                if (order == null)
                {
                    throw new Exception("Не найден заказ");
                }

                if (order.Status != OrderStatus.Принят)
                {
                    throw new Exception("Заказ не в статусе \"Принят\"");
                }

                if (order.ImplementerId.HasValue)
                {
                    throw new Exception("У заказа уже есть исполнитель");
                }

                orderLogic.CreateOrUpdate(new OrderBindingModel
                {
                    Id = order.Id,
                    ClientId = order.ClientId,
                    GiftSetId = order.GiftSetId,
                    ImplementerId = model.ImplementerId,
                    Count = order.Count,
                    Sum = order.Sum,
                    DateCreate = order.DateCreate,
                    DateImplement = DateTime.Now,
                    Status = OrderStatus.Выполняется
                });

                MailLogic.MailSendAsync(new MailSendInfo
                {
                    MailAddress = clientLogic.Read(new ClientBindingModel { 
                    Id = order.ClientId })?[0]?.Email,
                    Subject = $"Заказ №{order.Id}",
                    Text = $"Заказ №{order.Id} передан в работу."
                });
            }
        }

        public void FinishOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];

            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }

            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }

            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                GiftSetId = order.GiftSetId,
                ImplementerId = order.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Готов
            });

            MailLogic.MailSendAsync(new MailSendInfo
            {
                MailAddress = clientLogic.Read(new ClientBindingModel
                { 
                Id = order.ClientId })?[0]?.Email,
                Subject = $"Заказ №{order.Id}",
                Text = $"Заказ №{order.Id} готов."
            });

        }

        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];

            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }

            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }

            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                GiftSetId = order.GiftSetId,
                ImplementerId = model.ImplementerId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен
            });

            MailLogic.MailSendAsync(new MailSendInfo
            {
                MailAddress = clientLogic.Read(new ClientBindingModel {
                Id = order.ClientId })?[0]?.Email,
                Subject = $"Заказ №{order.Id}",
                Text = $"Заказ №{order.Id} оплачен."
            });
        }
    }
}