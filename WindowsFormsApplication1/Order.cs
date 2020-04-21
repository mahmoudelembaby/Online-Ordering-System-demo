using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Order
    {
        public int id;
        public int product_id;
        public string product_name { get; set; }
        public string order_status { get; set; }
        public int quantity { get; set; }
        public int int_status;
        public float price_per_unit;
        public float total { get; set; }
        public int user_id { get; set; }
        public Order(int id1, int product_id1, int user_id1, int quantity1, float price_per_unit1, int int_status1, string product_name1)
        {
            id = id1;
            product_id = product_id1;
            user_id = user_id1;
            quantity = quantity1;
            int_status = int_status1;
            if (int_status1 == 0) order_status = "Pending";
            else if (int_status1 == 1) order_status = "Delivering";
            else order_status = "Delivered";
            product_name = product_name1;
            total = price_per_unit1 * quantity1;
        }

        // Calculate status and total price
        public void init()
        {
            if (int_status == 0) order_status = "Pending";
            else if (int_status == 1) order_status = "Delivering";
            else order_status = "Delivered";
            product_name = Uri.UnescapeDataString(product_name);
            total = price_per_unit * quantity;
        }
    }
}
