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
    public partial class UserOrders : Form
    {
        string password;
        int uid;
        public BindingList<Order> display;
        public UserOrders(int id, string pass)
        {
            InitializeComponent();
            uid = id;
            password = pass;
            display = UserRequest.list_orders(uid,password);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Load order data into listbox
        private void UserOrders_Load(object sender, EventArgs e)
        {
            foreach (Order c in display) c.init();
            dataGridView1.DataSource = display;
            dataGridView1.Invalidate();
            dataGridView1.Refresh();
        }

        // Remove order
        private void button1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            bool status = UserRequest.delete_order(uid, password, display[index].id);
            if (status)
            {
                display.RemoveAt(index);
                dataGridView1.Invalidate();
                dataGridView1.Refresh();
            }
        }

        // Edit order
        private void button2_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            UserEditOrder f = new UserEditOrder(uid, password, display[index].id);
            f.Show();
            Hide();
        }
    }
}
