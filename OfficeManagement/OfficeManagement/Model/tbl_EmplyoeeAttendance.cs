//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OfficeManagement.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_EmplyoeeAttendance
    {
        public int Attendance_Id { get; set; }
        public string EID { get; set; }
        public Nullable<System.DateTime> Attendance_Date { get; set; }
        public Nullable<System.TimeSpan> In_Time { get; set; }
        public Nullable<System.TimeSpan> Out_Time { get; set; }
        public Nullable<System.DateTime> Edit_Date { get; set; }
        public string Edit_User { get; set; }
    }
}