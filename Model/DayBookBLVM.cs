using AdminUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminUI.Model
{
    public class DayBookBLVM
    {
        public DayBookBLVM()
        {
            ObjDayBookBLList = new List<DayBookBL>();
        }
        public List<DayBookBL> ObjDayBookBLList { get; set; }
    }
}