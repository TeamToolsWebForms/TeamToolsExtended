<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="OrganizationDetails.aspx.cs" Inherits="TeamTools.Web.OrganizationDetails" %>

<%@ Register Src="~/OrganizationDetailsHome.ascx" TagName="OrganizationHome" TagPrefix="oh" %>
<%@ Register Src="~/OrganizationDetailsAddUser.ascx" TagName="OrganizationAddUser" TagPrefix="oau" %>
<%@ Register Src="~/OrganizationDetailsProjects.ascx" TagName="OrganizationProjects" TagPrefix="op" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/organization-details.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" id="organization-details">
        <div class="row">
            <div class="col-sm-3">
                <ul class="nav nav-pills nav-stacked nav-email shadow mb-20">
                    <li class="active">
                        <asp:LinkButton runat="server" ID="OrganizationProjects" OnClick="OrganizationProjects_Click">
                            <i class="fa fa-file-text-o"></i> Projects  <span class="label pull-right"></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton runat="server" ID="OrganizationAddUser" OnClick="OrganizationAddUser_Click">
                            <i class="fa fa-user-plus"></i> Add user  <span class="label pull-right"></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton runat="server" ID="OrganizationProfile" OnClick="OrganizationProfile_Click">
                            <i class="fa fa-sitemap"></i> Organization Info  <span class="label pull-right"></span>
                        </asp:LinkButton>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Settings <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <li class="settings-item">
                                        <a runat="server" onserverclick="LeaveOrganizationBtn_ServerClick" id="LeaveOrganizationBtn">Leave organization</a>
                                    </li>
                                    <li class="settings-item">
                                        <a runat="server" onserverclick="ChangeLogo_ServerClick" id="ChangeLogo">Change logo</a>
                                    </li>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ul>
                    </li>
                </ul>
            </div>
            <div id="DocumentFileUpload" class="panel panel-default col-md-4">
                <div class="panel-content">
                    <div class="panel-header">
                        <button type="button" onclick="closeFileUploadForm();" id="Button1" class="close" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <div class="panel-body">
                            <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload"
                                ClientIDMode="Static" OnClientUploadCompleteAll="verifyDownload"
                                OnUploadComplete="AjaxFileUpload_UploadComplete"
                                AllowedFileTypes="png,jpg,jpeg"
                                MaximumNumberOfFiles="1"
                                runat="server" />
                        </div>
                    </div>
                </div>
            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <oh:OrganizationHome runat="server" ID="OrganizationHomeControl" Visible="false" />
                    <oau:OrganizationAddUser runat="server" ID="OrganizationAddUserControl" Visible="false" />
                    <op:OrganizationProjects runat="server" ID="OrganizationProjectsControl" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="OrganizationProfile" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="OrganizationAddUser" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="OrganizationProjects" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>

    <script src="Scripts/organization-details.js"></script>
    <script src="Scripts/organization-details-projects.js"></script>
    <script src="Scripts/organization-details-adduser.js"></script>
</asp:Content>
