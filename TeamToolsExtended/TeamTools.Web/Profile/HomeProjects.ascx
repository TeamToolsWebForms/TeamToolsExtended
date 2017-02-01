<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomeProjects.ascx.cs" Inherits="TeamTools.Web.Profile.HomeProjects" %>
<link rel="stylesheet" href="../Content/home-controls.css" type="text/css" />

<asp:ListView runat="server" ID="ProfileProjects" ItemType="TeamTools.DataTransferObjects.ProjectDTO">
    <ItemTemplate>
        <div class="container">
            <div class="row">
                <div>
                    <ul id="items-list">
                        <li class="list-item">
                            <h3><a href="#"><i class="fa fa-file-text"></i> <%#: Item.Title %></a></h3>
                            <p><%#: Item.Description %></p>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </ItemTemplate>
    <EmptyDataTemplate>
        <h3>Currently you are not a member of organization.</h3>
    </EmptyDataTemplate>
</asp:ListView>