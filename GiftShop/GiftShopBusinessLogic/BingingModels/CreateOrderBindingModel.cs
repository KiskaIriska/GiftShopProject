using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GiftShopBusinessLogic.BingingModels
{
    [DataContract]
    public class CreateOrderBindingModel
    {
        [DataMember]
        public int GiftSetId { get; set; }

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Sum { get; set; }

    }
}
