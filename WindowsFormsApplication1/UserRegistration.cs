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
    public partial class UserRegistration : Form
    {
        public UserRegistration()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        // get user data for registration and send it to server
        private void button1_Click(object sender, EventArgs e)
        {
            string name = Uri.EscapeDataString(textBox1.Text), first = Uri.EscapeDataString(textBox2.Text), last = Uri.EscapeDataString(textBox3.Text), phone = textBox4.Text, email = textBox5.Text, pass = Uri.EscapeDataString(textBox6.Text), pass_confirmation = Uri.EscapeDataString(textBox7.Text);

            if (name == "") { errorProvider1.SetError(this.textBox1, "Enter Username"); return; }
            else errorProvider1.Clear();

            if (first == "") { errorProvider2.SetError(this.textBox2, "Enter First name"); return; }
            else errorProvider2.Clear();

            if (last == "") { errorProvider3.SetError(this.textBox3, "Enter last name"); return; }
            else errorProvider3.Clear();

            if (phone == "") { errorProvider4.SetError(this.textBox4, "Enter Phone number"); return; }
            else errorProvider4.Clear();

            if (email == "") { errorProvider5.SetError(this.textBox5, "Enter E-mail"); return; }
            else errorProvider5.Clear();

            if (pass == "") { errorProvider6.SetError(this.textBox6, "Enter Password"); return; }
            else errorProvider6.Clear();

            if (pass_confirmation == "") { errorProvider7.SetError(this.textBox7, "Enter Password confirmation"); return; }
            else errorProvider7.Clear();

            if (pass_confirmation != pass) { errorProvider8.SetError(this.textBox6, "Password and Password confirmation should match"); return; }
            else errorProvider8.Clear();

            bool status = UserRequest.user_register(name, first, last, email, phone, pass, pass_confirmation);

            if (status == false) return;
            else { Hide(); MessageBox.Show("Success"); }

        }

        private void UserRegistration_Load(object sender, EventArgs e)
        {

        }
    }
}
