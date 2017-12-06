using OfficeManagement.BOL;
using OfficeManagement.DAL;
using OfficeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeManagement.BLL
{
    public class EmployeeSetup_BLL
    {
        EmployeeSetup_DAL objEmployeeSetup_DAL = new EmployeeSetup_DAL();

        internal int SaveEmployee(tbl_EmployeeInfo atbl_EmployeeInfo)
        {
            return objEmployeeSetup_DAL.SaveEmployee(atbl_EmployeeInfo);
        }

        internal int UpdateEmployee(tbl_EmployeeInfo atbl_EmployeeInfo, string EID)
        {
            return objEmployeeSetup_DAL.UpdateEmployee(atbl_EmployeeInfo, EID);
        }

        internal List<tbl_EmployeeInfo> GetAllEMployeeInfo()
        {
            return objEmployeeSetup_DAL.GetAllEMployeeInfo();
        }

        public IEnumerable<Employee_Viewer> GetAllEmployeeDetails()
        {
            return objEmployeeSetup_DAL.GetAllEmployeeDetails();
        }

        internal List<tbl_EmployeeInfo> GetAllEMployeeInfo(string EID)
        {
            return objEmployeeSetup_DAL.GetAllEMployeeInfo(EID);
        }
        public IEnumerable<Employee_Viewer> GetAllEmployeeDetailsByOfficeId(int Office_Id, TimeSpan inTime, TimeSpan outTime)
        {
            return objEmployeeSetup_DAL.GetAllEmployeeDetailsByOfficeId(Office_Id, inTime, outTime);
        }
        public IEnumerable<Employee_Viewer> GetAllEmployeeDetailsByDeptId(int Office_Id, int Dept_Id)
        {
            return objEmployeeSetup_DAL.GetAllEmployeeDetailsByDeptId(Office_Id, Dept_Id);
        }

    }
}