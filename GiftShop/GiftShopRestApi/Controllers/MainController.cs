using GiftShopBusinessLogic.BingingModels;
using GiftShopBusinessLogic.BusinessLogics;
using GiftShopBusinessLogic.Interfaces;
using GiftShopBusinessLogic.ViewModels;
using GiftShopRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;

        private readonly IGiftSetLogic _product;

        private readonly MainLogic _main;

        public MainController(IOrderLogic order, IGiftSetLogic product, MainLogic main)
        {
            _order = order;
            _product = product;
            _main = main;
        }
        [HttpGet] public List<GiftSetModel> GetProductList() => _product.Read(null)?.Select(rec => Convert(rec)).ToList();

        [HttpGet] public GiftSetModel GetProduct(int productId) => Convert(_product.Read(new GiftSetBindingModel { Id = productId })?[0]);

        [HttpGet] public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });

        [HttpPost] public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);

        private GiftSetModel Convert(GiftSetViewModel model)
        {
            if (model == null) return null;

            return new GiftSetModel
            {
                Id = model.Id,
                GiftSetName = model.GiftSetName,
                Price = model.Price
            };
        }
    }
}
