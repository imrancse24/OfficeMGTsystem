using OfficeManagement.BOL;
using OfficeManagement.DAL;
using OfficeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeManagement.BLL
{
    public class DepartmentSetup_BLL
    {
        DepartmentSetup_DAL aDepartmentSetup_DAL = new DepartmentSetup_DAL();

        internal int SaveDepartment(tbl_DepartmentInfo atbl_DepartmentInfo)
        {
            return aDepartmentSetup_DAL.SaveDepartment(atbl_DepartmentInfo);
        }

        internal List<tbl_DepartmentInfo> GetAllDepartment(int OfficeId)
        {
            return aDepartmentSetup_DAL.GetAllDepartment(OfficeId);
        }

        internal int UpdateDepartment(tbl_DepartmentInfo atbl_DepartmentInfo, int Department_Id)
        {
            return aDepartmentSetup_DAL.UpdateDepartment(atbl_DepartmentInfo, Department_Id);
        }

        internal List<tbl_DepartmentInfo> GetAllDepartmentInfo(int Department_Id)
        {
            return aDepartmentSetup_DAL.GetAllDepartmentInfo(Department_Id);
        }

        public IEnumerable<Department_Viewer> GetAllDepartmentDetails()
        {
            return aDepartmentSetup_DAL.GetAllDepartmentDetails();
        }
    }
}