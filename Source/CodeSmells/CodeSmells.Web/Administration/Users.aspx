<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPageAdmins.master" AutoEventWireup="true"
    CodeBehind="Users.aspx.cs" Inherits="CodeSmells.Web.Administration.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderAdminArea" runat="server">
    
    <asp:GridView CssClass="table table-striped table-bordered" ID="GridViewUsers" runat="server"
        AutoGenerateColumns="False" DataKeyNames="Id"
        PageSize="2" AllowPaging="true" AllowSorting="true"
        ItemType="CodeSmells.Models.User"
        SelectMethod="GridViewUsers_GetData">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:HyperLinkField Text="Edit" HeaderText="Action"
                DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="EditUser.aspx?userId={0}" />
        </Columns>
    </asp:GridView>
</asp:Content>
