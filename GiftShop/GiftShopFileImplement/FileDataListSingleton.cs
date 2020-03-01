using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using GiftShopFileImplement.Models;
using GiftShopBusinessLogic.Enums;

namespace GiftShopFileImplement
{
      public  class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string GiftSetFileName = "GiftSet.xml";
        private readonly string GiftSetComponentFileName = "GiftSetComponent.xml";
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<GiftSet> GiftSets { get; set; }
        public List<GiftSetComponent> GiftSetComponents { get; set; }
        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            GiftSets = LoadGiftSets();
            GiftSetComponents = LoadGiftSetComponents();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SaveGiftSets();
            SaveGiftSetComponents();
        }
        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        GiftSetId = Convert.ToInt32(elem.Element("GiftSetId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus),
                   elem.Element("Status").Value),
                        DateCreate =
                   Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement =
                   string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null :
                   Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<GiftSet> LoadGiftSets()
        {
            var list = new List<GiftSet>();
            if (File.Exists(GiftSetFileName))
            {
                XDocument xDocument = XDocument.Load(GiftSetFileName);
                var xElements = xDocument.Root.Elements("GiftSet").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new GiftSet
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        GiftSetName = elem.Element("GiftSetName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<GiftSetComponent> LoadGiftSetComponents()
        {
            var list = new List<GiftSetComponent>();
            if (File.Exists(GiftSetComponentFileName))
            {
                XDocument xDocument = XDocument.Load(GiftSetComponentFileName);
                var xElements = xDocument.Root.Elements("GiftSetComponent").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new GiftSetComponent
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        GiftSetId = Convert.ToInt32(elem.Element("GiftSetId").Value),
                        ComponentId = Convert.ToInt32(elem.Element("ComponentId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("GiftSetId", order.GiftSetId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveGiftSets()
        {
            if (GiftSets != null)
            {
                var xElement = new XElement("GiftSets");
                foreach (var product in GiftSets)
                {
                    xElement.Add(new XElement("GiftSet",
                    new XAttribute("Id", product.Id),
                    new XElement("GiftSetName", product.GiftSetName),
                    new XElement("Price", product.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(GiftSetFileName);
            }
        }
        private void SaveGiftSetComponents()
        {
            if (GiftSetComponents != null)
            {
                var xElement = new XElement("GiftSetComponents");
                foreach (var productComponent in GiftSetComponents)
                {
                    xElement.Add(new XElement("GiftSetComponent",
                    new XAttribute("Id", productComponent.Id),
                    new XElement("GiftSetId", productComponent.GiftSetId),
                    new XElement("ComponentId", productComponent.ComponentId),
                    new XElement("Count", productComponent.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(GiftSetComponentFileName);
            }
        }
    }
}
