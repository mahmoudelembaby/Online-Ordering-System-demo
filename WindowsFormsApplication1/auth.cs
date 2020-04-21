using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    // Send authorization details for
    class Auth
    {
        // user
        public static int user_auth(string user_name, string password)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/user/auth");
            var postData = "user_name=" + user_name + "&password=" + password;
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
            int ret = Int32.Parse(R.data);
            return ret;
        }

        // admin
        public static bool admin_auth(string admin_id, string admin_auth_key)
        {
            var requset = (HttpWebRequest)WebRequest.Create("https://oop-oos.herokuapp.com/admin/auth");
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
            streamReader.Close();
            Response R = JsonConvert.DeserializeObject<Response>(responseText);
            if (!R.status) MessageBox.Show(R.reason);
            return R.status;
        }
    }
}
