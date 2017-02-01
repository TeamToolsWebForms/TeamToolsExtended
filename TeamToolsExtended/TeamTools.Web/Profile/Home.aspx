<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TeamTools.Web.Profile.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Content/home-profile.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Toq menu bara da ne go zabravime ;d</h3>
    <h3><%# HttpContext.Current.User.Identity.GetUserName() %></h3>
    <asp:Image runat="server" ID="ProfileImage" AlternateText="Profile logo" />
</asp:Content>
