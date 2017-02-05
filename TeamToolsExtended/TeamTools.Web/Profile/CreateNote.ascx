<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateNote.ascx.cs" Inherits="TeamTools.Web.Profile.CreateNote" %>

<div class="quote-container">
  <i class="pin"></i>
  <blockquote class="note yellow">
    <label for="title">Title</label>
    <asp:TextBox runat="server" ID="title" type="text"/>
    <asp:CustomValidator ControlToValidate="title" runat="server" ClientValidationFunction="titleValidation" EnableClientScript="true"  />
    <label for="content">Content</label>
    <asp:TextBox runat="server" ID="content" type="text"/>
    <asp:CustomValidator ControlToValidate="content" runat="server" ClientValidationFunction="contentValidation" EnableClientScript="true" />
    <asp:Button runat="server" ID="NewNote" Text="Add" OnClick="NewNote_Click" />
  </blockquote>
</div>
