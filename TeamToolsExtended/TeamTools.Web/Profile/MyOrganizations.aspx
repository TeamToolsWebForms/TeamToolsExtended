<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyOrganizations.aspx.cs" Inherits="TeamTools.Web.Profile.MyOrganizations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" id="myorganizations-main">
        <div class="row">
            <div class="col-xs-12 col-sm-offset-3 col-sm-6">
                <div class="panel panel-default">
                    <div class="panel-heading c-list">
                        <span class="title">My Organizations</span>
                        <div class="pull-right c-controls">
                            <a href="#cant-do-all-the-work-for-you" data-toggle="tooltip" data-placement="top" title="Add Contact"><i class="glyphicon glyphicon-plus"></i></a>
                        </div>
                    </div>

                    <div class="row" style="display: none;">
                        <div class="col-xs-12">
                            <div class="input-group c-search">
                                <input type="text" class="form-control" id="contact-list-search">
                                <span class="input-group-btn">
                                    <button class="btn btn-default" type="button"><span class="glyphicon glyphicon-search text-muted"></span></button>
                                </span>
                            </div>
                        </div>
                    </div>

                    <ul class="list-group" id="contact-list">
                        <asp:ListView runat="server" ID="MyOrganizationsListView" ItemType="TeamTools.Logic.DTO.OrganizationDTO">
                            <ItemTemplate>
                                <li class="list-group-item">
                                    <div class="col-xs-12 col-sm-3">
                                        <img src="<%#: Item.OrganizationLogoUrl %>" alt="Organization logo" class="img-responsive img-circle" />
                                    </div>
                                    <div class="col-xs-12 col-sm-9">
                                        <span class="name"><%#: Item.Name %></span><br />
                                        <span class="fa fa-user-circle-o" data-toggle="tooltip" title="Created by"></span>
                                        <span class="visible-xs"><span class="text-muted"><%#: Item.CreatorName %></span><br />
                                        </span>
                                    </div>
                                    <div class="clearfix"></div>
                                </li>
                            </ItemTemplate>
                        </asp:ListView>
                    </ul>
                </div>
            </div>
        </div>

        <%--<div id="cant-do-all-the-work-for-you" class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title" id="mySmallModalLabel">Ooops!!!</h4>
                    </div>
                    <div class="modal-body">
                        <p>I am being lazy and do not want to program an "Add User" section into this snippet... So it looks like you'll have to do that for yourself.</p>
                        <br />
                        <p>
                            <strong>Sorry<br />
                                ~ Mouse0270</strong>
                        </p>
                    </div>
                </div>
            </div>
        </div>--%>
    </div>
</asp:Content>
