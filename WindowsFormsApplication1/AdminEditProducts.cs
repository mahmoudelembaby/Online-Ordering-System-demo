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
    public partial class AdminEditProducts : Form
    {
        int category_id;
        string admin_id, password;
        BindingList<product> products;

        // Initialize
        public AdminEditProducts(int id,string aid, string pass)
        {
            InitializeComponent();
            category_id = id;
            password = pass;
            admin_id = aid;
            products = UserRequest.list_products(category_id);
        }

        // Add product
        private void button2_Click(object sender, EventArgs e)
        {            
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter product name", "Input", "", 0, 0);
            string price = Microsoft.VisualBasic.Interaction.InputBox("Enter product price", "Input", "", 0, 0);
            bool status = AdminFunctions.add_product(admin_id, password, System.Uri.EscapeDataString(name), float.Parse(price), category_id);
            if (status)
            {
                products = UserRequest.list_products(category_id);
                listBox1.Items.Clear();
                foreach (var c in products)
                    listBox1.Items.Add(Uri.UnescapeDataString(c.name) + "\t" + c.price.ToString());
            }
        }

        // Edit product details
        private void button3_Click(object sender, EventArgs e)
        {            
            int index = listBox1.SelectedIndex;
            if (index == -1) return;
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter the new name", "Input", products[index].name, 0, 0);
            string price = Microsoft.VisualBasic.Interaction.InputBox("Enter the new price", "Input", products[index].price.ToString(), 0, 0);
            bool status = AdminFunctions.edit_product(admin_id, password, name, float.Parse(price), category_id, products[index].id);
            if (status)
            {
                products = UserRequest.list_products(category_id);
                listBox1.Items.Clear();
                foreach (var c in products)
                    listBox1.Items.Add(Uri.UnescapeDataString(c.name) + "\t" + c.price.ToString());
            }
        }

        // Delete product from database
        private void button4_Click(object sender, EventArgs e)
        {
            //Delete
            int index = listBox1.SelectedIndex;
            if (index == -1) return;
            bool status = AdminFunctions.delete_product(admin_id, password, category_id, products[index].id);
            if (status)
            {
                products = UserRequest.list_products(category_id);
                listBox1.Items.Clear();
                foreach (var c in products)
                    listBox1.Items.Add(Uri.UnescapeDataString(c.name) + "\t" + c.price.ToString());
            }
        }

        // View product details
        private void button1_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1) return;
            ProductView f = new ProductView(products[index], 0, "", true);
            f.Show();
        }

        // Load products into view
        private void AdminEditProducts_Load(object sender, EventArgs e)
        {
            foreach(var c in products)
            {
                listBox1.Items.Add(Uri.UnescapeDataString(c.name) + "\t" + c.price.ToString());
            }
        }
    }
}
