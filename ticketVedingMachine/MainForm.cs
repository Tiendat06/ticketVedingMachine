using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ticketVedingMachine
{

    public partial class MainForm : Form
    {
        SqlConnection conn = new SqlConnection(Program.myConn);
        public MainForm()
        {
            InitializeComponent();
        }

        private void loadData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from Destination" +
                    " where desID='" + comboBoxDes.SelectedValue + "' and desTime='" + Convert.ToDateTime(dateTimePicker1.Text).ToShortDateString()+"'", conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    button1.Enabled = true;
                    button3.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                
                SqlCommand cmd = new SqlCommand("select * from Destination", conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //dataGridViewDepartment.DataSource = dt;
                    comboBoxDes.DataSource = dt;
                    comboBoxDes.DisplayMember = "desName";
                    comboBoxDes.ValueMember = "desID";
                    button1.Enabled = false;
                    button3.Enabled = false;

                    //loadData();
                }
                else
                {
                    MessageBox.Show("No Data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void ticketVendingMachine_Click(object sender, EventArgs e)
        {

        }

        // search click
        private void searchBtn_Click(object sender, EventArgs e)
        {
            
            loadData();
        }

        // Choose click
        private void button1_Click(object sender, EventArgs e)
        {
            string desID = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string cost = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string quan = textBoxQuan.Text;
            //MessageBox.Show(cost);

            if (String.IsNullOrEmpty(quan))
            {
                quan = "1";
            }

            int total = Convert.ToInt32(cost) * Convert.ToInt32(quan);

            textBoxPrice.Text = total.ToString();  

            
        }

        // All click
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button3.Enabled = true;
            try
            {
                SqlCommand cmd = new SqlCommand("select * from Destination", conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No data");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ok click
        private void button3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxPrice.Text))
            {
            this.Close();
            }
        }
    }
}
