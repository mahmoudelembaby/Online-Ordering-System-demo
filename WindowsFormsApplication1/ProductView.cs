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
    public partial class ProductView : Form
    {
        product x;
        int uid;
        string password;
        bool is_admin;

        // Initialize
        public ProductView(product p, int id, string pass,bool admin)
        {
            InitializeComponent();
            x = p;
            uid = id;
            password = pass;
            is_admin = admin;
        }

        // Change visibility of certain controls depending on whether the user is an admin
        private void ProductView_Load(object sender, EventArgs e)
        {
            if(is_admin)
            {
                textBox4.Hide();
                label4.Hide();
                button1.Hide();
                button3.Hide();
            }
            textBox1.Text = Uri.UnescapeDataString(x.name);
            textBox2.Text = x.price.ToString();
            if (x.desc != null) x.desc = Uri.UnescapeDataString(x.desc);
            textBox3.Text = x.desc;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
        }

        // Order button listener
        private void button1_Click(object sender, EventArgs e)
        {
            string quantity = textBox4.Text;
            foreach(char i in quantity)
            {
                if(i<'0'||i>'9')
                {
                    errorProvider1.SetError(textBox4,"Only digits between 0-9 allowed");
                    return;
                }
            }
            errorProvider1.Clear();
            if(Int32.Parse(quantity)>1000|| Int32.Parse(quantity)<1)
            {
                errorProvider1.SetError(textBox4, "Please enter a positive integer between 1 - 1000");
                return;
            }
            errorProvider1.Clear();
            bool status = UserRequest.place_order(uid, password, Int32.Parse(quantity), x.id);
            if(status)
            {
                MessageBox.Show("Success");
                Hide();
            }
        }

        // Show write review form
        private void button3_Click(object sender, EventArgs e)
        {
            WriteReview f = new WriteReview(uid, password, x.id);
            f.Show();
        }

        // List all reviews for product
        private void button2_Click(object sender, EventArgs e)
        {
            BindingList<Review> reviews = UserRequest.list_product_reviews(x.id);
            ListReviews f = new ListReviews(reviews);
            f.Show();
        }
    }
}
