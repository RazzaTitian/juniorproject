using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPlanner
{
    class Schedule
    {
        private int _schID;
        private string _title;
        private string _desc;
        private DateTime _date;
        private DateTime _time;
        private string _loc;

        public int ScheduleID
        {
            get { return _schID; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value;  }
        }
        public string Description
        {
            get { return _desc; }
            set { _desc = value; }
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
        public string Location
        {
            get { return _loc; }
            set { _loc = value; }
        }
        
        public void createSchedule()
        {

        }
        public void editSchedule()
        {

        }
        public void deleteSchedule()
        {

        }
    }
}
