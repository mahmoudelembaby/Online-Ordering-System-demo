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
    public partial class Cms : Form
    {
        string admin_id, password;
        public Cms(string id,string pass)
        {
            InitializeComponent();
            admin_id = id;
            password = pass;
        }

        //Add/Edit Categories
        private void button1_Click(object sender, EventArgs e)
        {
            AdminEditCategories f = new AdminEditCategories(admin_id, password);
            f.Show();
        }

        //Add/Edit Orders
        private void button2_Click(object sender, EventArgs e)
        {
            AdminEditOrders f = new AdminEditOrders(admin_id, password);
            f.Show();
        }

        private void Cms_Load(object sender, EventArgs e)
        {

        }
    }
}
