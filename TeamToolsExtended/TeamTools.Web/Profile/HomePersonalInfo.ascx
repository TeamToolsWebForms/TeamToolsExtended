<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomePersonalInfo.ascx.cs" Inherits="TeamTools.Web.Profile.HomePersonalInfo" %>
<%@ Register Src="~/Profile/HomeOrganizations.ascx" TagName="MyOrganizations" TagPrefix="mo" %>
<%@ Register Src="~/Profile/HomeProjects.ascx" TagName="MyProjects" TagPrefix="mp" %>

<asp:ScriptManagerProxy runat="server" ID="ProfileHomeScriptManager">
    <Scripts>
        <asp:ScriptReference Path="~/Scripts/Profile/Home/profile-home.js" />
    </Scripts>
</asp:ScriptManagerProxy>
<div class="col-sm-9">
    <div class="panel panel-default">
        <div class="panel-heading resume-heading">
            <div class="row">
                <div class="col-lg-12">
                    <div class="col-xs-12 col-sm-4">
                        <figure>
                            <asp:Image runat="server" ID="ProfileImage" AlternateText="Profile logo" CssClass="img-circle img-responsive" />
                        </figure>
                        <div class="row">
                            <div class="col-xs-12 social-btns">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:FileUpload runat="server" ID="FileUpload" />
                                        <asp:Button Text="Upload" runat="server" ID="UploadImage" CssClass="btn btn-info" OnClick="UploadImage_Click" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="UploadImage" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:Button Text="Upload image" runat="server" ID="ShowUpload" CssClass="btn btn-info" OnClick="ShowUpload_Click" />
                            </div>
                        </div>
                    </div>
                    <div id="profileInfo" class="col-xs-12 col-sm-8">
                        <ul class="list-group">
                            <li class="list-group-item"><%#: this.Model.User.FirstName %></li>
                            <li class="list-group-item"><%#: this.Model.User.LastName %></li>
                            <li class="list-group-item"><%#: this.Model.User.Gender %></li>
                            <li class="list-group-item"><i class="fa fa-envelope"></i> <%#: HttpContext.Current.User.Identity.GetUserName() %></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class="bs-callout bs-callout-danger">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="tabbable-panel">
                        <div class="tabbable-line">
                            <ul class="nav nav-tabs">
                                <li id="myProjects">
                                    <asp:Button Text="My Projects" runat="server" ID="ShowProjects" CssClass="btn btn-default" OnClick="ShowProjects_Click" />
                                </li>
                                <li id="myOrganizations">
                                    <asp:Button Text="My Organizations" runat="server" ID="ShowOrganizations" CssClass="btn btn-default" OnClick="ShowOrganizations_Click" />
                                </li>
                            </ul>
                            <div class="tab-content">
                                <asp:MultiView ActiveViewIndex="1" runat="server" ID="ContentView">
                                    <asp:View runat="server" ID="MyOrganizationsView">
                                        <mo:MyOrganizations runat="server" />
                                    </asp:View>
                                    <asp:View runat="server" ID="MyProjectsView">
                                        <mp:MyProjects runat="server" />
                                    </asp:View>
                                </asp:MultiView>
                            </div>
                        </div>
                    </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
