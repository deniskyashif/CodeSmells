<%@ Page Title="Posts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetPosts.aspx.cs" Inherits="CodeSmells.Web.Posts.GetPosts" %>
<asp:Content ID="GetPostsContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="well">
            <div class="table table-striped table-hover">
                <asp:GridView runat="server" ID="GetAllPostsGridView" 
                ItemType="CodeSmells.Models.Post" 
                DataKeyNames="PostId"
                SelectMethod="GetAllPosts"
                AutoGenerateColumns="False">
                <Columns>
                     <asp:BoundField DataField="Title" HeaderText="Title"/>
                     <asp:BoundField DataField="Body" HeaderText="Code"/>
                     <asp:BoundField DataField="Category" HeaderText="Category"/>
                     <asp:BoundField DataField="Author.UserName" HeaderText="Author"/>
                     <asp:BoundField DataField="Rating" HeaderText="Rating"/>
                </Columns>
                </asp:GridView>
             </div>
        </div>
    </div>
    <%--<h2><%: this.Title %>.</h2>
    <ul ID="CategoriesList" runat="server">
      <% foreach(var item in this.collection)
         { %>
         <li><%= item %></li>
      <% } %>
    </ul>
    <h3><%: this.test.Title %></h3>
    <pre class="prettyprint linenums"><%: this.test.Body %></pre>--%>
</asp:Content>
