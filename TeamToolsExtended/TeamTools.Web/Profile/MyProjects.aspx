<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProjects.aspx.cs" Inherits="TeamTools.Web.Profile.MyProjects1" %>
<%@ Register Src="~/Profile/Projects.ascx" TagName="Projects" TagPrefix="mp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManagerProxy runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/create-note-validation.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <mp:Projects runat="server" ID="MyProjectsControl" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
