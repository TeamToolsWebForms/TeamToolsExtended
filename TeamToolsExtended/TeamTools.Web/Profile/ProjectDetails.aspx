<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="TeamTools.Web.Profile.ProjectDetails" %>
<%@ Register Src="~/Profile/ProjectDetailsTasks.ascx" TagName="ProjectTasks" TagPrefix="pt" %>
<%-- Add documents --%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Content/project-details.css" rel="stylesheet" type="text/css" />
    <link href="../Content/message-board.css" rel="stylesheet" type="text/css" />
    <link href="../Content/new-task.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManagerProxy runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/project-details.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
    <div id="wrapper" class="row">
        <div id="sidebar-wrapper">
            <ul class="sidebar-nav">
                <li class="sidebar-brand">
                    <div class="dropdown">
                        <button class="btn btn-default dropdown-toggle" type="button" data-toggle="dropdown">
                            Project members
  <span class="caret"></span>
                        </button>
                        <ul class="dropdown-menu" style="position: absolute; top: 45px; left: 80px;">
                            <li>
                                <span>Full name</span>
                            </li>
                        </ul>
                    </div>
                </li>
                <li class="sidebar-brand">
                    <a role="button">Add user to project</a>
                </li>
            </ul>
        </div>

        <!-- Page Content -->
        <div id="page-content-wrapper">
            <div class="container-fluid">
                <div class="container">
                    <div class="row">
                        <div class="col-xs-10">
                            <pt:ProjectTasks runat="server" />
                            <div class="modal-dialog modal-md box hidden">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" aria-label="Close" <%--(click)="toggleMove()"--%>>
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                        <h4 class="modal-title">Add user to project</h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-group">
                                            <label for="userField">Username</label>
                                            <input class="form-control" <%--auto-complete--%> <%--[source]="users"--%> id="userField" name="userToAdd" <%--[(ngModel)]="userToAdd"--%> type="text" />
                                            <button class="btn btn-info" <%--(click)="addUserToProject(); !addUser"--%>>Add</button>
                                        </div>
                                    </div>
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
        </div>
    </div>
</asp:Content>
