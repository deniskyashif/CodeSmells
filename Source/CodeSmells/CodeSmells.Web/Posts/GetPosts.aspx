<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetPosts.aspx.cs" Inherits="CodeSmells.Web.Posts.GetPosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="GetAllPostsGridView" 
        ItemType="CodeSmells.Models.Post" 
        DataKeyNames="PostId"
        SelectMethod="GetAllPosts"
        AutoGenerateColumns="True">
        <Columns>
             <asp:BoundField DataField="Title"/>
             <asp:BoundField DataField="Body"/>
        </Columns>
    </asp:GridView>
</asp:Content>
