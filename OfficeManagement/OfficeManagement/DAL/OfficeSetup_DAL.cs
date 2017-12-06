using OfficeManagement.BOL;
using OfficeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeManagement.DAL
{
    public class OfficeSetup_DAL
    {
        private OfficeManagementEntities _context = new OfficeManagementEntities();

        internal int SaveOffice(tbl_OfficeInfo atbl_OfficeInfo)
        {
            _context.tbl_OfficeInfo.Add(atbl_OfficeInfo);
            _context.SaveChanges();
            return 1;
        }

        internal int UpdateOffice(tbl_OfficeInfo atbl_OfficeInfo, int Office_Id)
        {
            tbl_OfficeInfo objtbl_OfficeInfo = _context.tbl_OfficeInfo.First(x => x.Office_Id == Office_Id);
            objtbl_OfficeInfo.Office_Name = atbl_OfficeInfo.Office_Name;
            _context.SaveChanges();
            return 1;
        }


        internal List<tbl_OfficeInfo> GetAllOffice()
        {
            try
            {
                var query = (from off in _context.tbl_OfficeInfo
                             select off).OrderBy(x => x.Office_Id).ToList();

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<tbl_OfficeInfo> GetAllOfficeInfo(int Office_Id)
        {
            try
            {
                var query = (from emp in _context.tbl_OfficeInfo
                             where emp.Office_Id == Office_Id
                             select emp).OrderBy(x => x.Office_Id).ToList();

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public IEnumerable<Office_Viewer> GetAllOfficeDetails()
        {
            //using (var _context = new OfficeManagementEntities())
            //{
            return (from emp in _context.tbl_OfficeInfo                    

                    select new Office_Viewer
                    {
                        Office_Id = emp.Office_Id,
                        Office_Name = emp.Office_Name     
                    }).ToList();
            //}
        }

    }
}