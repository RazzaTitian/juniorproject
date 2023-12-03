using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;


namespace EasyPlanner_2
{
    public partial class Form1 : Form
    {
        int month, year;
        public static int static_month, static_year;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            displayDays();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();
            if (month == 12)
            {
                month = 0;
                year++;
            }
            month++;
            display(month, year);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            dayContainer.Controls.Clear();
            if (month == 1)
            {
                month = 13;
                year--;
            }
            month--;
            display(month, year);
        }

        private void displayDays ()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            display(month, year);
        }

        private void display (int month, int year)
        {
            static_month = month;
            static_year = year;
            lbMonthYear.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(month) + ", " + year;
            DateTime startOfTheMonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayOfTheWeek = Convert.ToInt32(startOfTheMonth.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < dayOfTheWeek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                dayContainer.Controls.Add(ucblank);
            }
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                dayContainer.Controls.Add(ucdays);
            }
        }
    }
}
