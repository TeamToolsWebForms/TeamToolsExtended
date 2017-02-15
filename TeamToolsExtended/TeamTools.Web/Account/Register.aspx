<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TeamTools.Web.Account.Register" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="stylesheet" href="../Content/register.css" type="text/css" />
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2>Register</h2>

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The email field is required." />
                <asp:RegularExpressionValidator ErrorMessage="You've entered invalid email" CssClass="text-danger" Display="Dynamic" ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}" ControlToValidate="Email" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="FirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" />
                <asp:RegularExpressionValidator Display="Dynamic" ErrorMessage="First name must be between 3 and 100 symbols" CssClass="text-danger" ValidationExpression = "^[\s\S]{3,100}$" ControlToValidate="FirstName" runat="server" />
                <br />
                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="FirstName"
                    CssClass="text-danger" ErrorMessage="The first name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="LastName" CssClass="col-md-2 control-label">Last Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="LastName" CssClass="form-control" />
                <asp:RegularExpressionValidator Display="Dynamic" ErrorMessage="Last name must be between 3 and 100 symbols" CssClass="text-danger" ValidationExpression = "^[\s\S]{3,100}$" ControlToValidate="LastName" runat="server" />
                <br />
                <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="LastName"
                    CssClass="text-danger" ErrorMessage="The last name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="GenderList" CssClass="col-md-2 control-label">Choose gender</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="GenderList" CssClass="form-control">
                    <asp:ListItem Text="Male" />
                    <asp:ListItem Text="Female" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password field is required." />
                <asp:RegularExpressionValidator Display = "Dynamic" CssClass="text-danger" ControlToValidate = "Password" ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{6,}$" runat="server" ErrorMessage="Password must be at least 6 sybmols long"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script src="../Scripts/register.js"></script>
</asp:Content>
