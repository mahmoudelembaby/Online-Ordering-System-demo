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
    public partial class AdminEditOrders : Form
    {
        BindingList<Order> display;
        string admin_id, password;
        //  Initialize
        public AdminEditOrders(string id, string pass)
        {
            InitializeComponent();
            admin_id = id;
            password = pass;
            display = AdminFunctions.list_orders(id, pass);
        }

        // Edit order status
        private void button1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            string new_status = Microsoft.VisualBasic.Interaction.InputBox("Enter the new status\n'0' = Pending\n'1' = Delivering\n'2' = Delivered", "Input", display[index].int_status.ToString(), 0, 0);
            bool status = AdminFunctions.edit_order_status(admin_id, password, display[index].id, Int32.Parse(new_status));
            if (status)
            {
                display[index].int_status = Int32.Parse(new_status);
                display[index].init();
                dataGridView1.Invalidate();
                dataGridView1.Refresh();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Load data from orders
        private void AdminEditOrders_Load(object sender, EventArgs e)
        {
            foreach (var c in display) c.init();
            dataGridView1.DataSource = display;
            dataGridView1.Invalidate();
            dataGridView1.Refresh();
        }
    }
}
