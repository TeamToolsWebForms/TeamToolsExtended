<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeOrganizations.ascx.cs" Inherits="TeamTools.Web.Profile.HomeOrganizations" %>
<link rel="stylesheet" href="../Content/home-controls.css" type="text/css" />

<asp:ListView runat="server" ID="ProfileOrganizations" ItemType="TeamTools.Logic.DTO.OrganizationDTO">
    <LayoutTemplate>
        <div class="dropdown">
            <span class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Sort <span class="caret"></span></span>
            <ul class="dropdown-menu">
                <li><asp:Button runat="server" Text="By name" ID="SortByName" CssClass="btn btn-default" OnClick="SortByName_Click" /></li>
            </ul>
        </div>
        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
    </LayoutTemplate>
    <ItemTemplate>
        <div class="container">
            <div class="row">
                <div>
                    <ul id="items-list">
                        <li class="list-item">
                            <h3><a href="#"><i class="fa fa-users"></i><%#: Item.Name %></a></h3>
                            <p><%#: Item.Description %></p>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </ItemTemplate>
    <EmptyDataTemplate>
        <h3>Currently you are not a member of organization</h3>
    </EmptyDataTemplate>
</asp:ListView>
<%-- Make pager with ajax --%>
<asp:DataPager ID="DataPagerOrganizations" runat="server"
    PagedControlID="ProfileOrganizations" PageSize="5"
    QueryStringField="page">
    <Fields>
        <asp:NextPreviousPagerField ShowFirstPageButton="true"
            ShowNextPageButton="false" ShowPreviousPageButton="false" />
        <asp:NumericPagerField />
        <asp:NextPreviousPagerField ShowLastPageButton="true"
            ShowNextPageButton="false" ShowPreviousPageButton="false" />
    </Fields>
</asp:DataPager>
