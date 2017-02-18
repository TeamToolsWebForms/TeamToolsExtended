<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="TeamTools.Web.ProjectDetails" %>

<%@ Register Src="~/ProjectDetailsCharts.ascx" TagName="ProjectChart" TagPrefix="pt" %>
<%@ Register Src="~/ProjectDetailsTasks.ascx" TagName="ProjectTasks" TagPrefix="pt" %>
<%@ Register Src="~/ProjectDetailsDocuments.ascx" TagName="ProjectDocuments" TagPrefix="pt" %>
<%@ Register Src="~/ProjectDetailsAddUserToProject.ascx" TagName="AddUserToProject" TagPrefix="pt" %>

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
                    <a runat="server" id="AddUserToProject" onserverclick="AddUserToProject_ServerClick">Add user to project</a>
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
                                    <pt:AddUserToProject runat="server" ID="AddUserToProjectControl" Visible="false" />
                                    <pt:ProjectTasks runat="server" ID="ProjectDetailsContentControl" />
                                    <pt:ProjectDocuments runat="server" ID="ProjectDocumentsControl" Visible="false" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ShowTasks" EventName="ServerClick" />
                                    <asp:AsyncPostBackTrigger ControlID="ShowStatistics" EventName="ServerClick" />
                                    <asp:AsyncPostBackTrigger ControlID="ShowDocuments" EventName="ServerClick" />
                                    <asp:AsyncPostBackTrigger ControlID="AddUserToProject" EventName="ServerClick" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>






    <ajaxToolkit:Accordion ID="AccordionTasks" runat="server"
        SelectedIndex="-1"
        HeaderCssClass="accordionHeader"
        HeaderSelectedCssClass="accordionHeaderSelected"
        ContentCssClass="accordionContent"
        AutoSize="None"
        FadeTransitions="true"
        TransitionDuration="250"
        FramesPerSecond="40"
        RequireOpenedPane="false"
        SuppressHeaderPostbacks="true"
        ClientIDMode="Static">
        <Panes>
            <ajaxToolkit:AccordionPane runat="server">
                <Header>
                    <div id="showChat">
                        <span class="glyphicon glyphicon-comment"></span>Chat
                                <div class="btn-group">
                                    <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">
                                        <span class="glyphicon glyphicon-chevron-down"></span>
                                    </button>
                                </div>
                    </div>
                </Header>
                <Content>
                    <div id="main-chat" <%--[@slideInOut]="menuState"--%> class="container col-xs-4">
                        <div class="row">
                            <div class="panel panel-default">
                                <div class="panel-heading"><%--{{project.name}}--%></div>
                                <div class="panel-body">
                                    <div id="message-container" <%--#chatContent--%> class="container scrollable-chat-menu">
                                        <div class="row message-bubble" <%--*ngFor="let message of messages"--%>>
                                            <p class="text-muted">
                                                <img style="width: 30px; height: 25px;" src="<%--{{message.picture}}/> {{message.from}}--%>" />
                                            </p>
                                            <p><%--{{message.message}}--%></p>
                                            <div>sent <%--{{message.created | date}}--%></div>
                                        </div>
                                    </div>
                                    <div class="chat-message-botom">
                                        <div class="input-group">
                                            <input id="m" type="text" class="form-control" <%--(keyup.enter)="messageBoardUpdate()"--%> <%--[(ngModel)]="message"--%> />
                                            <span class="input-group-btn">
                                                <button id="sendMsg" type="submit" class="btn btn-success" <%--(click)="messageBoardUpdate()"--%>>Send</button>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </Content>
            </ajaxToolkit:AccordionPane>
        </Panes>
    </ajaxToolkit:Accordion>

    <script src="../Scripts/project-details.js"></script>
</asp:Content>
