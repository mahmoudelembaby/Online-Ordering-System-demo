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
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }

        // Show user login screen
        private void button2_Click(object sender, EventArgs e)
        {
            UserLogin f = new UserLogin();
            this.Hide();
            f.Show();
        }

        // Show admin login screen
        private void button2_Click_1(object sender, EventArgs e)
        {
            AdminLogin f = new AdminLogin();
            this.Hide();
            f.Show();
        }

        // Show user registration screen
        private void button3_Click(object sender, EventArgs e)
        {
            UserRegistration f = new UserRegistration();
            f.Show();
        }
    }
}
