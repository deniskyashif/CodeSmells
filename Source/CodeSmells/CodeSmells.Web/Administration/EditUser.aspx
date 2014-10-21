<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/MasterPageAdmins.master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="CodeSmells.Web.Administration.EditUser" %>

<asp:Content ID="EditUserContent" ContentPlaceHolderID="ContentPlaceHolderAdminArea" runat="server">
    
    <h2>Edit User</h2>

    <div class="form-group">
        <asp:Label Text="UserName" runat="server" />
        <asp:TextBox ID="TbUserName" runat="server" CssClass="form-control"/>
    </div>

    <div class="form-group">
        <asp:Label Text="Email" runat="server" />
        <asp:TextBox ID="TbEmail" runat="server" TextMode="Email" CssClass="form-control" />
    </div>
    
    <div class="btn-group">
        <asp:Button ID="BtnBanUser" runat="server" Text="Ban" CssClass="btn btn-default" 
                    OnClientClick=" return confirm('Do you want to Ban user ?'); "
                    OnClick="BtnBanUser_Click" />
        <asp:Button ID="BtnToggleAdminRole" runat="server" Text="Assign Admin Rights" CssClass="btn btn-default" 
                    OnClientClick=" return confirm('Do you want to assign admin rights to user?'); "
                    OnClick="BtnToggleAdminRole_Click" />
    </div>
    <br />
    <asp:LinkButton ID="LinkBtnSaveUser" runat="server" CssClass="btn btn-default"
                    Text="Save Changes" OnClick="LinkBtnSaveUser_Click" />
    <br />
    
</asp:Content>