using OfficeManagement.BOL;
using OfficeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeManagement.DAL
{
    public class DepartmentSetup_DAL
    {
        private OfficeManagementEntities _context = new OfficeManagementEntities();

        internal int SaveDepartment(tbl_DepartmentInfo atbl_DepartmentInfo)
        {
            _context.tbl_DepartmentInfo.Add(atbl_DepartmentInfo);
            _context.SaveChanges();
            return 1;
        }

        internal int UpdateDepartment(tbl_DepartmentInfo atbl_DepartmentInfo, int Department_Id)
        {
            tbl_DepartmentInfo objtbl_DepartmentInfo = _context.tbl_DepartmentInfo.First(x => x.Department_Id == Department_Id);
            objtbl_DepartmentInfo.Department_Name = atbl_DepartmentInfo.Department_Name;
            objtbl_DepartmentInfo.Office_Id = atbl_DepartmentInfo.Office_Id;
            _context.SaveChanges();
            return 1;
        }

        internal List<tbl_DepartmentInfo> GetAllDepartment(int OfficeId)
        {
            try
            {
                var query = (from dept in _context.tbl_DepartmentInfo
                             where dept.Office_Id == OfficeId
                             select dept).OrderBy(x => x.Department_Name).ToList();

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        internal List<tbl_DepartmentInfo> GetAllDepartmentInfo(int Department_Id)
        {
            try
            {
                var query = (from emp in _context.tbl_DepartmentInfo
                             where emp.Department_Id == Department_Id
                             select emp).OrderBy(x => x.Department_Id).ToList();

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public IEnumerable<Department_Viewer> GetAllDepartmentDetails()
        {
            //using (var _context = new OfficeManagementEntities())
            //{
            return (from emp in _context.tbl_DepartmentInfo
                    join o in _context.tbl_OfficeInfo on emp.Office_Id equals o.Office_Id

                    select new Department_Viewer
                    {
                        Department_Id = emp.Department_Id,
                        Department_Name = emp.Department_Name,
                        Office_Id = (int)emp.Office_Id,
                        Office_Name = o.Office_Name,
                    }).ToList();
            //}
        }
    }
}