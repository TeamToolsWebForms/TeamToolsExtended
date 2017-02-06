<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TeamTools.Web.Profile.Home" %>

<%@ Register Src="~/Profile/HomePersonalInfo.ascx" TagName="PersonalInfo" TagPrefix="pi" %>
<%@ Register Src="~/Profile/CreateNote.ascx" TagName="CreateNote" TagPrefix="cn" %>
<%@ Register Src="~/Profile/MyNotes.ascx" TagName="MyNotes" TagPrefix="mn" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../Content/home-profile.css" rel="stylesheet" type="text/css" />
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet">
    <link href="../Content/create-note.css" rel="stylesheet" type="text/css" />
    <link href="../Content/mynotes.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManagerProxy runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/create-note-validation.js" />
            <asp:ScriptReference Path="~/Scripts/mynotes.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
    <div class="container">
        <div class="row">
            <div class="col-sm-3">
                <ul class="nav nav-pills nav-stacked nav-email shadow mb-20">
                    <li class="active">
                        <asp:LinkButton runat="server" ID="MyProfile" OnClick="MyProfile_Click">
                            <i class="fa fa-user"></i>Profile  <span class="label pull-right"></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton runat="server" ID="MyNotes" OnClick="MyNotes_Click">
                            <i class="fa fa-sticky-note-o"></i>My Notes  <span class="label pull-right"></span>
                        </asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton runat="server" ID="CreateNote" OnClick="CreateNote_Click">
                            <i class="fa fa-sticky-note"></i>Create Note <span class="label pull-right"></span></asp:LinkButton>
                    </li>
                    <li>
                        <a href="#"><i class="fa fa-certificate"></i>Important</a>
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
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <pi:PersonalInfo runat="server" ID="PersonalInfoControl" />
                    <cn:CreateNote runat="server" ID="CreateNoteControl" Visible="false" />
                    <mn:MyNotes runat="server" ID="MyNotesControl" Visible="false" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="MyNotes" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="CreateNote" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="MyProfile" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
