<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="TeamTools.Web.Admin.Admin" %>
<%@ Register Src="~/Admin/AllUsers.ascx" TagName="allusers" TagPrefix="admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Content/admin-allusers.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="DashboardMain" ClientIDMode="Static">
        <ContentTemplate>
            <div class="tabbable-panel">
                <div class="tabbable-line">
                    <div class="tab-content">
                        <asp:Panel runat="server" ID="ContentView">
                            <div>
                                <admin:allusers runat="server" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../Scripts/allusers.js"></script>
</asp:Content>
