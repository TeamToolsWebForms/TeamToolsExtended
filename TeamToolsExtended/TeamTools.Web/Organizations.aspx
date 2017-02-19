<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Organizations.aspx.cs" Inherits="TeamTools.Web.Organizations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Content/my-organizations.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" id="myorganizations-main">
        <div class="row">
            <div class="col-xs-12 col-sm-offset-3 col-sm-6">
                <div class="panel panel-default">
                    <div class="panel-heading c-list">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="form-inline">
                                    <div class="form-group">
                                        <label for="SearchOrganizations">Organizations</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="SearchOrganizations" />
                                        <asp:Button Text="Search" ID="SearchBtn" OnClick="SearchBtn_Click" CssClass="btn btn-default" runat="server" />
                                    </div>
                                    <div class="pull-right c-controls">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <a id="showCreatePanel" runat="server" onserverclick="showCreatePanel_ServerClick" data-toggle="tooltip" data-placement="top" title="Add Organization">
                                                    <i class="glyphicon glyphicon-plus"></i>
                                                </a>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="SearchBtn" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>

                    <ul class="list-group" id="contact-list">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:ListView runat="server" OnItemDataBound="OrganizationsListView_ItemDataBound" ID="OrganizationsListView" ItemType="TeamTools.Logic.DTO.OrganizationDTO">
                                    <LayoutTemplate>
                                        <div class="dropdown" id="SortMenu">
                                            <span class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Sort <span class="caret"></span></span>
                                            <ul class="dropdown-menu">
                                                <li>
                                                    <a runat="server" class="text-center" id="SortInitially" onserverclick="SortInitially_ServerClick">Initially</a>
                                                    <a runat="server" class="text-center" id="SortByName" onserverclick="SortByName_ServerClick">By name</a>
                                                </li>
                                            </ul>
                                        </div>
                                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <li class="list-group-item">
                                            <div class="col-xs-12 col-sm-3">
                                                <img src="<%#: Item.OrganizationLogoUrl %>" alt="Organization logo" class="img-responsive img-circle" />
                                            </div>
                                            <div class="col-xs-12 col-sm-9">
                                                <asp:Button runat="server" CommandArgument="<%#: Item.Id %>" ID="JoinOrganizationBtn" OnClick="JoinOrganizationBtn_Click" CssClass="btn btn-danger pull-right" Text="Join" />
                                                <span class="name">
                                                    <asp:HyperLink runat="server" CssClass="my-anchor" NavigateUrl='<%# string.Format("~/organizationdetails?id={0}", Item.Id) %>' Text="<%#: Item.Name %>" /></span><br />
                                                <span class="fa fa-user-circle-o" data-toggle="tooltip" title="Created by"> <%#: Item.CreatorName %></span>
                                            </div>
                                            <div class="clearfix"></div>
                                        </li>
                                    </ItemTemplate>
                                </asp:ListView>

                                <asp:DataPager ID="DataPagerMyOrganizationsListView" ClientIDMode="Static" runat="server"
                                    PagedControlID="OrganizationsListView" PageSize="5">
                                    <Fields>
                                        <asp:NextPreviousPagerField ShowFirstPageButton="false"
                                            ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                        <asp:NumericPagerField />
                                        <asp:NextPreviousPagerField ShowLastPageButton="false"
                                            ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                    </Fields>
                                </asp:DataPager>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </ul>
                </div>
            </div>
        </div>

        <asp:Panel ID="CreteOrganizationPanel" ClientIDMode="Static" runat="server" CssClass="modalPopup" align="center" Style="display: none">
            <div class="modal-dialog modal-md">
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <button type="button" runat="server" onserverclick="closeBtn_ServerClick" id="closeBtn" class="close" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <h4 class="modal-title">New Organization</h4>
                    </div>
                    <div class="modal-body">
                        <div>
                            <div class="form-group">
                                <label for="organizationName">Name</label>
                                <asp:TextBox runat="server" ID="OrganizationName" CssClass="form-control" placeholder="Name of the organization" />
                                <asp:RegularExpressionValidator Display="Dynamic" ErrorMessage="Name must be between 4 and 50 symbols" CssClass="text-danger" ValidationExpression="^[\s\S]{4,50}$" ControlToValidate="OrganizationName" runat="server" />
                            </div>
                            <div class="form-group">
                                <label for="organizationDesc">Description</label>
                                <textarea class="form-control" rows="5" runat="server" id="organizationDesc" placeholder="Optional description"></textarea>
                                <asp:RegularExpressionValidator Display="Dynamic" ErrorMessage="Name must be between 5 and 200 symbols" CssClass="text-danger" ValidationExpression="^[\s\S]{5,200}$" ControlToValidate="organizationDesc" runat="server" />
                            </div>
                            <div class="actions">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="saveOrganizationBtn" CssClass="btn btn-success" Text="Save Project" OnClick="saveOrganizationBtn_Click" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Label ID="test" runat="server" />
    </div>
    <script src="../Scripts/my-organizations.js"></script>
</asp:Content>
