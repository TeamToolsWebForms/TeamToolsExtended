<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectDetailsTasks.ascx.cs" Inherits="TeamTools.Web.Profile.ProjectDetailsTasks" %>

<div id="gridviewControl" class="row">
    <div class="col-md-7 col-md-offset-1">
        <div class="panel panel-default panel-table">
            <div class="panel-heading">
                <div class="row">
                    <div class="col col-xs-6">
                        <h3 class="panel-title">Project tasks</h3>
                    </div>
                    <div class="col col-xs-6 text-right">
                        <a id="CreateNew" class="btn btn-sm btn-primary btn-create">Create New</a>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <asp:GridView runat="server" ID="MyProjectTasksGrid"
                    DataKeyNames="Id"
                    ItemType="TeamTools.Logic.DTO.ProjectTaskDTO"
                    CssClass="table table-striped table-bordered table-list"
                    AutoGenerateColumns="false" AllowPaging="true"
                    AllowSorting="true"
                    PageSize="5"
                    OnPageIndexChanging="MyProjectTasksGrid_PageIndexChanging"
                    SelectMethod="MyProjectTasksGrid_GetData"
                    UpdateMethod="MyProjectTasksGrid_UpdateItem"
                    DeleteMethod="MyProjectTasksGrid_DeleteItem">
                    <Columns>
                        <%-- On hyperlink possibly show some chart about task --%>
                        <asp:BoundField SortExpression="Title" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataField="Title" HeaderText="Task" />
                        <asp:BoundField SortExpression="Status" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataField="Status" HeaderText="Task Status" />
                        <asp:TemplateField ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Button Text="Edit" CssClass="btn btn-warning" CommandName="Edit" runat="server" />
                                <asp:Button Text="Delete" CssClass="btn btn-danger" CommandName="Delete" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div id="NewTaskPanel" class="panel panel-default col-md-4">
                <div class="panel-content">
                    <div class="panel-header">
                        <button type="button" id="closeTaskForm" class="close" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h4 class="modal-title">New Task</h4>
                    </div>
                    <div class="panel-body">
                        <form name="NewTaskForm">
                            <div class="form-group">
                                <label for="taskName">Name</label>
                                <%-- Invalid task name: Lenght of the name should be between 3 and 50 symbols. --%>
                                <asp:TextBox runat="server" ID="TaskName" CssClass="form-control" placeholder="Something catchy and short." />
                            </div>
                            <div class="form-group">
                                <label for="taskDescription">Description</label>
                                <textarea runat="server" class="form-control" rows="5" placeholder="Something descriptive, but don't write a novel.(Optional)" id="taskDescription"></textarea>
                            </div>
                            <div class="form-group form-inline">
                                <label for="taskDate">Due date</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <span class="fa fa-calendar"></span>
                                    </div>
                                    <asp:TextBox runat="server" ID="TaskEndDate" CssClass="form-control" />
                                    <ajaxToolkit:CalendarExtender runat="server" TargetControlID="TaskEndDate" />
                                </div>
                                <div class="form-group">
                                    <label for="taskCost">Cost</label>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <span class="glyphicon glyphicon-usd"></span>
                                        </div>
                                        <input runat="server" class="form-control" type="number" id="taskCost" min="1">
                                    </div>
                                    <%-- Invalid Cost: Task cost cannot be 0 or negative value. --%>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="taskStatus">Status</label>
                                <select class="form-control" runat="server" id="taskStatus">
                                    <option value="started">Started</option>
                                    <option value="done">Done</option>
                                </select>
                            </div>
                            <div class="form-group">
                                <a id="CreateTask" class="btn btn-success" runat="server" onserverclick="CreateTask_ServerClick">Save Task</a>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
