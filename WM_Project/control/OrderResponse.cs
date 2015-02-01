using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WM_Project.control
{
    public class OrderResponse
    {
        private string[] errors;

        public string[] Errors
        {
            get { return errors; }
            set { errors = value; }
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        private string leaderOrderNumber;

        public string LeaderOrderNumber
        {
            get { return leaderOrderNumber; }
            set { leaderOrderNumber = value; }
        }

        private string orderNumber;

        public string OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        private string trackNumber;

        public string TrackNumber
        {
            get { return trackNumber; }
            set { trackNumber = value; }
        }


    }
}