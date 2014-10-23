﻿<%@ Page Title="Posts" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GetPosts.aspx.cs" Inherits="CodeSmells.Web.Posts.GetPosts" %>
<asp:Content ID="GetPostsContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="well">
            <div class="table table-striped">
                <asp:GridView runat="server" ID="GetAllPostsGridView" 
                ItemType="CodeSmells.Models.Post" 
                DataKeyNames="PostId"
                SelectMethod="GetAllPosts"
                AutoGenerateColumns="False">
                
                <Columns>
                     <asp:TemplateField HeaderText="Title">
                         <ItemTemplate>
                             <asp:HyperLink ID="TextBox1" runat="server" NavigateUrl='<%# "~/Posts/PostDetails.aspx?id="+Eval("PostId") %>' Text='<%# Bind("Title") %>'></asp:HyperLink>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Code">
                         <ItemTemplate>
                             <pre class="prettyprint linenums">
                                 <asp:Label ID="CodeLabel" runat="server" CssClass="prettyprint linenums" Text='<%# Bind("Body") %>'></asp:Label>
                            </pre>
                             
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField DataField="Category" HeaderText="Category"/>
                     <asp:TemplateField HeaderText="Author">
                         <ItemTemplate>
                             <asp:HyperLink ID="TextBox1" runat="server" NavigateUrl='<%# "~/Public/ProfileDetails.aspx?id="+Eval("AuthorId") %>' Text='<%# Bind("Author.UserName") %>'></asp:HyperLink>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField DataField="Rating" HeaderText="Rating"/>
                </Columns>
                </asp:GridView>
             </div>
        </div>
    </div>
    <%--<h2><%: this.Title %>.</h2>

    <h2><%: this.Title %>.</h2>
    <h4>Categories</h4>
    <hr/>

    <ul ID="CategoriesList" runat="server">
      <% foreach(var cat in Categories) { %>
         <li><a href="#"><%=cat.CategoryName%>(<%=cat.PostsCount%>)</a></li>
      <% } %>
    </ul>

    <h3><%: this.test.Title %></h3>
    <pre class="prettyprint linenums"><%: this.test.Body %></pre>

    <h4>All Codes</h4>
    <hr/>
    <% foreach(var post in Posts) { %>
    <h3><%=post.Title%></h3><%=post.Author.UserName%> posted this in <%=post.Category%>
    <pre class="prettyprint linenums"><%=HttpUtility.HtmlEncode(post.Body)%></pre>
    <% } %>--%>
</asp:Content>
