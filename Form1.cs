using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace LAB6BDPrakt
{
    public partial class Form1 : Form
    {
        string connection = "host = localhost; username = postgres; password = 22443311q; database = test";
        public Form1()
        {
            InitializeComponent();
            InitFill();
            
        }
        private void InitFill()
        {
            TableMain.Rows.Clear();
            TableMain.Columns.Clear();
            TableMain.Columns.Add("id", "id");
            TableMain.Columns.Add("Driver_name", "Driver_name");
            TableMain.Columns.Add("Driver_surname", "Driver_surname");
            TableMain.Columns.Add("id_park", "id_park");
            TableMain.Columns.Add("Driver_park_position", "Driver_park_position");
            TableMain.Columns.Add("Driver_now_parking", "Driver_now_parking");
            TableMain.Columns.Add("Driver_payment_status", "Driver_payment_status");
            TableMain.Columns[0].Visible = false;
            TableMain.Columns[3].Visible = false;
            using (var connect = new NpgsqlConnection(connection))
            {
                connect.Open();
                var Command = new NpgsqlCommand
                {
                    Connection = connect,
                    CommandText = @"select driver.id, name, surname,park_place, parkingposition, nowparking, parking_pay  from parking inner join driver on parking.id = driver.park_place"
                };
                var reader = Command.ExecuteReader();
                while (reader.Read())
                    TableMain.Rows.Add(reader["id"],reader["name"], reader["surname"],reader["park_place"], reader["parkingposition"], reader["nowparking"], reader["parking_pay"]);
            }
            foreach(DataGridViewRow row in TableMain.Rows)
            {
                if(row.Tag != null)
                {
                    List <object> tag = new List<object>();
                    foreach(DataGridViewCell cell in row.Cells)
                    {
                        tag.Add(cell.Value);
                    }
                    row.Tag = tag;
                }
               
            }
            


        }

        private void DeleteBut_Click(object sender, EventArgs e)
        {
            using (var connect = new NpgsqlConnection(connection))
            {
                connect.Open();
                var command_del = new NpgsqlCommand("delete from driver where id = @id;",connect);
                var adapter = new NpgsqlDataAdapter(command_del);
                command_del.Parameters.AddWithValue("@id", int.Parse(TableMain.SelectedRows[0].Cells["id"].Value.ToString()));
                command_del.ExecuteNonQuery();
                TableMain.Rows.Remove(TableMain.SelectedRows[0]);

            }
            
        }

        private void TableMain_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = TableMain.Rows[e.RowIndex];
            if(TableMain.IsCurrentRowDirty)// если данные изменяются
            {
                if (!e.Cancel)  // событие не отменено
                {
                    using (var connect = new NpgsqlConnection(connection))
                    {
                        connect.Open();
                        var command_driver = new NpgsqlCommand() { Connection = connect };
                        var command_parking = new NpgsqlCommand() { Connection = connect };
                        command_driver.Parameters.AddWithValue("@name", row.Cells["Driver_name"].Value);
                        command_driver.Parameters.AddWithValue("@surname", row.Cells["Driver_surname"].Value);
                        command_driver.Parameters.AddWithValue("@parking_pay", bool.Parse(row.Cells["Driver_payment_status"].Value.ToString()));
                        command_parking.Parameters.AddWithValue("@parkingposition", int.Parse(row.Cells["Driver_park_position"].Value.ToString()));
                        command_parking.Parameters.AddWithValue("@nowparking", bool.Parse(row.Cells["Driver_now_parking"].Value.ToString()));
                        if (row.Tag == null)
                        {
                            command_parking.CommandText = @"insert into parking (parkingposition, nowparking) VALUES (@parkingposition,@nowparking) returning id;";
                            try
                            {
                                int id = (int)command_parking.ExecuteScalar();
                                command_driver.Parameters.AddWithValue("@park_place", id);
                            }
                            catch (Exception E)
                            {
                                Console.WriteLine(E.Message);
                            }
                            command_driver.CommandText = @"insert into driver (name,surname,park_place,parking_pay) values (@name,@surname,@park_place,@parking_pay);";
                            command_driver.ExecuteNonQuery();
                           
                        }
                        else if (row.Tag != null)
                        {
                            command_driver.Parameters.AddWithValue("@id", row.Cells["id"].Value);
                            command_parking.Parameters.AddWithValue("@park_place", row.Cells["id_park"].Value);
                            command_driver.CommandText = @"update driver set name = @name, surname = @surname, park_place = @park_place, parking_pay = @parking_pay where id = @id;";
                            command_parking.CommandText = @"update parking set parkingposition = @parkingposition, nowparking = @nowparking where id = @park_place;";

                            command_driver.ExecuteNonQuery();
                            command_parking.ExecuteNonQuery();
                        }

                    }
                }
           
            }
            foreach(DataGridViewRow row_ in TableMain.Rows)
            {
                List<object> values = new List<object>();
                foreach(DataGridViewCell cell in row_.Cells)
                {
                    values.Add(cell.Value);
                }

                row_.Tag = values;
                if (row_.IsNewRow)
                {
                    row_.Tag = null;
                }
            }
        }
    }
}
