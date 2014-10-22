<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostDetails.aspx.cs" Inherits="CodeSmells.Web.Posts.PostDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Post Details</h3>
    <asp:DetailsView 
        ID="PostDetailsView" 
        runat="server" 
        ItemType="CodeSmells.Models.Post" 
        DataKeyNames="PostId"
        SelectMethod="GetPostById"
        AutoGenerateRows="false" 
        class="table table-striped table-hover">
        <Fields>
            <asp:BoundField HeaderText="Category" DataField="Category"/>            
            <asp:BoundField HeaderText="Title" DataField="Title"/>
            <asp:BoundField HeaderText="Author" DataField="Author.UserName"/>
            <asp:BoundField HeaderText="Code" DataField="Body"/>
            <asp:BoundField HeaderText="Rating" DataField="Rating"/>
        </Fields>
    </asp:DetailsView>
    <h3>Comments</h3>
    <asp:Repeater runat="server" ID="CommentsRepeater" ItemType="CodeSmells.Models.Comment">
        <ItemTemplate>
            <div class="container">
                <div class="well">
                    <h4><%#: Item.Author.UserName %> says:</h4>
                    <p>
                        <%#: Item.Body %>
                    </p>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
