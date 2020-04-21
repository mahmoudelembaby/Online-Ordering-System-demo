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
    public partial class ListReviews : Form
    {
        BindingList<Review> display;
        public ListReviews(BindingList<Review> show)
        {
            InitializeComponent();
            display = show;
        }

        // Load reviews into listbox
        private void ListReviews_Load(object sender, EventArgs e)
        {
            foreach (var c in display) listBox1.Items.Add(Uri.UnescapeDataString(c.title) + "\t" + c.rating.ToString());
        }

        // View selected review
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index == -1) return;
            MessageBox.Show(Uri.UnescapeDataString(display[index].body));
        }
    }
}
