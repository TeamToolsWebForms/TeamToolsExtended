<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectDetailsAddUserToProject.ascx.cs" Inherits="TeamTools.Web.ProjectDetailsAddUserToProject" %>

<div id="AddUserPanel" class="panel panel-default col-md-10">
    <div class="panel-content">
        <div class="panel-header">
            <h4 class="panel-title text-center">Add user to project</h4>
        </div>
        <div class="panel-body">
            <div class="form-group">
                <label for="userField">Email</label>
                <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control" ID="ProjectUserField" />
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Button runat="server" ID="AddUserToProjectBtn" OnClick="AddUserToProjectBtn_Click" CssClass="btn btn-info" Text="Add user" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>
