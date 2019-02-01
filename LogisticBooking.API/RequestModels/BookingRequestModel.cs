using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogisticBooking.API.RequestModels
{
    public class BookingRequestModel
    {
        public int Customer_Number { get; set; }
        public DateTime Date { get; set; }
        public string Transporter_Name { get; set; }
        public string Contact_Email { get; set; }
        public DateTime Booking_Time { get; set; }
        public int Port { get; set; }
        public int Total_Pallets { get; set; }
        public enum In_Out { In, Out }
        public List<Order> Orders { get; set; }

        public BookingRequestModel(int customer_Number, DateTime date, string transporter_Name, string contact_Email, 
                            DateTime booking_Time, int port, int total_Pallets, List<Order> orders)
        {
            Customer_Number = customer_Number;
            Date = date;
            Transporter_Name = transporter_Name;
            Contact_Email = contact_Email;
            Booking_Time = booking_Time;
            Port = port;
            Total_Pallets = total_Pallets;
            Orders = orders;
        }
        

        public class Order
        {
            public Order(string order_Number, int order_Numbers, int pallets, string supplier_Name)
            {
                Order_Number = order_Number;
                Order_Numbers = order_Numbers;
                Pallets = pallets;
                Supplier_Name = supplier_Name;
            }

            public string Order_Number { get; set; }
            public int Order_Numbers { get; set; }
            public int Pallets { get; set; }
            public string Supplier_Name { get; set; }
        }
    }
}
