<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrganizationDetails.aspx.cs" Inherits="TeamTools.Web.OrganizationDetails" %>
<%@ Register Src="~/OrganizationDetailsHome.ascx" TagName="OrganizationHome" TagPrefix="oh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-3">
                <ul class="nav nav-pills nav-stacked nav-email shadow mb-20">
                    <li class="active">
                        <asp:LinkButton runat="server" ID="OrganizationProfile" OnClick="OrganizationProfile_Click">
                            <i class="fa fa-sitemap"></i>Home  <span class="label pull-right"></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton runat="server" ID="OrganizationAddUser">
                            <i class="fa fa-user-plus"></i>Add user  <span class="label pull-right"></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton runat="server" ID="OrganizationProjects">
                            <i class="fa fa-file-text-o"></i>Projects  <span class="label pull-right"></span>
                        </asp:LinkButton>
                    </li>
                </ul>
            </div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <oh:OrganizationHome runat="server" ID="OrganizationHomeControl" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="OrganizationProfile" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
