<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenAuthProviders.ascx.cs" Inherits="TeamTools.Web.Account.OpenAuthProviders" %>

<asp:ListView runat="server" ID="providerDetails" ItemType="System.String"
    SelectMethod="GetProviderNames" ViewStateMode="Disabled">
    <ItemTemplate>
        <button type="submit" class="fa fa-facebook fa-lg btn btn-primary" name="provider" value="<%#: Item %>"
            title="Log in using your <%#: Item %> account.">
            <%#: Item %>
        </button>
    </ItemTemplate>
</asp:ListView>
