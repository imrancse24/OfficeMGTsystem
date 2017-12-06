<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="OfficeManagement.Pages.Attendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <script src="../js/bootstrap.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/npm.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />

    <br />
    <asp:Label runat="server" ID="lblMessage" Visible="false"></asp:Label>
    <br />
    <div class="col-md-6">

        <asp:Label runat="server">Office</asp:Label>
        <asp:DropDownList runat="server" ID="ddlOfficeName" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlOfficeName_SelectedIndexChanged"></asp:DropDownList>
        <asp:HiddenField runat="server" ID="hdnOfficeId" />
        <br />

        <asp:Label runat="server">Department</asp:Label>
        <asp:DropDownList runat="server" ID="ddlDepartmentName" CssClass="form-control"></asp:DropDownList>
        <br />

        <asp:Label runat="server">Attendance Date</asp:Label>
        <asp:TextBox runat="server" ID="txtAttendanceDate" CssClass="form-control" Width="50%" ></asp:TextBox><br />

         <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAttendanceDate"
            Display="Dynamic" ErrorMessage="Select Attendance Date" ForeColor="Red" SetFocusOnError="True" Font-Size="11px"
            ValidationGroup="group1"></asp:RequiredFieldValidator>--%>

        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtAttendanceDate"
            PopupButtonID="Image_AT" Format="MM/dd/yyyy" CssClass="ajax__calendar" Enabled="True" />

        <asp:Label runat="server">In Time</asp:Label>
        <asp:TextBox runat="server" ID="txtIntime" CssClass="form-control" Width="50%"></asp:TextBox><br />

        <asp:Label runat="server">Out Time</asp:Label>
        <asp:TextBox runat="server" ID="txtOuttime" CssClass="form-control" Width="50%"></asp:TextBox><br />

        <asp:Label runat="server">Remarks</asp:Label>
        <asp:TextBox runat="server" ID="txtRemarks" CssClass="form-control" Width="25%"></asp:TextBox><br />

        <asp:Button runat="server" ID="btnProcess" CssClass="btn btn-primary" Text="Process" OnClick="btnProcess_Click" />&nbsp&nbsp&nbsp

        <asp:Button runat="server" ID="btnConfirm" CssClass="btn btn-info" Text="Confirm" ValidationGroup="group1" OnClick="btnConfirm_Click" />

    </div>

    <div class="col-md-6" style="margin-top: 8px">
        <asp:GridView ID="dgvEmployee" runat="server" BackColor="White" BorderColor="#E7E7FF"
            BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Names="Calibri" Font-Size="Larger"
            GridLines="Horizontal" AutoGenerateColumns="false">

            <Columns>
                <asp:TemplateField HeaderText="Sl." HeaderStyle-Width="10%">
                    <ItemTemplate><%# Container.DataItemIndex +1 %></ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="EID" HeaderStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Label ID="lblEid" runat="server" Text='<%# Eval("EID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" HeaderStyle-Width="20%" />

                <asp:BoundField DataField="Office_Name" HeaderText="Office" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Left" />

                <asp:BoundField DataField="Department_Name" HeaderText="Department" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Left" />

                <asp:TemplateField HeaderText="In Time">
                    <ItemTemplate>
                        <asp:TextBox ID="txtbxIntime" runat="server" Width="100%" ToolTip="Enter Time" Text='<%# Bind("In_Time") %>' Style="text-align: center"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                </asp:TemplateField>

                  <asp:TemplateField HeaderText="Out Time">
                    <ItemTemplate>
                        <asp:TextBox ID="txtbxOuttime" runat="server" Width="100%" ToolTip="Enter Time" Text='<%# Bind("Out_Time") %>' Style="text-align: center"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                </asp:TemplateField>

                <asp:TemplateField ShowHeader="False" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" Text="View"></asp:LinkButton>
                        <%--<asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" OnClientClick="return isDelete();" Text="Delete"></asp:LinkButton>--%>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>


            <AlternatingRowStyle BackColor="#F7F7F7" />

            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />

            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />

            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />

            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />

            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />

            <SortedAscendingCellStyle BackColor="#F4F4FD" />

            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />


            <SortedDescendingCellStyle BackColor="#D8D8F0" />

            <SortedDescendingHeaderStyle BackColor="#3E3277" />

        </asp:GridView>
    </div>

</asp:Content>
