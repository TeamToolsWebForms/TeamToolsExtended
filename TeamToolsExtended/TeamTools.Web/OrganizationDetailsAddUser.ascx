<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrganizationDetailsAddUser.ascx.cs" Inherits="TeamTools.Web.OrganizationDetailsAddUser" %>

<div class="col-md-8">
    <div class="modal-dialog modal-md box">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Invite user to organization</h4>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <label for="userField">Username</label>
                    <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control" ID="UserField" />
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Button runat="server" ID="SendInvitation" CssClass="btn btn-info" Text="Invite" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</div>
