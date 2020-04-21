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
    public partial class UserScreen : Form
    {
        int uid;
        string password;
        public UserScreen(int id, string pass)
        {
            InitializeComponent();
            uid = id;
            password = pass;
        }

        // Show categories for user
        private void button1_Click(object sender, EventArgs e)
        {
            CategoryList f = new CategoryList(uid, password);
            f.Show();
        }

        private void UserScreen_Load(object sender, EventArgs e)
        {

        }

        // Show orders the user had placed earlier
        private void button2_Click(object sender, EventArgs e)
        {
            UserOrders f = new UserOrders(uid, password);
            f.Show();
        }

        // Show reviews the user had written earlier
        private void button3_Click(object sender, EventArgs e)
        {
            BindingList<Review> reviews = UserRequest.list_user_reviews(uid);
            ListReviews f = new ListReviews(reviews);
            f.Show();
        }
    }
}
