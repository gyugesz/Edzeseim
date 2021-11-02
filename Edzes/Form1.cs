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
    public partial class Form1 : Form
    {
        MySqlConnection con = new MySqlConnection("Server=inventory-do-user-9982915-0.b.db.ondigitalocean.com;user=doadmin;database=valami;port=25060;password=lSoEsliJ35yJUvBi");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            else
            {
                con.Open();

            }


            MySqlCommand cmd3 = con.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select * from edzo";
            cmd3.ExecuteNonQuery();
            DataTable dt3 = new DataTable();
            MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
            da3.Fill(dt3);
            dataGridView1.DataSource = dt3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Nem hagyhatod üresen a tavolság mezőt! Ha nem tettél meg távot,akkor 0-át írj!");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Nem hagyhatod üresen az elégetett kalória mezőt! Ha nem égettél kalóriát,akkor 0-át írj!");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Nem hagyhatod üresen az edzés_idő mezőt! Ha nin mért időd,akkor 0-át írj!");
            }

            else
            {
                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select * from edzo ";
                cmd1.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                da1.Fill(dt1);



                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into edzo (ido,__suly__,gyakorlat,tavolsag,caloria,edzes_ido,Megjegyzes) values( '" + dateTimePicker1.Value.ToString("yyy-MM-dd") + "','" + textBox5.Text + "','" + comboBox1.Text + "','" + textBox1.Text + "','" + textBox6.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Az adatok mentése sikeres");

                MySqlCommand cmd3 = con.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select * from edzo";
                cmd3.ExecuteNonQuery();
                DataTable dt3 = new DataTable();
                MySqlDataAdapter da3 = new MySqlDataAdapter(cmd3);
                da3.Fill(dt3);
                dataGridView1.DataSource = dt3;


                textBox5.Text = "";
                comboBox1.Text = "";
                textBox1.Text = "";
                textBox6.Text = "";
            }

                
            
        }

        public void display()
        {
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM edzo";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter de = new MySqlDataAdapter(cmd);
            de.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            var value = dataGridView1.SelectedCells[0].Value;
            if (value == null) return;
            try
            {
                id = Convert.ToInt32(value.ToString());
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from edzo where id=" + id + "";
                cmd.ExecuteNonQuery();

                display();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Statistic s = new Statistic();
            s.Show();
        }

        public void fill_dg()
        {

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from edzo";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void button4_Click(object sender, EventArgs e)
        {

            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            MessageBox.Show(i.ToString());

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update edzo set ido,__suly__='" + dateTimePicker1.Value.ToString("yyy-MM-dd") + "','" + textBox5.Text + "' where id =" + i + "";
            cmd.ExecuteNonQuery();

            fill_dg();






        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                for (int i = 0; i < id; i++)
                {
                }
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from edzo where id=" + id + "";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    dateTimePicker1.Text = dr["ido"].ToString();
                    textBox5.Text = dr["__suly__"].ToString();
                    comboBox1.Text = dr["gyakorlat"].ToString();
                    textBox1.Text = dr["tavolsag"].ToString();
                    textBox6.Text = dr["caloria"].ToString();
                    textBox2.Text = dr["edzes_ido"].ToString();
                    textBox3.Text = dr["Megjegyzes"].ToString();

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Nincs kijelölve semmi a táblából");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            MessageBox.Show(i.ToString());

            MySqlCommand cmd = con.CreateCommand();
           
            cmd.CommandText = "update edzo set __suly__='" + textBox5.Text + "' where id =" + i + "";
           
            cmd.ExecuteNonQuery();

            fill_dg();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            MessageBox.Show(i.ToString());

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
           
            cmd.CommandText = "update edzo set gyakorlat='" + comboBox1.Text + "' where id =" + i + "";
           
            cmd.ExecuteNonQuery();

            fill_dg();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            MessageBox.Show(i.ToString());

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            
            cmd.CommandText = "update edzo set tavolsag='" + textBox1.Text + "' where id =" + i + "";
           
            cmd.ExecuteNonQuery();

            fill_dg();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            MessageBox.Show(i.ToString());

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
          
            cmd.CommandText = "update edzo set caloria='" + textBox6.Text + "' where id =" + i + "";
           
            cmd.ExecuteNonQuery();

            fill_dg();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            MessageBox.Show(i.ToString());

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update edzo set edzes_ido='" + textBox2.Text + "' where id =" + i + "";
           
            cmd.ExecuteNonQuery();

            fill_dg();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            MessageBox.Show(i.ToString());

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
           
            cmd.CommandText = "update edzo set Megjegyzes='" + textBox3.Text + "' where id =" + i + "";
            cmd.ExecuteNonQuery();

            fill_dg();

        }
    }
}



