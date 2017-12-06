using OfficeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeManagement.DAL
{
    public class AttendanceSetup_DAL
    {

        private OfficeManagementEntities _context = new OfficeManagementEntities();

        internal object InsertAttendance(tbl_EmplyoeeAttendance atbl_EmplyoeeAttendance)
        {
            //foreach (tbl_EmplyoeeAttendance atten in lsttbl_EmplyoeeAttendance)
            //{
            _context.tbl_EmplyoeeAttendance.Add(atbl_EmplyoeeAttendance);
            _context.SaveChanges();
            //}

            return 1;
        }

    }
}