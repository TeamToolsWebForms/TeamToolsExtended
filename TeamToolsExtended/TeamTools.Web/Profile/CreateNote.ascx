<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateNote.ascx.cs" Inherits="TeamTools.Web.Profile.CreateNote" %>

<asp:ScriptManagerProxy runat="server" ID="ProfileHomeScriptManager">
    <Scripts>
        <asp:ScriptReference Path="~/Scripts/create-note-validation.js" />
    </Scripts>
</asp:ScriptManagerProxy>
<div class="quote-container">
  <i class="pin"></i>
  <blockquote class="note yellow">
    <label for="title">Title</label>
    <asp:TextBox runat="server" ID="title" type="text"/>
    <label for="content">Content</label>
    <asp:TextBox runat="server" ID="content" type="text"/>
    <asp:Button runat="server" ID="NewNote" Text="Add" OnClick="NewNote_Click" />
  </blockquote>
</div>
