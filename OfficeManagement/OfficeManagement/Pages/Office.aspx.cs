using OfficeManagement.BLL;
using OfficeManagement.BOL;
using OfficeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OfficeManagement.Pages
{
    public partial class Office : System.Web.UI.Page
    {

        OfficeManagementEntities _context = new OfficeManagementEntities();

        OfficeSetup_BLL aOfficeSetup_BLL = new OfficeSetup_BLL();
        List<tbl_OfficeInfo> lsttbl_OfficeInfo = new List<tbl_OfficeInfo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true)
            {
                GetAllOfficeDetails();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbl_OfficeInfo atbl_OfficeInfo = new tbl_OfficeInfo();
            atbl_OfficeInfo.Office_Name = txtOfficeName.Text;

            int count = (from emp in _context.tbl_OfficeInfo
                         where emp.Office_Name == atbl_OfficeInfo.Office_Name
                         select emp.Office_Name).Count();

            if (btnSave.Text == "Save")
            {
                if (count > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "E-ID already exists!";
                    return;
                }
                aOfficeSetup_BLL.SaveOffice(atbl_OfficeInfo);

                lblMessage.Visible = true;
                lblMessage.Text = "Data Save Successfully";
            }
            else
            {
                aOfficeSetup_BLL.UpdateOffice(atbl_OfficeInfo, Convert.ToInt16(hdnofficeID.Value));
                lblMessage.Visible = true;
                lblMessage.Text = "Data Update Successfully";
                btnCancel.Visible = false;
                btnSave.Text = "Save";

            }
            Clearform();
            GetAllOfficeDetails();
        }
        public void Clearform()
        {
            txtOfficeName.Text = "";
            btnSave.Text = "Save";
            btnCancel.Visible = false;
        }

        private void GetAllOfficeDetails()
        {
            List<Office_Viewer> lstOffice_Viewer = aOfficeSetup_BLL.GetAllOfficeDetails().ToList();

            if (lstOffice_Viewer.Count > 0)
            {
                dgvEmployee.DataSource = lstOffice_Viewer;
                dgvEmployee.DataBind();
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblOfficeID = (Label)dgvEmployee.Rows[grdrow.RowIndex].FindControl("lblOfficeID");
            hdnofficeID.Value = lblOfficeID.Text;

            lsttbl_OfficeInfo = aOfficeSetup_BLL.GetAllOfficeInfo(Convert.ToInt16(hdnofficeID.Value)).ToList();
            var result = lsttbl_OfficeInfo.First();

            if (lsttbl_OfficeInfo.Count > 0)
            {
                txtOfficeName.Text = result.Office_Name;


                btnSave.Text = "Update";
                btnCancel.Visible = true;
            }
            else
            {
                lblMessage.Text = "No Data Found";
            }
        }

        
    }
}