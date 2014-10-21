<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="CodeSmells.Web.Administration.EditUser" %>

<asp:Content ID="EditUserContent" ContentPlaceHolderID="MainContent" runat="server">
    
     <asp:LinkButton ID="LinkButtonReturn" runat="server" CssClass="btn btn-default" 
        Text="Back" OnClick="LinkButtonReturn_Click" />

    <h2>Edit User</h2>

    <div class="form-group">
        <asp:Label Text="UserName" runat="server" />
        <asp:TextBox ID="TbUserName" runat="server" CssClass="form-control"/>
    </div>

    <div class="form-group">
        <asp:Label Text="Email" runat="server" />
        <asp:TextBox ID="TbEmail" runat="server" TextMode="Email" CssClass="form-control" />
    </div>
    
    <asp:LinkButton ID="LinkButtonSaveUser" runat="server" CssClass="btn btn-default"
        Text="Save Changes" OnClick="LinkButtonSaveUser_Click" />
    <br /><br />
    <div class="btn-group">
    <asp:Button ID="ButtonBAN" runat="server" Text="BAN User" CssClass="btn btn-default" 
        OnClientClick="return confirm('Do you want to Ban user ?');"
        OnClick="ButtonBAN_Click" />
    <asp:Button ID="ButtonAdmin" runat="server" Text="Add Admin" CssClass="btn btn-default" 
        OnClientClick="return confirm('Do you want to create admin?');"
        OnClick="ButtonAdmin_Click" />
        </div>
</asp:Content>
