using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeManagement.BOL
{
    public class Department_Viewer
    {
        public int Department_Id { get; set; }
        public string Department_Name { get; set; }
        public int Office_Id { get; set; }
        public string Office_Name { get; set; }
    }
}