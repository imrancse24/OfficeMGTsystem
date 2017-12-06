using OfficeManagement.DAL;
using OfficeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeManagement.BLL
{
    public class AttendanceSetup_BLL
    {

        AttendanceSetup_DAL aAttendance_DAL = new AttendanceSetup_DAL();

        internal object InsertAttendance(tbl_EmplyoeeAttendance atbl_EmplyoeeAttendance)
        {
            return aAttendance_DAL.InsertAttendance(atbl_EmplyoeeAttendance);
        }

    }
}