<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="TeamTools.Web.ProjectDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
</asp:Content>
