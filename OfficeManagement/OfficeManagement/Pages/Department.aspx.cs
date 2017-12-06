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
    public partial class Department : System.Web.UI.Page
    {

        OfficeManagementEntities _context = new OfficeManagementEntities();

        DepartmentSetup_BLL objDepartmentSetup_BLL = new DepartmentSetup_BLL();
        List<tbl_DepartmentInfo> lsttbl_DepartmentInfo = new List<tbl_DepartmentInfo>();


        OfficeSetup_BLL aOfficeSetup_BLL = new OfficeSetup_BLL();
        List<tbl_OfficeInfo> lsttbl_OfficeInfo = new List<tbl_OfficeInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true)
            {
                BindAllOffice();

                GetAllDepartmentDetails();
            }
        }
        private void GetAllDepartmentDetails()
        {
            List<Department_Viewer> lstDepartment_Viewer = objDepartmentSetup_BLL.GetAllDepartmentDetails().ToList();

            if (lstDepartment_Viewer.Count > 0)
            {
                dgvEmployee.DataSource = lstDepartment_Viewer;
                dgvEmployee.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbl_DepartmentInfo atbl_DepartmentInfo = new tbl_DepartmentInfo();
            atbl_DepartmentInfo.Department_Name = txtDepartmentName.Text;
            atbl_DepartmentInfo.Office_Id = Convert.ToInt16(ddlOfficeName.SelectedValue);



            int count = (from emp in _context.tbl_DepartmentInfo
                         where emp.Department_Name == atbl_DepartmentInfo.Department_Name
                         && emp.Office_Id == atbl_DepartmentInfo.Office_Id
                         select emp.Department_Name).Count();

            if (btnSave.Text == "Save")
            {
                if (count > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "E-ID already exists!";
                    return;
                }
                objDepartmentSetup_BLL.SaveDepartment(atbl_DepartmentInfo);

                lblMessage.Visible = true;
                lblMessage.Text = "Data Save Successfully";
            }
            else
            {
                objDepartmentSetup_BLL.UpdateDepartment(atbl_DepartmentInfo, Convert.ToInt16(hdndeptID.Value));
                lblMessage.Visible = true;
                lblMessage.Text = "Data Update Successfully";
                btnCancel.Visible = false;
                btnSave.Text = "Save";

            }
            Clearform();
            GetAllDepartmentDetails();
        }

        public void Clearform()
        {
            txtDepartmentName.Text = "";
            btnSave.Text = "Save";
            btnCancel.Visible = false;
        }

        private void BindAllOffice()
        {
            lsttbl_OfficeInfo = aOfficeSetup_BLL.GetAllOffice().ToList();

            ddlOfficeName.DataSource = lsttbl_OfficeInfo;
            ddlOfficeName.DataTextField = "Office_Name";
            ddlOfficeName.DataValueField = "Office_Id";
            ddlOfficeName.DataBind();
            ddlOfficeName.Items.Insert(0, "--select Office --");
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblDeptID = (Label)dgvEmployee.Rows[grdrow.RowIndex].FindControl("lblDeptID");
            hdndeptID.Value = lblDeptID.Text;

            lsttbl_DepartmentInfo = objDepartmentSetup_BLL.GetAllDepartmentInfo(Convert.ToInt16(hdndeptID.Value)).ToList();
            var result = lsttbl_DepartmentInfo.First();

            if (lsttbl_DepartmentInfo.Count > 0)
            {
                txtDepartmentName.Text = result.Department_Name;
                ddlOfficeName.SelectedValue = Convert.ToInt16(result.Office_Id).ToString();


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