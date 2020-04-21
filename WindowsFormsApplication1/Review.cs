using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Review
    {
        public string title;
        public string body;
        public int rating;
        public int product_id;
        public int user_id;
        public int id;
        public Review(string title1, string body1, int rating1, int product_id1, int user_id1, int id1)
        {
            title = title1;
            body = body1;
            rating = rating1;
            product_id = product_id1;
            user_id = user_id1;
            id = id1;
        }
    }
}
