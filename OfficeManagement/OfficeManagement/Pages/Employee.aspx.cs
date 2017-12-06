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
    public partial class Employee : System.Web.UI.Page
    {
        OfficeManagementEntities context = new OfficeManagementEntities();
        EmployeeSetup_BLL aEmployeeSetup_BLL = new EmployeeSetup_BLL();
        List<tbl_EmployeeInfo> lsttbl_EmployeeInfo = new List<tbl_EmployeeInfo>();

        OfficeSetup_BLL aOfficeSetup_BLL = new OfficeSetup_BLL();
        List<tbl_OfficeInfo> lsttbl_OfficeInfo = new List<tbl_OfficeInfo>();

        DepartmentSetup_BLL aDepartmentSetup_BLL = new DepartmentSetup_BLL();
        List<tbl_DepartmentInfo> lsttbl_DepartmentInfo = new List<tbl_DepartmentInfo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true)
            {
                lblMessage.Visible = false;
                GetAllEmployeeDetails();
                BindAllOffice();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tbl_EmployeeInfo atbl_EmployeeInfo = new tbl_EmployeeInfo();
            atbl_EmployeeInfo.EID = txtEID.Text;
            atbl_EmployeeInfo.EmployeeName = txtEmployeeName.Text;
            atbl_EmployeeInfo.Office_Id = Convert.ToInt16(ddlOfficeName.SelectedValue);
            atbl_EmployeeInfo.Department_Id = Convert.ToInt16(ddlDepartmentName.SelectedValue);

            int count = (from emp in context.tbl_EmployeeInfo
                         where emp.EID == atbl_EmployeeInfo.EID
                         select emp.EID).Count();

            if (btnSave.Text == "Save")
            {
                if (count > 0)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "E-ID already exists!";
                    return;
                }
                aEmployeeSetup_BLL.SaveEmployee(atbl_EmployeeInfo);

                //context.tbl_EmployeeInfo.Add(atbl_EmployeeInfo); //Add object into DBset      
                //context.SaveChanges(); // call SaveChanges method to save into database

                lblMessage.Visible = true;
                lblMessage.Text = "Data Save Successfully";
            }
            else
            {
                aEmployeeSetup_BLL.UpdateEmployee(atbl_EmployeeInfo, txtEID.Text);
                lblMessage.Visible = true;
                lblMessage.Text = "Data Update Successfully";
                btnCancel.Visible = false;
                //btnSave.Text = "Save";

            }
            Clearform();
            GetAllEmployeeDetails();
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

        private void BindDepartmentName()
        {
            lsttbl_DepartmentInfo = aDepartmentSetup_BLL.GetAllDepartment(Convert.ToInt16(ddlOfficeName.SelectedValue)).ToList();

            ddlDepartmentName.DataSource = lsttbl_DepartmentInfo;
            ddlDepartmentName.DataTextField = "Department_Name";
            ddlDepartmentName.DataValueField = "Department_Id";
            ddlDepartmentName.DataBind();
            ddlOfficeName.Items.Insert(0, "--select Department --");
        }

        private void GetAllEmployee()
        {
            lsttbl_EmployeeInfo = aEmployeeSetup_BLL.GetAllEMployeeInfo().ToList();
            //var result=lsttbl_EmployeeInfo.First();

            if (lsttbl_EmployeeInfo.Count > 0)
            {
                dgvEmployee.DataSource = lsttbl_EmployeeInfo;
                dgvEmployee.DataBind();
            }
        }

        private void GetAllEmployeeDetails()
        {
            List<Employee_Viewer> lstEmployee_Viewer = aEmployeeSetup_BLL.GetAllEmployeeDetails().ToList();

            if (lstEmployee_Viewer.Count > 0)
            {
                dgvEmployee.DataSource = lstEmployee_Viewer;
                dgvEmployee.DataBind();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clearform();
        }

        public void Clearform()
        {
            txtEID.Text = "";
            txtEmployeeName.Text = "";
            btnSave.Text = "Save";
            btnCancel.Visible = false;
            txtEID.Enabled = true;
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblEid = (Label)dgvEmployee.Rows[grdrow.RowIndex].FindControl("lblEid");

            lsttbl_EmployeeInfo = aEmployeeSetup_BLL.GetAllEMployeeInfo(lblEid.Text).ToList();
            var result = lsttbl_EmployeeInfo.First();

            if (lsttbl_EmployeeInfo.Count > 0)
            {
                txtEID.Text = lblEid.Text;
                txtEID.Enabled = false;
                txtEmployeeName.Text = result.EmployeeName;
                ddlOfficeName.SelectedValue = Convert.ToInt16(result.Office_Id).ToString();


                btnSave.Text = "Update";
                btnCancel.Visible = true;
            }
            else
            {
                lblMessage.Text = "No Data Found";
                txtEID.Enabled = true;
            }
        }

        protected void ddlOfficeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartmentName();
        }


    }
}