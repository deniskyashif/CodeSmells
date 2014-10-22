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
    <h4>Categories</h4>
    <hr/>
    <ul ID="CategoriesList" runat="server">
      <% foreach(var cat in Categories) { %>
         <li><a href="#"><%=cat.CategoryName%>(<%=cat.PostsCount%>)</a></li>
      <% } %>
    </ul>
    <h4>All Codes</h4>
    <hr/>
    <% foreach(var post in Posts) { %>
    <h3><%=post.Title%></h3><%=post.Author.UserName%> posted this in <%=post.Category%>
    <pre class="prettyprint linenums"><%=HttpUtility.HtmlEncode(post.Body)%></pre>
    <% } %>
</asp:Content>
