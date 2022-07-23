using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Database.Models
{
    class Report
    {
        public static int _rowNumber;
        public static int RowNumber { get;private set; }

        public string Text { get; set; }

        public Report(int rowNumber,string text)
        {
            RowNumber = rowNumber;
            Text = text;
            _rowNumber++;
        }

    }
}
