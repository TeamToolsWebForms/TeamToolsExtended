<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TeamTools.Web.Profile.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Content/home-profile.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--<h3>Toq menu bara da ne go zabravime ;d</h3>
    <h3><%# HttpContext.Current.User.Identity.GetUserName() %></h3>
    <asp:Image runat="server" ID="ProfileImage" AlternateText="Profile logo" />--%>

    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet">
    <div class="container">
        <div class="row">
            <div class="col-sm-3">
                <ul class="nav nav-pills nav-stacked nav-email shadow mb-20">
                    <li class="active">
                        <a href="#mail-inbox.html">
                            <i class="fa fa-sticky-note-o"></i>My Notes  <span class="label pull-right"></span>
                        </a>
                    </li>
                    <li>
                        <a href="#mail-compose.html"><i class="fa fa-sticky-note"></i>Create Note</a>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-certificate"></i>Important</a>
                    </li>
                    <li>
                        <a href="#">
                            <i class="fa fa-file-text-o"></i>Notes <span class="label label-info pull-right inbox-notification">35</span>
                        </a>
                    </li>
                    <li><a href="#"><i class="fa fa-trash-o"></i>Trash</a></li>
                </ul>
                <!-- /.nav -->

                <h5 class="nav-email-subtitle">More</h5>
                <ul class="nav nav-pills nav-stacked nav-email mb-20 rounded shadow">
                    <li>
                        <a href="#">
                            <i class="fa fa-folder-open"></i>My Projects  <span class="label label-info pull-right">3</span>
                        </a>
                    </li>
                    <li>
                        <a href="#">
                            <i class="fa fa-sitemap"></i>My Organizations
                </a>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown"><span class="caret"></span><span style="font-size: 16px;" class="pull-left hidden-xs showopacity fa fa-cog"></span>Settings</a>
                        <ul class="dropdown-menu forAnimate" role="menu">
                            <li><a href="#">Change Password</a></li>
                            <li><a href="#">Delete project</a></li>
                        </ul>
                    </li>
                </ul>
            </div>
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
                                                    <asp:Button Text="Upload image" runat="server" ID="ImageUpload" OnClick="ImageUpload_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:FileUpload runat="server" ID="FileUpload" Visible="false" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
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
                                            <asp:MultiView ActiveViewIndex="0" runat="server" ID="ContentView" OnLoad="ContentView_Load">
                                                <asp:View runat="server" ID="MyOrganizationsView">
                                                    <asp:ListView runat="server" ID="ProfileOrganizations" ItemType="TeamTools.DataTransferObjects.OrganizationDTO">
                                                        <LayoutTemplate>
                                                            <h3>My Organizations</h3>
                                                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                                        </LayoutTemplate>
                                                        <ItemTemplate>
                                                            <h4><%#: Item.Name %></h4>
                                                            <p><%#: Item.Description %></p>
                                                        </ItemTemplate>
                                                    </asp:ListView>
                                                </asp:View>
                                                <asp:View runat="server" ID="MyProjectsView">
                                                    <h3>Projects</h3>
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
        </div>
    </div>
    <script src="../Scripts/Profile/Home/profile-home.js"></script>
</asp:Content>
