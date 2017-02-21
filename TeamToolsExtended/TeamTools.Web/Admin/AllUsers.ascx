<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AllUsers.ascx.cs" Inherits="TeamTools.Web.Admin.AllUsers" %>

<div id="gridviewControl" class="row">
    <div class="col-md-9">
        <div class="panel panel-default panel-table">
            <div class="panel-heading">
                <div class="row">
                    <div class="col col-xs-6">
                        <h3 class="panel-title">Users</h3>
                    </div>
                    <div class="col col-xs-6 text-right">
                        <asp:TextBox runat="server" CssClass="search-box" ClientIDMode="Static" ID="SearchUsers" />
                        <asp:Button ID="SearchBtn" ClientIDMode="Static" CssClass="btn btn-sm btn-primary btn-create" Text="Search" runat="server" OnClick="SearchBtn_Click" />
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <asp:GridView runat="server" ID="UsersGrid"
                    ViewStateMode="Enabled"
                    DataKeyNames="Id"
                    ItemType="TeamTools.Logic.DTO.UserDTO"
                    CssClass="table table-striped table-bordered table-list"
                    AutoGenerateColumns="false" AllowPaging="true"
                    AllowSorting="true"
                    PageSize="5"
                    OnPageIndexChanging="UsersGrid_PageIndexChanging"
                    SelectMethod="UsersGrid_GetData">
                    <EmptyDataTemplate>
                        <h3 class="text-center">There are no personal projects yet!</h3>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField SortExpression="Username" DataField="Username" HeaderText="Username" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="text-center">
                                    <asp:Button Text="Ban" CommandArgument="<%# Item.Id %>" ID="BanBtn" CssClass="btn btn-danger spacing" OnClick="BanBtn_Click" runat="server" />
                                    <asp:Button Text="Unban" CommandArgument="<%# Item.Id %>" ID="UnbanBtn" CssClass="btn btn-danger spacing" OnClick="UnbanBtn_Click" runat="server" />
                                    <asp:Button Text="Make Admin" CommandArgument="<%# Item.Id %>" ID="AdminBtn" CssClass="btn btn-warning spacing" OnClick="AdminBtn_Click" runat="server" />
                                    <asp:Button Text="Remove Admin" CommandArgument="<%# Item.Id %>" ID="RemoveAdminBtn" CssClass="btn btn-warning spacing" OnClick="RemoveAdminBtn_Click" runat="server" />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</div>