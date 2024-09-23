using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTour
{
    internal class Concert
    {
        private string country;
        private string city;
        private string venue;
        private Date date;
        private int attendance;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string Venue
        {
            get { return venue; }
            set { venue = value; }
        }
        public Date Date
        {
            get { return date; }
            set { date = value; }
        }
        public int Attendance
        {
            get { return attendance; }
            set { attendance = value; }
        }
    }
}
