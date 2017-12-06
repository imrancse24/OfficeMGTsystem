﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="OfficeManagement.Pages.Department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/bootstrap.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/npm.js"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <asp:Label runat="server" ID="lblMessage" Visible="false"></asp:Label>
    <br />
    <div class="col-md-6">

                <asp:Label runat="server">Office</asp:Label>
        <asp:DropDownList runat="server" ID="ddlOfficeName" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
        <br />

        <asp:Label runat="server">Department Name</asp:Label>
        <asp:TextBox runat="server" ID="txtDepartmentName" CssClass="form-control"></asp:TextBox><br />

        <asp:HiddenField ID="hdndeptID" runat="server" />

        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-info" Text="Save" OnClick="btnSave_Click" />
        <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-default" Text="Cancel" Visible="false" />

   </div>

    <div class="col-md-6" style="margin-top:8px">
        <asp:GridView ID="dgvEmployee" runat="server" BackColor="White" BorderColor="#E7E7FF"
            BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Names="Calibri" Font-Size="Larger"
            GridLines="Horizontal" AutoGenerateColumns="false">

            <Columns>
                <asp:TemplateField HeaderText="Sl." HeaderStyle-Width="10%">
                    <ItemTemplate><%# Container.DataItemIndex +1 %></ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Department_Id" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDeptID" runat="server" Text='<%# Eval("Department_Id") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="" HorizontalAlign="Center" />
                                <ItemStyle CssClass="" HorizontalAlign="Center" />
                            </asp:TemplateField>

                <asp:BoundField DataField="Office_Name" HeaderText="Office" HeaderStyle-Width="30%" ItemStyle-HorizontalAlign="Left"/>

                <asp:BoundField DataField="Department_Name" HeaderText="Department" HeaderStyle-Width="30%" ItemStyle-HorizontalAlign="Left"/>

                <asp:TemplateField ShowHeader="False" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" Text="View" OnClick="btnView_Click" ></asp:LinkButton>
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
