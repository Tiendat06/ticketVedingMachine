using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ticketVedingMachine
{
    public partial class PaymentMethod : Form
    {
        public PaymentMethod()
        {
            InitializeComponent();
        }

        private void qrCode_Click(object sender, EventArgs e)
        {
            pictureBox.Image = Properties.Resources.qr;
            textBox.Text = null;

        }

        private void creCard_Click(object sender, EventArgs e)
        {
            textBox.Text = "Please enter your credit card";
            pictureBox.Image = null;

        }

        private void PaymentMethod_Load(object sender, EventArgs e)
        {
            MainForm f = new MainForm();
            f.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
