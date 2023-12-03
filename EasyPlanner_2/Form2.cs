using System;
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
            listBoxEvents.SelectedIndexChanged += listBoxEvents_SelectedIndexChanged;
            btnDelete.Click += btnDelete_Click;
            btnUpdate.Click += btnUpdate_Click;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string insertSql = "INSERT INTO tb_events (event_id, event_title, event_description, event_date, event_time, event_location) " +
                                       "VALUES (@event_id, @event_title, @event_description, @event_date, @event_time, @event_location)";

                    using (var cmd = new NpgsqlCommand(insertSql, conn))
                    {
                        long timestamp = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                        cmd.Parameters.AddWithValue("@event_id", timestamp);
                        cmd.Parameters.AddWithValue("@event_title", tbTitle.Text);
                        cmd.Parameters.AddWithValue("@event_description", tbDescription.Text);
                        cmd.Parameters.AddWithValue("@event_date", dtpDateTime.Value.Date);
                        cmd.Parameters.AddWithValue("@event_time", dtpDateTime.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@event_location", tbLocation.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data acara telah berhasil disimpan. Event ID: " + timestamp);
                            DisplayEventTitles();
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
            DisplayEventTitles();
        }

        private void DisplayEventTitles()
        {
            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    string selectSql = "SELECT event_title FROM tb_events WHERE event_date = @event_date::date";

                    string formattedDate = $"{Form1.static_year}-{Form1.static_month:00}-{UserControlDays.static_day:00}";

                    using (var cmd = new NpgsqlCommand(selectSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@event_date", formattedDate);

                        using (var reader = cmd.ExecuteReader())
                        {
                            listBoxEvents.Items.Clear();

                            while (reader.Read())
                            {
                                string eventTitle = reader["event_title"].ToString();
                                listBoxEvents.Items.Add(eventTitle);
                            }

                            if (listBoxEvents.Items.Count == 0)
                            {
                                listBoxEvents.Items.Add("Tidak ada acara pada tanggal ini.");
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

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayEventDetails();
        }

        private void DisplayEventDetails()
        {
            try
            {
                if (listBoxEvents.SelectedIndex != -1)
                {
                    using (var conn = new NpgsqlConnection(connString))
                    {
                        conn.Open();

                        string selectDetailsSql = "SELECT event_description, event_location FROM tb_events WHERE event_title = @event_title";

                        string selectedEventTitle = listBoxEvents.SelectedItem.ToString();

                        using (var cmd = new NpgsqlCommand(selectDetailsSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@event_title", selectedEventTitle);

                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string eventDescription = reader["event_description"].ToString();
                                    string eventLocation = reader["event_location"].ToString();

                                    tbEventTitle.Text = selectedEventTitle;
                                    tbEventDescription.Text = eventDescription;
                                    tbEventLocation.Text = eventLocation;
                                }
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listBoxEvents_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxEvents.SelectedIndex != -1)
                {
                    using (var conn = new NpgsqlConnection(connString))
                    {
                        conn.Open();

                        string deleteSql = "DELETE FROM tb_events WHERE event_title = @event_title";

                        string selectedEventTitle = listBoxEvents.SelectedItem.ToString();

                        using (var cmd = new NpgsqlCommand(deleteSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@event_title", selectedEventTitle);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data acara telah berhasil dihapus.");
                                DisplayEventTitles();
                                ClearEventDetails(); // Menambah fungsi untuk membersihkan detail acara setelah dihapus
                            }
                            else
                            {
                                MessageBox.Show("Gagal menghapus data acara.");
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

        private void ClearEventDetails()
        {
            // Membersihkan kolom detail acara
            tbEventTitle.Text = string.Empty;
            tbEventDescription.Text = string.Empty;
            tbEventLocation.Text = string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxEvents.SelectedIndex != -1)
                {
                    using (var conn = new NpgsqlConnection(connString))
                    {
                        conn.Open();

                        string updateSql = "UPDATE tb_events SET event_title = @new_event_title, " +
                                           "event_description = @new_event_description, " +
                                           "event_location = @new_event_location " +
                                           "WHERE event_title = @event_title";

                        string selectedEventTitle = listBoxEvents.SelectedItem.ToString();

                        using (var cmd = new NpgsqlCommand(updateSql, conn))
                        {
                            // Mengambil nilai baru dari TextBoxes
                            string newEventTitle = tbEventTitle.Text;
                            string newEventDescription = tbEventDescription.Text;
                            string newEventLocation = tbEventLocation.Text;

                            // Parameter untuk query
                            cmd.Parameters.AddWithValue("@new_event_title", newEventTitle);
                            cmd.Parameters.AddWithValue("@new_event_description", newEventDescription);
                            cmd.Parameters.AddWithValue("@new_event_location", newEventLocation);
                            cmd.Parameters.AddWithValue("@event_title", selectedEventTitle);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data acara telah berhasil diupdate.");
                                DisplayEventTitles();
                                ClearEventDetails(); // Membersihkan kolom detail acara setelah diupdate
                            }
                            else
                            {
                                MessageBox.Show("Gagal mengupdate data acara.");
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
    }
}
