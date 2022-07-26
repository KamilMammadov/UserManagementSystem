﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Database.Models
{
    class Report
    {
        public User FromUser { get; set; }
        public User ToUser { get; set; }


        public static int _rowNumber;
        public static int RowNumber { get;private set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }

        public string Text { get; set; }
        public DateTime ReportTime { get; set; }


        public Report(string fromEmail,string toEmail,string text)
        {
            RowNumber = _rowNumber;
            FromEmail = fromEmail;
            ToEmail = toEmail;
            Text = text;
            _rowNumber++;
            ReportTime = DateTime.Now;
        }

    
        

    }
}
