<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePost.aspx.cs" Inherits="CodeSmells.Web.Posts.CreatePost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create Post</h2>
    <asp:FormView runat="server" ID="CreatePostFormView" 
        ItemType="CodeSmells.Models.Post" 
        DataKeyNames="PostId"
        InsertMethod="AddPost"
        OnItemInserted="AddPostForm_ItemInserted" 
        DefaultMode="Insert">
        <InsertItemTemplate>
            <asp:Label runat="server" ID="TitleLable" Text="Title"></asp:Label>
            <asp:TextBox runat="server" ID="TitleTextBox" Text="<%#: BindItem.Title %>"></asp:TextBox>
            <br />
            <br/>
            <asp:Label runat="server" ID="BodyLabel" Text="Code"></asp:Label>
            <asp:TextBox runat="server" ID="BodyTextBox" TextMode="MultiLine" Text="<%#: BindItem.Body %>"></asp:TextBox>
            <br />
            <br/>
            <asp:Button runat="server" Text="Insert" CommandName="Insert" />
            <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="CancelButton_Click" />
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
