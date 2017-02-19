<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Projects.ascx.cs" Inherits="TeamTools.Web.Profile.Projects" %>

<div id="gridviewControl" class="row">
    <div class="col-md-9">
        <div class="panel panel-default panel-table">
            <div class="panel-heading">
                <div class="row">
                    <div class="col col-xs-6">
                        <h3 class="panel-title">My Projects</h3>
                    </div>
                    <div class="col col-xs-6 text-right">
                        <asp:Button ID="CreateNew" ClientIDMode="Static" CssClass="btn btn-sm btn-primary btn-create" Text="Create New" runat="server" OnClick="CreateNew_Click" />
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <asp:GridView runat="server" ID="MyProjectsGrid"
                    ViewStateMode="Enabled"
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
                    <EmptyDataTemplate>
                        <h3 class="text-center">There are no personal projects yet!</h3>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-info" />
                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="fa fa-info-circle btn btn-warning" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/profile/projectdetails.aspx?id={0}" Text=" Info" HeaderText="Show details" />
                        <asp:BoundField SortExpression="Title" DataField="Title" HeaderText="Name" />
                        <asp:BoundField SortExpression="CreatorName" ReadOnly="true" DataField="CreatorName" HeaderText="Creator" />
                        <asp:CommandField ShowDeleteButton="true" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-danger" />
                    </Columns>
                </asp:GridView>
            </div>

            <asp:Panel ID="CreteProjectPanel" ClientIDMode="Static" runat="server" CssClass="modalPopup" align="center" Style="display: none">
                    <div class="modal-dialog modal-md">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" runat="server" onserverclick="closeBtn_ServerClick" id="closeBtn" class="close" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <h4 class="modal-title">New Project</h4>
                            </div>
                            <div class="modal-body">
                                <form>
                                    <div class="form-group">
                                        <label for="projectName">Name</label>
                                        <asp:TextBox runat="server" ID="ProjectName" CssClass="form-control" placeholder="Name of the project" />
                                    </div>
                                    <div class="form-group">
                                        <label for="projectDesc">Description</label>
                                        <textarea class="form-control" rows="5" runat="server" id="projectDesc" placeholder="Optional description"></textarea>
                                    </div>
                                    <div class="actions">
                                        <asp:Button ID="saveProject" CssClass="btn btn-success" Text="Save Project" OnClick="saveProject_Click" runat="server" />
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
            </asp:Panel>
        </div>
    </div>
</div>
