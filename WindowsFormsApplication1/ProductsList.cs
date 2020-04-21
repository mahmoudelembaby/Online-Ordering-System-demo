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
    public partial class ProductsList : Form
    {
        public static BindingList<product> products;
        int uid;
        string password;

        // Initialize
        public ProductsList(int id,int Uid, string pass)
        {
            InitializeComponent();
            products = UserRequest.list_products(id);
            uid = Uid;
            password = pass;
        }

        // Load categories into listbox
        private void category_Load(object sender, EventArgs e)
        {
            foreach (var c in products)
            {
                listBox1.Items.Add(Uri.UnescapeDataString(c.name));
            }
        }

        // View product list for selected category
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1) return;
            ProductView f = new ProductView(products[index], uid, password,false);
            f.Show();
        }
    }
}
