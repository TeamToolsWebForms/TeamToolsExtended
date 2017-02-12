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
                        <a runat="server" onserverclick="CreateNew_ServerClick" id="CreateNew" class="btn btn-sm btn-primary btn-create">Create New</a>
                    </div>
                </div>
            </div>
            <div class="panel-body">
                <asp:GridView runat="server" ClientIDMode="Static" ID="MyProjectTasksGrid"
                    DataKeyNames="Id"
                    ItemType="TeamTools.Logic.DTO.ProjectTaskDTO"
                    CssClass="table table-striped table-bordered table-list"
                    AutoGenerateColumns="false" AllowPaging="true"
                    AllowSorting="true"
                    PageSize="5"
                    OnPageIndexChanging="MyProjectTasksGrid_PageIndexChanging"
                    SelectMethod="MyProjectTasksGrid_GetData"
                    DeleteMethod="MyProjectTasksGrid_DeleteItem">
                    <Columns>
                        <asp:BoundField SortExpression="Title" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataField="Title" HeaderText="Task" />
                        <asp:BoundField SortExpression="Status" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataField="Status" HeaderText="Task Status" />
                        <asp:BoundField SortExpression="DueDate" DataFormatString="{0: dd.MM.yyyy}" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataField="DueDate" HeaderText="Due Date" />
                        <asp:TemplateField ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:Button Text="Edit" AccessKey="<%# Item.Id %>" CssClass="btn btn-warning" ID="EditTaskBtn" OnClick="EditTaskBtn_Click" runat="server" />
                                <asp:Button Text="Delete" CssClass="btn btn-danger" CommandName="Delete" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <%-- New task form --%>
            <div id="NewTaskPanel" class="panel panel-default col-md-4">
                <div class="panel-content">
                    <div class="panel-header">
                        <button runat="server" onserverclick="closeTaskForm_ServerClick" type="button" id="closeTaskForm" class="close" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h4 class="modal-title">New Task</h4>
                    </div>
                    <div class="panel-body">
                        <form name="NewTaskForm">
                            <div class="form-group">
                                <label for="taskName">Name</label>
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
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="taskStatus">Status</label>
                                <asp:DropDownList ID="TaskStatus" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Started" Value="started" />
                                    <asp:ListItem Text="Done" Value="done" />
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <a id="CreateTask" class="btn btn-success" runat="server" onserverclick="CreateTask_ServerClick">Save Task</a>
                            </div>
                        </form>
                    </div>
                </div>
            </div>

            <%-- Edit task form --%>
            <div id="EditTaskPanel" class="panel panel-default col-md-4">
                    <div class="panel-content">
                        <div class="panel-header">
                            <button runat="server" onserverclick="closeEditTaskPanel_ServerClick" type="button" id="closeEditTaskPanel" class="close" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <h4 class="modal-title">Edit Task</h4>
                        </div>
                        <div class="panel-body">
                            <form name="EditTaskForm">
                                <div class="form-group">
                                    <label for="EditTaskTitle">Name</label>
                                    <asp:TextBox runat="server" ID="EditTaskTitle" CssClass="form-control" placeholder="Something catchy and short." />
                                </div>
                                <div class="form-group">
                                    <label for="taskDescription">Description</label>
                                    <textarea runat="server" class="form-control" rows="5" placeholder="Something descriptive, but don't write a novel.(Optional)" id="EditTaskDescription"></textarea>
                                </div>
                                <div class="form-group form-inline">
                                    <label for="taskDate">Due date</label>
                                    <div class="input-group">
                                        <div class="input-group-addon">
                                            <span class="fa fa-calendar"></span>
                                        </div>
                                        <asp:TextBox runat="server" ID="EditTaskEndDate" CssClass="form-control" />
                                        <ajaxToolkit:CalendarExtender runat="server" TargetControlID="EditTaskEndDate" />
                                    </div>
                                    <div class="form-group">
                                        <label for="taskCost">Cost</label>
                                        <div class="input-group">
                                            <div class="input-group-addon">
                                                <span class="glyphicon glyphicon-usd"></span>
                                            </div>
                                            <input runat="server" class="form-control" type="number" id="EditTaskCost" min="1">
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="taskStatus">Status</label>
                                    <asp:DropDownList ID="EditTaskStatus" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Started" Value="started" />
                                        <asp:ListItem Text="Done" Value="done" />
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <a id="EditTaskBtn" class="btn btn-success" runat="server" onserverclick="EditTaskBtn_ServerClick">Edit Task</a>
                                </div>
                            </form>
                        </div>
                    </div>
            </div>
        </div>
    </div>
</div>
