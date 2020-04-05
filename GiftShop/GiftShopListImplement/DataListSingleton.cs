using GiftShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GiftShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<GiftSet> GiftSets { get; set; }
        public List<GiftSetComponent> GiftSetComponents { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public List<WarehouseComponent> WarehouseComponents { get; set; }
        private DataListSingleton()
        {
            Components = new List<Component>();
            Orders = new List<Order>();
            GiftSets = new List<GiftSet>();
            GiftSetComponents = new List<GiftSetComponent>();
            Warehouses = new List<Warehouse>();
            WarehouseComponents = new List<WarehouseComponent>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
