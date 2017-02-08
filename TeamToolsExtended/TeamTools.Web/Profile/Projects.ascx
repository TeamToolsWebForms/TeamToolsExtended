<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Projects.ascx.cs" Inherits="TeamTools.Web.Profile.MyProjects" %>

<div class="row">
    <div class="col-md-7 col-md-offset-1">
        <div class="panel panel-default panel-table">
            <div class="panel-heading">
                <div class="row">
                    <div class="col col-xs-6">
                        <h3 class="panel-title">My Projects</h3>
                    </div>
                    <div class="col col-xs-6 text-right">
                        <button type="button" class="btn btn-sm btn-primary btn-create">Create New</button>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <asp:GridView runat="server" ID="MyProjectsGrid"
                    DataKeyNames="Id"
                    ItemType="TeamTools.Logic.DTO.ProjectDTO"
                    CssClass="table table-striped table-bordered table-list"
                    AutoGenerateColumns="false" AllowPaging="true"
                    AllowSorting="true"
                    PageSize="5"
                    OnPageIndexChanging="MyProjectsGrid_PageIndexChanging"
                    SelectMethod="MyProjectsGrid_GetData"
                    UpdateMethod="MyProjectsGrid_UpdateItem"
                    DeleteMethod="MyProjectsGrid_DeleteItem">
                    <Columns>
                        <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-info" />
                        <asp:BoundField SortExpression="Title" DataField="Title" HeaderText="Name" />
                        <asp:BoundField SortExpression="CreatorName" ReadOnly="true" DataField="CreatorName" HeaderText="Creator" />
                        <asp:CommandField ShowDeleteButton="true" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-danger" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</div>
