
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class PublishBL
    {
        [Key]
        public long PublishId { get; set; }
        public Nullable<long> CustomerId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string MediaUrl { get; set; }
        public Nullable<System.DateTime> PublishDate { get; set; }
        public Nullable<int> FrequencyInDays { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UserId { get; set; }

        public string CustomerName { get; set; }
        public string ProductName { get; set; }

        public bool IsNeedsToDelete { get; set; }
    }
}