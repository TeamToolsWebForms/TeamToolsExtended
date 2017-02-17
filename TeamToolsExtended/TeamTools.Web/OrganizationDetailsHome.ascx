<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrganizationDetailsHome.ascx.cs" Inherits="TeamTools.Web.OrganizationDetailsHome" %>

<div class="container">
    <div class="row">
        <div class="col-md-8">
            <div class="panel panel-default" id="aboutModal">
                <div class="panel-header">
                    <h3 id="organization-home-title">About <%#: this.Model.Organization.Name %></h3>
                </div>
                <div class="panel-body" style="text-align: center;">
                    <div class="row-fluid">
                        <div class="span10 offset1">
                            <div class="tab-content">
                                <div class="tab-pane active" id="about">
                                    <img src="<%#: this.Model.Organization.OrganizationLogoUrl %>" width="140" height="140" border="0" class="img-circle" />
     
                                    <h3 class="media-heading"><%#: this.Model.Organization.Name %></h3>
                                    <span><strong>Members: </strong></span>
                                    <asp:Repeater runat="server" ID="OrganizationMembersRepeater" ItemType="TeamTools.Logic.DTO.UserDTO">
                                        <ItemTemplate>
                                            <span class="label label-info"><%#: Item.FirstName + " " + Item.LastName %></span>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <hr>
                                    <div>
                                        <p class="text-left">
                                            <strong>Description: </strong>
                                            <br>
                                            <%#: this.Model.Organization.Description %>
                                        </p>
                                        <br>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
