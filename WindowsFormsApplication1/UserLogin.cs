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
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserLogin_Load(object sender, EventArgs e)
        {

        }

        // Login user
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text, password = textBox2.Text;
            if (name == "") { errorProvider1.SetError(this.textBox1, "Enter Username"); return; }
            else errorProvider1.Clear();
            if (password == "") { errorProvider2.SetError(this.textBox2, "Enter Password"); return; }
            else errorProvider2.Clear();
            name = System.Uri.EscapeDataString(name);
            password = System.Uri.EscapeDataString(password);
            int uid = Auth.user_auth(name, password);
            if (uid == -1) return;
            UserScreen f = new UserScreen(uid, password);
            this.Hide();
            f.Show();
        }
    }
}
