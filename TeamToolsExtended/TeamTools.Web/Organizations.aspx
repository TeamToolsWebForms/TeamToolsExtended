<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyOrganizations.aspx.cs" Inherits="TeamTools.Web.Profile.MyOrganizations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Content/organizations.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HyperLink NavigateUrl="~/create-organization.aspx" CssClass="btn btn-primary" ID="HyperLink1" runat="server">Create an organization</asp:HyperLink>
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TeamToolsDB %>" SelectCommand="SELECT [Name], [Description] FROM [Organizations]"></asp:SqlDataSource>
        </div>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <asp:Panel ID="Panel4" runat="server" CssClass="panel panel-primary">                    
                    <asp:Panel runat="server" CssClass="panel-heading">
                        <h3 class="panel-title"><%# Eval("Name") %></h3>
                    </asp:Panel>  
                    <asp:Panel runat="server" CssClass="panel-body">
                        <%# Eval("Description") %>
                    </asp:Panel>            
                </asp:Panel>
            </ItemTemplate>
        </asp:Repeater>
   
</asp:Content>
