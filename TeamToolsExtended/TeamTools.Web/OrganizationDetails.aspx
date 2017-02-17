<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrganizationDetails.aspx.cs" Inherits="TeamTools.Web.OrganizationDetails" %>
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
                        <asp:LinkButton runat="server" ID="OrganizationProfile" OnClick="OrganizationProfile_Click">
                            <i class="fa fa-sitemap"></i> Home  <span class="label pull-right"></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton runat="server" ID="OrganizationAddUser" OnClick="OrganizationAddUser_Click">
                            <i class="fa fa-user-plus"></i> Add user  <span class="label pull-right"></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton runat="server" ID="OrganizationProjects" OnClick="OrganizationProjects_Click">
                            <i class="fa fa-file-text-o"></i> Projects  <span class="label pull-right"></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                    <div class="dropdown">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Settings
                        </button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton" style="position: absolute; left: 20px">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <a runat="server" onserverclick="LeaveOrganizationBtn_ServerClick" id="LeaveOrganizationBtn">Leave organization</a>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </li>
                </ul>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <oh:OrganizationHome runat="server" ID="OrganizationHomeControl" />
                    <oau:OrganizationAddUser runat="server" ID="OrganizationAddUserControl" Visible="false" />
                    <op:OrganizationProjects runat="server" ID="OrganizationProjectsControl" Visible="false" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="OrganizationProfile" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="OrganizationAddUser" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="OrganizationProjects" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
