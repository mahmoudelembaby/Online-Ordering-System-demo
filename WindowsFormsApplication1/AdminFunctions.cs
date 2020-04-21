using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    // Send HTTP POST Request containing data required to access admin functions on server
    class AdminFunctions
    {
        // Adds category to server
        public static bool add_category(string admin_id, string admin_auth_key, string name)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/admin/addCat");
            var postData = "admin_id=" + admin_id + "&admin_auth_key=" + admin_auth_key + "&name=" + System.Uri.EscapeDataString(name);
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

        // Edits category name on server
        public static bool edit_category(string admin_id, string admin_auth_key, int id, string name)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/admin/editCat");
            var postData = "admin_id=" + admin_id + "&admin_auth_key=" + admin_auth_key + "&id=" +id.ToString() + "&name=" + System.Uri.EscapeDataString(name);
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

        // Delete category from server alongside all products listed in it (serverside operation)
        public static bool delete_category(string admin_id, string admin_auth_key, int id)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/admin/deleteCat");
            var postData = "admin_id=" + admin_id + "&admin_auth_key=" + admin_auth_key + "&id=" + id.ToString();
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

        // Adds a product to the server
        public static bool add_product(string admin_id, string admin_auth_key, string name, float price, int cat_id)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/admin/addProd");
            var postData = "admin_id=" + admin_id + "&admin_auth_key=" + admin_auth_key + "&name=" + System.Uri.EscapeDataString(name) + "&price=" + price.ToString() + "&cat_id=" + cat_id.ToString();
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

        // Edits product details on server
        public static bool edit_product(string admin_id, string admin_auth_key, string name, float price, int cat_id, int id)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/admin/editProd");
            var postData = "admin_id=" + admin_id + "&admin_auth_key=" + admin_auth_key + "&name=" + System.Uri.EscapeDataString(name) + "&price=" + price.ToString() + "&cat_id=" + cat_id.ToString() + "&id=" + id.ToString();
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

        // delete product from server
        public static bool delete_product(string admin_id, string admin_auth_key, int cat_id, int id)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/admin/deleteProd");
            var postData = "admin_id=" + admin_id + "&admin_auth_key=" + admin_auth_key + "&cat_id=" + cat_id.ToString() + "&id=" + id.ToString();
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

        // Return list of all orders from all users sorted chronologically
        public static BindingList<Order> list_orders(string admin_id, string admin_auth_key)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/admin/listOrders");
            var postData = "admin_id=" + admin_id + "&admin_auth_key=" + admin_auth_key;
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
            BindingList<Order> display = new BindingList<Order>();
            if (R.status) display = JsonConvert.DeserializeObject<BindingList<Order>>(R.data);
            else MessageBox.Show(R.reason);
            return display;
        }

        // Edit order status (pending, delivering, delivered)
        public static bool edit_order_status(string admin_id, string admin_auth_key, int order_id, int new_status)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/admin/changeOrderStatus");
            var postData = "admin_id=" + admin_id + "&admin_auth_key=" + admin_auth_key + "&id=" + order_id.ToString() + "&status=" + new_status.ToString();
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

    }
}
