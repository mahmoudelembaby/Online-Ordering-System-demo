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
    public partial class CategoryList : Form
    {
        public BindingList<category> categories;
        int uid; // user_id
        string password;
        public CategoryList(int id, string pass)
        {
            InitializeComponent();
            categories = UserRequest.list_categories();
            uid = id;
            password = pass;
        }

        // Load items into listbox
        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (var c in categories)
            {
                listBox1.Items.Add(Uri.UnescapeDataString(c.name));
            }
        }

        // show products of selected category
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1) return;
            ProductsList f = new ProductsList(categories[index].id, uid, password);
            f.Show();
        }

    }

}
