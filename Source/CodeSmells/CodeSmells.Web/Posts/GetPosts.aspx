<%@ Page Title="Posts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetPosts.aspx.cs" Inherits="CodeSmells.Web.Posts.GetPosts" %>
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
    <h2><%: this.Title %>.</h2>
    <ul ID="CategoriesList" runat="server">
      <% foreach(var item in collection) { %>
         <li><%=item%></li>
      <% } %>
    </ul>
    <h3><%: this.test.Title %></h3>
    <pre class="prettyprint linenums"><%: this.test.Body %></pre>
</asp:Content>
