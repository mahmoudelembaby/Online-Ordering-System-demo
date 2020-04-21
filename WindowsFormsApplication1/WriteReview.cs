using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class WriteReview : Form
    {
        int uid,product_id;
        string password;
        public WriteReview(int id, string pass, int pid)
        {
            InitializeComponent();
            password = pass;
            uid = id;
            product_id = pid;
        }

        private void WriteReview_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 4;
        }

        // Send review to server
        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string body = textBox2.Text;
            if (title == "" || title == null) return;
            if (body == "" || body == null) return;
            title = Uri.EscapeDataString(title);
            body = Uri.EscapeDataString(body);
            int rating = Int32.Parse(comboBox1.Text);
            bool status = UserRequest.add_review(uid, password, product_id, title, body, rating);
            if(status)
            {
                MessageBox.Show("Success");
                Hide();
            }
        }
    }
}
