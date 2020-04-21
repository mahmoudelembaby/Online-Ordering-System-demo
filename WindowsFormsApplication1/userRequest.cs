
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.ComponentModel;

namespace WindowsFormsApplication1
{
    public class UserRequest
    {

        // Get list of categories from server
        public static BindingList<category> list_categories()
        {
            var requset=(HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/listCats");
            requset.ContentType = "text/json";
            requset.Method = "POST";
            var response = (HttpWebResponse)requset.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream());
            var responseText = streamReader.ReadToEnd();
            Response R = JsonConvert.DeserializeObject<Response>(responseText);
            BindingList<category> display = JsonConvert.DeserializeObject<BindingList<category>>(R.data);
            streamReader.Close();
            return display;
        }

        // Get list of products from server
        public static BindingList<product> list_products(int id)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/listCatProds");
            var postData = "cat_id=" + id.ToString();
            var data = Encoding.ASCII.GetBytes(postData);
            requset.ContentType = "application/x-www-form-urlencoded";
            requset.Method = "POST";
            requset.ContentLength = data.Length;
            var stream = requset.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Flush();
            stream.Close();
            var response = requset.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream());
            var responseText = streamReader.ReadToEnd();
            Response R = JsonConvert.DeserializeObject<Response>(responseText);
            streamReader.Close();
            BindingList<product> display=new BindingList<product>();
            if (R.status) display = JsonConvert.DeserializeObject<BindingList<product>>(R.data);
            else MessageBox.Show(R.reason);
            return display;
        }

        // Register user in the server
        public static bool user_register(string user_name, string first_name, string last_name, string email, string phone, string password, string password_confirmation)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/user/register");
            var postData = "user_name=" + System.Uri.EscapeDataString(user_name) + "&first_name=" + System.Uri.EscapeDataString(first_name) + "&last_name=" + System.Uri.EscapeDataString(last_name) + "&email=" + System.Uri.EscapeDataString(email) + "&phone=" + phone + "&password=" + System.Uri.EscapeDataString(password) + "&password_confirmation=" + System.Uri.EscapeDataString(password_confirmation);
            var data = Encoding.ASCII.GetBytes(postData);
            requset.ContentType = "application/x-www-form-urlencoded";
            requset.Method = "POST";
            requset.ContentLength = data.Length;
            var stream = requset.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Flush();
            stream.Close();
            var response = requset.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream());
            var responseText = streamReader.ReadToEnd();
            streamReader.Close();
            Response R = JsonConvert.DeserializeObject<Response>(responseText);
            if (!R.status) MessageBox.Show(R.reason);
            return R.status;
        }

        // Get list of orders from server
        public static BindingList<Order> list_orders(int user_id, string password)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/user/listOrders");
            var postData = "user_id=" + user_id.ToString() + "&password=" + password;
            var data = Encoding.ASCII.GetBytes(postData);
            requset.ContentType = "application/x-www-form-urlencoded";
            requset.Method = "POST";
            requset.ContentLength = data.Length;
            var stream = requset.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Flush();
            stream.Close();
            var response = requset.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream());
            var responseText = streamReader.ReadToEnd();
            Response R = JsonConvert.DeserializeObject<Response>(responseText);
            BindingList<Order> display=new BindingList<Order>();
            if (R.status) display = JsonConvert.DeserializeObject<BindingList<Order>>(R.data);
            else MessageBox.Show(R.reason);
            streamReader.Close();
            return display;
        }

        // Place an order on the server
        public static bool place_order(int user_id, string password, int quantity, int product_id)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/user/placeOrder");
            var postData = "user_id=" + user_id.ToString() + "&password=" + password + "&quantity=" + quantity.ToString() + "&product_id=" + product_id.ToString();
            var data = Encoding.ASCII.GetBytes(postData);
            requset.ContentType = "application/x-www-form-urlencoded";
            requset.Method = "POST";
            requset.ContentLength = data.Length;
            var stream = requset.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Flush();
            stream.Close();
            var response = requset.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream());
            var responseText = streamReader.ReadToEnd();
            Response R = JsonConvert.DeserializeObject<Response>(responseText);
            streamReader.Close();
            if (!R.status) MessageBox.Show(R.reason);
            return R.status;
        }

        // Edit order data on server
        public static bool edit_order(int user_id, string password, int order_id, int quantity)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/user/editOrder");
            var postData = "user_id=" + user_id.ToString() + "&password=" + password + "&order_id=" + order_id.ToString() + "&quantity=" + quantity.ToString();
            var data = Encoding.ASCII.GetBytes(postData);
            requset.ContentType = "application/x-www-form-urlencoded";
            requset.Method = "POST";
            requset.ContentLength = data.Length;
            var stream = requset.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Flush();
            stream.Close();
            var response = requset.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream());
            var responseText = streamReader.ReadToEnd();
            Response R = JsonConvert.DeserializeObject<Response>(responseText);
            streamReader.Close();
            if (!R.status) MessageBox.Show(R.reason);
            return R.status;
        }

        // Delete order from database
        public static bool delete_order(int user_id, string password, int order_id)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/user/deleteOrder");
            var postData = "user_id=" + user_id.ToString() + "&password=" + password + "&order_id=" + order_id.ToString();
            var data = Encoding.ASCII.GetBytes(postData);
            requset.ContentType = "application/x-www-form-urlencoded";
            requset.Method = "POST";
            requset.ContentLength = data.Length;
            var stream = requset.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Flush();
            stream.Close();
            var response = requset.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream());
            var responseText = streamReader.ReadToEnd();
            streamReader.Close();
            Response R = JsonConvert.DeserializeObject<Response>(responseText);
            if (!R.status) MessageBox.Show(R.reason);
            return R.status;
        }

        // Add user review on server
        public static bool add_review(int user_id, string password,int product_id, string title, string body, int rating)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/user/addReview");
            var postData = "user_id=" + user_id.ToString() + "&password=" + password + "&product_id=" + product_id.ToString() + "&title=" + System.Uri.EscapeDataString(title) + "&body=" + System.Uri.EscapeDataString(body) + "&rating=" + rating.ToString();
            var data = Encoding.ASCII.GetBytes(postData);
            requset.ContentType = "application/x-www-form-urlencoded";
            requset.Method = "POST";
            requset.ContentLength = data.Length;
            var stream = requset.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Flush();
            stream.Close();
            var response = requset.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream());
            var responseText = streamReader.ReadToEnd();
            streamReader.Close();
            Response R = JsonConvert.DeserializeObject<Response>(responseText);
            if (!R.status) MessageBox.Show(R.reason);
            return R.status;
        }

        // Get list of user reviews for a certain user
        public static BindingList<Review> list_user_reviews(int user_id)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/getUserRevs");
            var postData = "user_id=" + user_id.ToString();
            var data = Encoding.ASCII.GetBytes(postData);
            requset.ContentType = "application/x-www-form-urlencoded";
            requset.Method = "POST";
            requset.ContentLength = data.Length;
            var stream = requset.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Flush();
            stream.Close();
            var response = requset.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream());
            var responseText = streamReader.ReadToEnd();
            Response R = JsonConvert.DeserializeObject<Response>(responseText);
            BindingList<Review> display = new BindingList<Review>();
            if (R.status) display = JsonConvert.DeserializeObject<BindingList<Review>>(R.data);
            else MessageBox.Show(R.reason);
            streamReader.Close();
            return display;
        }

        // Get list of user reviews for a certain product
        public static BindingList<Review> list_product_reviews(int product_id)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/getProdRevs");
            var postData = "product_id=" + product_id.ToString();
            var data = Encoding.ASCII.GetBytes(postData);
            requset.ContentType = "application/x-www-form-urlencoded";
            requset.Method = "POST";
            requset.ContentLength = data.Length;
            var stream = requset.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Flush();
            stream.Close();
            var response = requset.GetResponse();
            var streamReader = new StreamReader(response.GetResponseStream());
            var responseText = streamReader.ReadToEnd();
            Response R = JsonConvert.DeserializeObject<Response>(responseText);
            BindingList<Review> display = new BindingList<Review>();
            if (R.status) display = JsonConvert.DeserializeObject<BindingList<Review>>(R.data);
            else MessageBox.Show(R.reason);
            streamReader.Close();
            return display;
        }
    }
}
