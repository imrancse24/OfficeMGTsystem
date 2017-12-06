using OfficeManagement.BOL;
using OfficeManagement.DAL;
using OfficeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeManagement.BLL
{
    public class OfficeSetup_BLL
    {
        OfficeSetup_DAL aOfficeSetup_DAL = new OfficeSetup_DAL();

        internal int SaveOffice(tbl_OfficeInfo atbl_OfficeInfo)
        {
            return aOfficeSetup_DAL.SaveOffice(atbl_OfficeInfo);
        }

        internal int UpdateOffice(tbl_OfficeInfo atbl_OfficeInfo, int Office_Id)
        {
            return aOfficeSetup_DAL.UpdateOffice(atbl_OfficeInfo, Office_Id);
        }

        internal List<tbl_OfficeInfo> GetAllOfficeInfo(int Office_Id)
        {
            return aOfficeSetup_DAL.GetAllOfficeInfo(Office_Id);
        }

        internal List<tbl_OfficeInfo> GetAllOffice()
        {
            return aOfficeSetup_DAL.GetAllOffice();
        }

        public IEnumerable<Office_Viewer> GetAllOfficeDetails()
        {
            return aOfficeSetup_DAL.GetAllOfficeDetails();
        }
    }
}