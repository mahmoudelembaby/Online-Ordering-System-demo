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
    public partial class UserEditOrder : Form
    {
        int uid;
        string password;
        int order_id;
        public UserEditOrder(int id, string pass, int oid)
        {
            InitializeComponent();
            uid = id;
            password = pass;
            order_id = oid;
        }

        // Change quantity
        private void button1_Click(object sender, EventArgs e)
        {
            string quantity = textBox1.Text;
            foreach (char i in quantity)
            {
                if (i < '0' || i > '9')
                {
                    errorProvider1.SetError(textBox1, "Only digits between 0-9 allowed");
                    return;
                }
            }
            errorProvider1.Clear();
            if (Int32.Parse(quantity) > 1000 || Int32.Parse(quantity) < 1)
            {
                errorProvider1.SetError(textBox1, "Please enter a positive integer between 1 - 1000");
                return;
            }
            errorProvider1.Clear();
            bool status = UserRequest.edit_order(uid, password, order_id,Int32.Parse(quantity));
            if (status)
            {
                MessageBox.Show("Success");
            }
            Hide();
            UserOrders f = new UserOrders(uid, password);
            f.Show();
        }

        private void UserEditOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
