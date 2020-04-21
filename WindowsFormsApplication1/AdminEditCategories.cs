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
    public partial class AdminEditCategories : Form
    {
        string admin_id, password;
        public BindingList<category> categories;
        public AdminEditCategories(string id, string pass)
        {
            InitializeComponent();
            admin_id = id;
            password = pass;
            categories = UserRequest.list_categories();
        }

        // Loads categories into listbox
        private void AdminEditCategories_Load(object sender, EventArgs e)
        {
            foreach (var c in categories)
            {
                listBox1.Items.Add(Uri.UnescapeDataString(c.name));
            }
        }

        // Listens for edit button click
        private void button3_Click(object sender, EventArgs e)
        {            
            int index = listBox1.SelectedIndex;
            if (index == -1) return;
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter the new name", "Input", "", 0, 0);
            bool status = AdminFunctions.edit_category(admin_id, password, categories[index].id, System.Uri.EscapeDataString(input));
            if (status)
            {
                categories = UserRequest.list_categories();
                listBox1.Items.Clear();
                foreach (var c in categories)
                    listBox1.Items.Add(Uri.UnescapeDataString(c.name));
            }
        }

        // listens for delete button click
        private void button4_Click(object sender, EventArgs e)
        {         
            int index = listBox1.SelectedIndex;
            if (index == -1) return;
            bool status = AdminFunctions.delete_category(admin_id, password, categories[index].id);
            if (status)
            {
                categories = UserRequest.list_categories();
                listBox1.Items.Clear();
                foreach (var c in categories)
                    listBox1.Items.Add(Uri.UnescapeDataString(c.name));
            }
        }

        // listen for view button click
        private void button1_Click(object sender, EventArgs e)
        {            
            int index = listBox1.SelectedIndex;
            if (index == -1) return;
            AdminEditProducts f = new AdminEditProducts(categories[index].id, admin_id, password);
            f.Show();            
        }

        // listen for add button click
        private void button2_Click(object sender, EventArgs e)
        {            
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter category name", "Input", "", 0, 0);
            bool status = AdminFunctions.add_category(admin_id, password, System.Uri.EscapeDataString(input));
            if (status)
            {
                categories = UserRequest.list_categories();
                listBox1.Items.Clear();
                foreach (var c in categories)
                    listBox1.Items.Add(Uri.UnescapeDataString(c.name));
            }
        }
    }
}
