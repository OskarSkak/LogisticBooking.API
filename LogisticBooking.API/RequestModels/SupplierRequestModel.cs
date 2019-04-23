using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticBooking.API.RequestModels
{
    public class SupplierRequestModel
    {
        public string Email { get; set; }
        public int Telephone { get; set; }
        public string Name { get; set; }
    }
}
