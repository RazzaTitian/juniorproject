using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPlanner
{
    class Reminder
    {
        private string _msg;
        private DateTime _date;
        private DateTime _time;

        public string Message
        {
            get { return _msg; }
            set { _msg = value; }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public void setReminder()
        {

        }
        public void editReminder()
        {

        }
        public void deleteReminder()
        {

        }
        public void ringReminder()
        {

        }
    }
}
