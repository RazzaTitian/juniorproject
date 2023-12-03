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
    public partial class UserControlDays : UserControl
    {
        string connString = "Host=localhost;Port=5433;Username=postgres;Password=coneheadzombie;Database=junior-project";
        public static string static_day;
        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }
        public void days(int numday)
        {
            lbDays.Text = numday+"";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = lbDays.Text;
            // timer1.Start();
            Form2 form2 = new Form2();
            form2.Show();
        }

        /* private void displayEvent()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string selectSql = "SELECT event_title FROM tb_events WHERE event_date = @event_date::date"; // Menggunakan konversi ke tipe data date

                    // Format tanggal sesuai dengan kolom "event_date" pada tabel tb_events
                    string formattedDate = $"{Form1.static_year}-{Form1.static_month:00}-{static_day:00}";

                    using (var cmd = new NpgsqlCommand(selectSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@event_date", formattedDate);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string eventTitle = reader["event_title"].ToString();
                                lbEvent.Text = eventTitle;
                            }
                            else
                            {
                                lbEvent.Text = "Tidak ada acara pada tanggal ini.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            displayEvent();
        } */
    }
}
