using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class DayBookBL
    {
        [Key]
        public long AccountNo { get; set; }
        public string Date { get; set; }
        public string AccountName { get; set; }
        public string AccountDescription { get; set; }
        public string AccountAmount { get; set; }
        public bool IsNeedsToDelete { get; set; }
    }
}