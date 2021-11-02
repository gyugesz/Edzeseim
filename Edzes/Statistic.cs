using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edzes
{
    public partial class Statistic : Form
    {
        MySqlConnection con = new MySqlConnection("Server=inventory-do-user-9982915-0.b.db.ondigitalocean.com;user=doadmin;database=valami;port=25060;password=lSoEsliJ35yJUvBi");
        public Statistic()
        {
            InitializeComponent();
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            else
            {
                con.Open();
            }


            decimal  k = 0;
            decimal i = 0;
            decimal j = 0;
            MySqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from edzo";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            foreach (DataRow dr in dt1.Rows)
            {
                j = j + Convert.ToDecimal(dr["tavolsag"].ToString());
                i = i + Convert.ToDecimal(dr["edzes_ido"].ToString());
                k = k + Convert.ToDecimal(dr["caloria"].ToString());
            }

            label1.Text = j.ToString()+" km";
            label2.Text = k.ToString()+ " cal";
            label3.Text = i.ToString()+ " óra";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal k = 0;
            decimal i = 0;
            decimal j = 0;
            MySqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select * from edzo";
            cmd1.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            foreach (DataRow dr in dt1.Rows)
            {
                j = j + Convert.ToDecimal(dr["tavolsag"].ToString());
                i = i + Convert.ToDecimal(dr["edzes_ido"].ToString());
                k = k + Convert.ToDecimal(dr["caloria"].ToString());
            }

            label1.Text = j.ToString() + " km";
            label2.Text = k.ToString() + " cal";
            label3.Text = i.ToString() + " óra";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal k = 0;
            decimal i = 0;
            decimal j = 0;
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from edzo where gyakorlat='" + comboBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            foreach (DataRow dr in dt.Rows)
            {
                j = j + Convert.ToDecimal(dr["tavolsag"].ToString());
                i = i + Convert.ToDecimal(dr["edzes_ido"].ToString());
                k = k + Convert.ToDecimal(dr["caloria"].ToString());
            }
            label1.Text = j.ToString() + " km";
            label2.Text = k.ToString() + " cal";
            label3.Text = i.ToString() + " óra";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal k = 0;
            decimal i = 0;
            decimal j = 0;
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from edzo where ido='" + dateTimePicker1.Value.ToString("yyy-MM-dd") +"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            foreach (DataRow dr in dt.Rows)
            {
                j = j + Convert.ToDecimal(dr["tavolsag"].ToString());
                i = i + Convert.ToDecimal(dr["edzes_ido"].ToString());
                k = k + Convert.ToDecimal(dr["caloria"].ToString());
            }
            label1.Text = j.ToString() + " km";
            label2.Text = k.ToString() + " cal";
            label3.Text = i.ToString() + " óra";
        }

     

        private void button4_Click_1(object sender, EventArgs e)
        {
            decimal k = 0;
            decimal i = 0;
            decimal j = 0;
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from edzo where ido='" + dateTimePicker1.Value.Month.ToString("dd-MM-yyy") + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            foreach (DataRow dr in dt.Rows)
            {
                j = j + Convert.ToDecimal(dr["tavolsag"].ToString());
                i = i + Convert.ToDecimal(dr["edzes_ido"].ToString());
                k = k + Convert.ToDecimal(dr["caloria"].ToString());
            }
            label1.Text = j.ToString() + " km";
            label2.Text = k.ToString() + " cal";
            label3.Text = i.ToString() + " óra";
        }
    }
    
}
