<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeProjects.ascx.cs" Inherits="TeamTools.Web.Profile.HomeProjects" %>
<link rel="stylesheet" href="../Content/home-controls.css" type="text/css" />

<asp:ListView runat="server" ID="ProfileProjects" ItemType="TeamTools.Logic.DTO.ProjectDTO">
    <ItemTemplate>
        <div class="container">
            <div class="row">
                <div>
                    <ul id="items-list">
                        <li class="list-item">
                            <h3>
                                <span class="fa fa-file-text">
                                    <asp:HyperLink NavigateUrl='<%# Eval("Id", "~/Profile/ProjectDetails.aspx?id={0}") %>' Text="<%#: Item.Title %>" runat="server" />
                                </span>
                            </h3>
                            <p><%#: Item.Description %></p>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </ItemTemplate>
    <EmptyDataTemplate>
        <h3>Currently you don't have projects</h3>
    </EmptyDataTemplate>
</asp:ListView>
<asp:DataPager ID="DataPagerMyProjects" runat="server"
    PagedControlID="ProfileProjects" PageSize="4">
    <Fields>
        <asp:NextPreviousPagerField ShowFirstPageButton="false"
            ShowNextPageButton="false" ShowPreviousPageButton="false" />
        <asp:NumericPagerField />
        <asp:NextPreviousPagerField ShowLastPageButton="false"
            ShowNextPageButton="false" ShowPreviousPageButton="false" />
    </Fields>
</asp:DataPager>
