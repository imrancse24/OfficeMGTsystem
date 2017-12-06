using OfficeManagement.BOL;
using OfficeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeManagement.DAL
{
    public class EmployeeSetup_DAL
    {
        private OfficeManagementEntities _context = new OfficeManagementEntities();


        internal int SaveEmployee(tbl_EmployeeInfo atbl_EmployeeInfo)
        {
            _context.tbl_EmployeeInfo.Add(atbl_EmployeeInfo);
            _context.SaveChanges();
            return 1;
        }

        internal int UpdateEmployee(tbl_EmployeeInfo atbl_EmployeeInfo, string EID)
        {
            tbl_EmployeeInfo objtbl_EmployeeInfo = _context.tbl_EmployeeInfo.First(x => x.EID == EID);
            objtbl_EmployeeInfo.EmployeeName = atbl_EmployeeInfo.EmployeeName;
            objtbl_EmployeeInfo.Office_Id = atbl_EmployeeInfo.Office_Id;
            objtbl_EmployeeInfo.Department_Id = atbl_EmployeeInfo.Department_Id;
            _context.SaveChanges();
            return 1;
        }

        internal List<tbl_EmployeeInfo> GetAllEMployeeInfo()
        {
            try
            {
                var query = (from emp in _context.tbl_EmployeeInfo
                             select emp).OrderBy(x => x.EID).ToList();

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<tbl_EmployeeInfo> GetAllEMployeeInfo(string EID)
        {
            try
            {
                var query = (from emp in _context.tbl_EmployeeInfo
                             where emp.EID == EID
                             select emp).OrderBy(x => x.EID).ToList();

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public IEnumerable<Employee_Viewer> GetAllEmployeeDetails()
        {
            //using (var _context = new OfficeManagementEntities())
            //{
            return (from emp in _context.tbl_EmployeeInfo
                    join o in _context.tbl_OfficeInfo on emp.Office_Id equals o.Office_Id
                    join t in _context.tbl_DepartmentInfo on emp.Department_Id equals t.Department_Id

                    select new Employee_Viewer
                    {
                        EID = emp.EID,
                        EmployeeName = emp.EmployeeName,
                        Office_Id = (int)emp.Office_Id,
                        Office_Name = o.Office_Name,
                        Department_Id = (int)emp.Department_Id,
                        Department_Name = t.Department_Name

                    }).ToList();
            //}
        }




        public IEnumerable<Employee_Viewer> GetAllEmployeeDetailsByOfficeId(int Office_Id, TimeSpan inTime, TimeSpan outTime)
        {
            //using (var _context = new OfficeManagementEntities())
            //{
            return (from emp in _context.tbl_EmployeeInfo
                    join o in _context.tbl_OfficeInfo on emp.Office_Id equals o.Office_Id
                    join t in _context.tbl_DepartmentInfo on emp.Department_Id equals t.Department_Id

                    where emp.Office_Id == Office_Id

                    select new Employee_Viewer
                    {
                        EID = emp.EID,
                        EmployeeName = emp.EmployeeName,
                        Office_Id = (int)emp.Office_Id,
                        Office_Name = o.Office_Name,
                        Department_Id = (int)emp.Department_Id,
                        Department_Name = t.Department_Name,
                        In_Time = inTime,
                        Out_Time = outTime
                    }).ToList();
            //}
        }

        public IEnumerable<Employee_Viewer> GetAllEmployeeDetailsByDeptId(int officeId, int deptId)
        {
            //using (var _context = new OfficeManagementEntities())
            //{
            return (from emp in _context.tbl_EmployeeInfo
                    join o in _context.tbl_OfficeInfo on emp.Office_Id equals o.Office_Id
                    join t in _context.tbl_DepartmentInfo on emp.Department_Id equals t.Department_Id

                    where emp.Office_Id == officeId && emp.Department_Id == deptId

                    select new Employee_Viewer
                    {
                        EID = emp.EID,
                        EmployeeName = emp.EmployeeName,
                        Office_Id = (int)emp.Office_Id,
                        Office_Name = o.Office_Name,
                        Department_Id = (int)emp.Department_Id,
                        Department_Name = t.Department_Name

                    }).ToList();
            //}
        }

    }
}