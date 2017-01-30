<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="TeamTools.Web.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-md-10 col-md-offset-1">
            <div class="well form-horizontal">
                <asp:Label runat="server" ID="UserLogo" Text="<%# Page.User.Identity.GetUserName() %>" />
                <img src="shouldBeChanged!" alt="Profile image" class="img-thumbnail">
                <h2 class="text-danger"></h2>
                <div class="text-center">
                    <p class="glyphicon glyphicon-pencil"></p>
                    <button class="btn btn-success" style="position: absolute; right: 500px;">Save</button>
                </div>
                <div class="text-left">
                    <asp:TextBox runat="server" ID="theFuck" />
                    <h4>Email:
                    <span class="text-success"></span>
                    </h4>
                    <h4>First name:
                    <span class="text-success"></span>
                        <input name="editEmail" type="text">
                    </h4>
                    <h4>Last name:
                    <span class="text-success"></span>
                        <input name="editEmail" type="text">
                    </h4>
                    <h4>Gender: <span class="text-success"></span></h4>
                    <h4>Company:
                    <span class="text-success"></span>
                        <input name="editEmail" type="text">
                    </h4>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
