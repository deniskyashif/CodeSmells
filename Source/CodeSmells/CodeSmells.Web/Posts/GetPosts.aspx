<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetPosts.aspx.cs" Inherits="CodeSmells.Web.Posts.GetPosts" %>
<asp:Content ID="GetPostsContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--<asp:GridView runat="server" ID="PostsGridView" 
        ItemType="CodeSmells.Models.Post" 
        DataKeyNames="PostId"
        SelectMethod="GetAllPosts"
        AutoGenerateColumns="True">
        <Columns>
             <asp:BoundField DataField="Title"/>
             <asp:BoundField DataField="Body"/>
        </Columns>
    </asp:GridView>-->
    <ul ID="CategoriesList" runat="server">
      <% foreach(var item in collection) { %>
         <li><%=item%></li>
      <% } %>
    </ul>
</asp:Content>
