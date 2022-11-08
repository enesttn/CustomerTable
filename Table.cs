using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GreatCustomers
{
    public partial class Table : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;
        public Table()
        {
            InitializeComponent();
        }

        void GetTable()
        {
            conn = new SqlConnection(@"Server=DESKTOP-U2PVNK1\SQLEXPRESS;Database=HERMES;User Id=sa;Password=123456");
            conn.Open();
            da = new SqlDataAdapter("SELECT *FROM HermesTable53", conn);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            conn.Close();
        }



        private void Table_Load(object sender, EventArgs e)
        {
            GetTable();
        }

        private void Ad_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtPhone.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtCompany.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            dtAdd.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void btEkle_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO HermesTable53 (first_name,last_name,email,phone,adress,company,bdate) VALUES (@first_name,@last_name,@email,@phone,@adress,@company,@bdate)";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@first_name", txtAd.Text);
            cmd.Parameters.AddWithValue("@last_name", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@adress", txtAdres.Text);
            cmd.Parameters.AddWithValue("@company", txtCompany.Text);
            cmd.Parameters.AddWithValue("@bdate", dtAdd.Value);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            GetTable();


        }

        private void btSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
              var id=  row.Cells["ID"].Value.ToString();

                string query = "DELETE FROM HermesTable53 WHERE ID= @ID";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(id));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                GetTable();

            }







        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
             string query = "UPDATE HermesTable53 SET first_name=@first_name, last_name=@last_name, email=@email, phone=@phone,adress=@adress,company=@company,bdate=@bdate WHERE ID=@ID";
            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtNo.Text));
            cmd.Parameters.AddWithValue("@first_name", txtAd.Text);
            cmd.Parameters.AddWithValue("@last_name", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@adress", txtAdres.Text);
            cmd.Parameters.AddWithValue("@company", txtCompany.Text);
            cmd.Parameters.AddWithValue("@bdate", dtAdd.Value);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
           GetTable();
          


             /* if (dataGridView1.SelectedRows.Count != 0)
             {
                 DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                 var id = row.Cells["ID"].Value.ToString();

                 string query = "UPDATE HermesTable53 SET first_name=@first_name, last_name=@last_name, email=@email, phone=@phone,adress=@adress,company=@company,bdate=@bdate WHERE ID=@ID";
                 cmd = new SqlCommand(query, conn);
                 cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(id));
                 conn.Open();
                 cmd.ExecuteNonQuery();
                 conn.Close();
                 GetTable();

             }
            
            */






        }
    }
}
