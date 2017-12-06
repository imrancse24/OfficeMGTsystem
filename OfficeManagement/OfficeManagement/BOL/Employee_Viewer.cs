using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeManagement.BOL
{
    public class Employee_Viewer
    {
        public string EID { get; set; }
        public string EmployeeName { get; set; }
        public int Office_Id { get; set; }
        public string Office_Name { get; set; }
        public int Department_Id { get; set; }
        public string Department_Name { get; set; }
        public TimeSpan In_Time { get; set; }

        public TimeSpan Out_Time { get; set; }
    }
}