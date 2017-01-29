<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TeamTools.Web._Default" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
    <link href="./Content/DefaultPage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wg-grid">
        <div class="wg-cell">
            <h2>Team Tools helps every team perform their best,<br>
                across the hall or across the globe</h2>
            <div class="text-center">
                <asp:Image ImageUrl="~/Images/home-img.png" runat="server" AlternateText="Home logo" CssClass="home-logo" />
            </div>

            <p class="home-anchor-subtitle">No matter the workflow, Team Tools enhances communication,<br>
                transparency and accountability to achieve results</p>

            <div class="container">
                <div class="row text-center">
                    <div class="col-xs-4">
                        <div>
                            <img class="home-anchor-icon--default" src="https://www.wrike.com/content/uploads/2016/11/icon-management.svg">
                        </div>
                        <p><span class="img-title">Project<br>
                            Management Solutions</span></p>
                    </div>
                    <div class="col-xs-4">
                        <div>
                            <img class="home-anchor-icon--default" src="https://www.wrike.com/content/uploads/2016/11/icon-creative.svg">
                        </div>
                        <p><span class="img-title">Creative<br>
                            Ideas</span></p>
                    </div>
                    <div class="col-xs-4">
                        <div>
                            <img class="home-anchor-icon--default" src="https://www.wrike.com/content/uploads/2016/11/icon-all-team.svg">
                        </div>
                        <p><span class="img-title">Project<br>
                            Communication</span></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
