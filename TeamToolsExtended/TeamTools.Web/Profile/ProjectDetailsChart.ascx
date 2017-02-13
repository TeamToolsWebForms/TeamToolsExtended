<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectDetailsChart.ascx.cs" Inherits="TeamTools.Web.Profile.ProjectDetailsChart" %>

<div class="container">
    <h2 class="text-center">Stats for project: <%#: this.Model.Project.Title %></h2>

    <ul class="list-group">
        <li class="list-group-item">Total days: <%#: this.Model.TotalDays %></li>
        <li class="list-group-item">Total cost: <span class="fa fa-usd"><%#: this.Model.TotalCost %></span></li>
        <li class="list-group-item"># of tasks: <%#: this.Model.Project.ProjectTasks.Count %></li>
    </ul>
    <ajaxToolkit:LineChart ID="LineChart" ClientIDMode="Static" runat="server"
        ChartWidth="450" ChartHeight="300" ChartType="Stacked"
        CssClass="col-md-7"
        ChartTitle="Project cost in days"
        AreaDataLabel=" dollars"
        ChartTitleColor="#000000" CategoryAxisLineColor="#D08AD9"
        ValueAxisLineColor="#000000" BaseLineColor="#A156AB">
    </ajaxToolkit:LineChart>
</div>
