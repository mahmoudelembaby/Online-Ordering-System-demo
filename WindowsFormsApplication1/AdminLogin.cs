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
    public partial class AdminLogin : Form
    {

        // Initialize
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        // Listens for login button and logs admin in if authenticated
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text, password = textBox2.Text;
            if (name == "") { errorProvider1.SetError(this.textBox1, "Enter Admin ID"); return; }
            else errorProvider1.Clear();
            if (password == "") { errorProvider2.SetError(this.textBox2, "Enter Password"); return; }
            else errorProvider2.Clear();
            name = System.Uri.EscapeDataString(name);
            password = System.Uri.EscapeDataString(password);
            bool status = Auth.admin_auth(name, password);
            if (status == false) return;
            Cms f = new Cms(name, password);
            f.Show();
            this.Hide();
        }
    }
}
