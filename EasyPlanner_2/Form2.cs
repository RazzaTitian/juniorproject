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

namespace EasyPlanner_2
{
    public partial class Form2 : Form
    {
        string connString = "Host=localhost;Port=5433;Username=postgres;Password=coneheadzombie;Database=junior-project";
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Buat koneksi ke database
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    // Buat perintah SQL untuk melakukan INSERT
                    string insertSql = "INSERT INTO tb_events (event_id, event_title, event_description, event_date, event_time, event_location) " +
                        "VALUES (@event_id, @event_title, @event_description, @event_date, @event_time, @event_location)";

                    using (var cmd = new NpgsqlCommand(insertSql, conn))
                    {
                        // Ganti nilai-nilai berikut dengan nilai yang sesuai
                        cmd.Parameters.AddWithValue("@event_id", 1); // Isi dengan nilai yang sesuai
                        cmd.Parameters.AddWithValue("@event_title", tbTitle.Text); // Ganti dengan judul acara yang diinginkan
                        cmd.Parameters.AddWithValue("@event_description", tbDescription.Text); // Ganti dengan deskripsi acara yang diinginkan
                        cmd.Parameters.AddWithValue("@event_date", dtpDateTime.Value.Date); // Ganti dengan tanggal yang sesuai
                        cmd.Parameters.AddWithValue("@event_time", dtpDateTime.Value.TimeOfDay); // Ganti dengan waktu yang sesuai
                        cmd.Parameters.AddWithValue("@event_location", tbLocation.Text); // Ganti dengan lokasi acara yang diinginkan

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data acara telah berhasil disimpan.");
                        }
                        else
                        {
                            MessageBox.Show("Gagal menyimpan data acara.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dtpDateTime.Value = new DateTime(Form1.static_year, Form1.static_month, int.Parse(UserControlDays.static_day));
        }
    }
}
