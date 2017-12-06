using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using OfficeManagement.Model;
using OfficeManagement.BLL;
using OfficeManagement.BOL;

namespace OfficeManagement.Pages
{
    public partial class Attendance : System.Web.UI.Page
    {
        OfficeManagementEntities context = new OfficeManagementEntities();
        EmployeeSetup_BLL aEmployeeSetup_BLL = new EmployeeSetup_BLL();
        List<tbl_EmployeeInfo> lsttbl_EmployeeInfo = new List<tbl_EmployeeInfo>();

        OfficeSetup_BLL aOfficeSetup_BLL = new OfficeSetup_BLL();
        List<tbl_OfficeInfo> lsttbl_OfficeInfo = new List<tbl_OfficeInfo>();

        DepartmentSetup_BLL aDepartmentSetup_BLL = new DepartmentSetup_BLL();
        List<tbl_DepartmentInfo> lsttbl_DepartmentInfo = new List<tbl_DepartmentInfo>();

        AttendanceSetup_BLL aAttendance_BLL = new AttendanceSetup_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack == true)
            {
                BindAllOffice();

                // GetAllEmployeeDetails();
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            if (ddlOfficeName.SelectedItem.Text != "--select--" && ddlDepartmentName.SelectedItem.Text != "--select--")
            {
                List<Employee_Viewer> lstEmployee_Viewer = aEmployeeSetup_BLL.GetAllEmployeeDetailsByDeptId(Convert.ToInt16(ddlOfficeName.SelectedValue), Convert.ToInt16(ddlDepartmentName.SelectedValue)).ToList();

                if (lstEmployee_Viewer.Count > 0)
                {
                    dgvEmployee.DataSource = lstEmployee_Viewer;
                    dgvEmployee.DataBind();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = " No Data Found";
                    dgvEmployee.DataSource = null;
                    dgvEmployee.DataBind();
                }
            }
            else if (ddlOfficeName.SelectedItem.Text != "--select--")
            {
                List<Employee_Viewer> lstEmployee_Viewer = aEmployeeSetup_BLL.GetAllEmployeeDetailsByOfficeId(Convert.ToInt16(ddlOfficeName.SelectedValue), TimeSpan.Parse(txtIntime.Text), TimeSpan.Parse(txtOuttime.Text)).ToList();

                if (lstEmployee_Viewer.Count > 0)
                {
                    dgvEmployee.DataSource = lstEmployee_Viewer;
                    dgvEmployee.DataBind();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = " No Data Found";
                    dgvEmployee.DataSource = null;
                    dgvEmployee.DataBind();
                }
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = " Select Office/Department for process!";
            }
        }

        private void BindAllOffice()
        {
            lsttbl_OfficeInfo = aOfficeSetup_BLL.GetAllOffice().ToList();

            ddlOfficeName.DataSource = lsttbl_OfficeInfo;
            ddlOfficeName.DataTextField = "Office_Name";
            ddlOfficeName.DataValueField = "Office_Id";
            ddlOfficeName.DataBind();
            ddlOfficeName.Items.Insert(0, "--select--");
        }

        private void BindDepartmentName()
        {
            lsttbl_DepartmentInfo = aDepartmentSetup_BLL.GetAllDepartment(Convert.ToInt16(ddlOfficeName.SelectedValue)).ToList();

            ddlDepartmentName.DataSource = lsttbl_DepartmentInfo;
            ddlDepartmentName.DataTextField = "Department_Name";
            ddlDepartmentName.DataValueField = "Department_Id";
            ddlDepartmentName.DataBind();
            ddlDepartmentName.Items.Insert(0, "--select--");
        }

        protected void ddlOfficeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDepartmentName();
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

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.Rows.Count == 0)
            {
                lblMessage.Text = "No employee in the list!";
            }

            List<tbl_EmplyoeeAttendance> lsttbl_EmplyoeeAttendance = new List<tbl_EmplyoeeAttendance>();
            tbl_EmplyoeeAttendance atbl_EmplyoeeAttendance = new tbl_EmplyoeeAttendance();

            foreach (GridViewRow gvRow in dgvEmployee.Rows)
            {
                Label lblEid = ((Label)gvRow.FindControl("lblEid"));
                atbl_EmplyoeeAttendance.EID = lblEid.Text;

                TextBox txtbxIntime = ((TextBox)gvRow.FindControl("txtbxIntime"));
                atbl_EmplyoeeAttendance.In_Time = TimeSpan.Parse(txtbxIntime.Text);

                TextBox txtbxOuttime = ((TextBox)gvRow.FindControl("txtbxOuttime"));
                atbl_EmplyoeeAttendance.Out_Time = TimeSpan.Parse(txtbxOuttime.Text);

                atbl_EmplyoeeAttendance.Attendance_Date = Convert.ToDateTime(txtAttendanceDate.Text);

                //TimeSpan intime = TimeSpan.Parse(txtIntime.Text);
                //atbl_EmplyoeeAttendance.In_time = TimeSpan.Parse(txtIntime.Text);
                //atbl_EmplyoeeAttendance.Out_Time = TimeSpan.Parse(txtOuttime.Text);
                atbl_EmplyoeeAttendance.Edit_Date = DateTime.Now;

                aAttendance_BLL.InsertAttendance(atbl_EmplyoeeAttendance);
            }

            //lsttbl_EmplyoeeAttendance.Add(atbl_EmplyoeeAttendance);

            lblMessage.Visible = true;
            lblMessage.Text = "Data Save Successfully";
        }




    }
}