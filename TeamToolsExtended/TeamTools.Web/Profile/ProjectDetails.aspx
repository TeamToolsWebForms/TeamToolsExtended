<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="TeamTools.Web.Profile.ProjectDetails" %>

<%@ Register Src="~/Profile/ProjectDetailsChart.ascx" TagName="ProjectChart" TagPrefix="pt" %>
<%@ Register Src="~/Profile/ProjectDetailsTasks.ascx" TagName="ProjectTasks" TagPrefix="pt" %>
<%@ Register Src="~/Profile/ProjectDetailsDocuments.ascx" TagName="ProjectDocuments" TagPrefix="pt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Content/project-details.css" rel="stylesheet" type="text/css" />
    <link href="../Content/new-task.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wrapper" class="row">
        <div id="sidebar-wrapper">
            <ul class="sidebar-nav">
                <li class="sidebar-brand">
                    <a runat="server" id="ShowTasks" onserverclick="ShowTasks_ServerClick">Show tasks</a>
                </li>
                <li class="sidebar-brand">
                    <a runat="server" id="ShowStatistics" onserverclick="ShowStatistics_ServerClick">Statistics</a>
                </li>
                <li class="sidebar-brand">
                    <a id="AddNewDocument" onclick="showAjaxFileUpload();">Add document</a>
                </li>
                <li class="sidebar-brand">
                    <a runat="server" id="ShowDocuments" onserverclick="ShowDocuments_ServerClick">Show documents</a>
                </li>
                <li>
                    <div class="dropdown">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Settings
                        </button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton" style="position: absolute; left: 20px">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <a runat="server" onserverclick="DeleteProjectButton_ServerClick" id="DeleteProjectButton">Delete project</a>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
        <div>
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
                                AllowedFileTypes="txt,xlsx,pdf,doc,docx,jpg,jpeg"
                                MaximumNumberOfFiles="3"
                                runat="server" />
                        </div>
                    </div>
                </div>
            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div id="DeleteProjectPanel" class="panel panel-default col-md-4">
                        <div class="panel-content">
                            <div class="panel-header">
                                <button type="button" runat="server" onserverclick="closeDeleteProjectForm_ServerClick" id="closeDeleteProjectForm" class="close" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <h4 class="modal-title">Are you sure you want to delete the project?</h4>
                            </div>
                            <div class="panel-body">
                                <asp:Button Text="Yes" ID="DeleteProjectBtn" OnClick="DeleteProjectBtn_Click" CssClass="btn btn-danger" runat="server" />
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <div id="page-content-wrapper">
            <div class="container-fluid">
                <div class="container">
                    <div class="row">
                        <div class="col-xs-14">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <pt:ProjectChart runat="server" ID="ProjectStatsControl" Visible="false" />
                                    <pt:ProjectTasks runat="server" ID="ProjectDetailsContentControl" />
                                    <pt:ProjectDocuments runat="server" ID="ProjectDocumentsControl" Visible="false" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ShowTasks" EventName="ServerClick" />
                                    <asp:AsyncPostBackTrigger ControlID="ShowStatistics" EventName="ServerClick" />
                                    <asp:AsyncPostBackTrigger ControlID="ShowDocuments" EventName="ServerClick" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../Scripts/project-details-download.js"></script>
    <script src="../Scripts/project-details.js"></script>
</asp:Content>
