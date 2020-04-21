using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class product
    {
        public string name;
        public float price;
        public int category_id;
        public int id;
        public string desc;
        public product(string name1, float price1, int category_id1, int id1, string desc1)
        {
            id = id1;
            category_id = category_id1;
            name = name1;
            price = price1;
            desc = desc1;
        }
    }
}
