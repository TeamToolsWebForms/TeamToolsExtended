<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyProjects.ascx.cs" Inherits="TeamTools.Web.Profile.MyProjects" %>

<asp:ListView runat="server" ID="ProfileProjects" ItemType="TeamTools.Logic.DTO.ProjectDTO">
    <LayoutTemplate>
        <div class="container">
            <div class="row" id="list-root">
                <div>
                    <ul id="items-list">
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </ul>
                </div>
            </div>
        </div>
    </LayoutTemplate>
    <ItemTemplate>
        <li class="list-item col-md-3">
            <h3><a href="#"><i class="fa fa-file-text"></i> <%#: Item.Title %></a></h3>
            <p><%#: Item.Description %></p>
        </li>
    </ItemTemplate>
    <EmptyDataTemplate>
        <h3>Currently you don't have projects</h3>
    </EmptyDataTemplate>
</asp:ListView>
<asp:DataPager ID="DataPagerAllMyProjects" runat="server"
    PagedControlID="ProfileProjects" PageSize="16">
    <Fields>
        <asp:NextPreviousPagerField ShowFirstPageButton="false"
            ShowNextPageButton="false" ShowPreviousPageButton="false" />
        <asp:NumericPagerField />
        <asp:NextPreviousPagerField ShowLastPageButton="false"
            ShowNextPageButton="false" ShowPreviousPageButton="false" />
    </Fields>
</asp:DataPager>
