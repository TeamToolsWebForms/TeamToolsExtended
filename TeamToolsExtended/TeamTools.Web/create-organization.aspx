<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create-organization.aspx.cs" Inherits="TeamTools.Web.create_category" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form class="form-horizontal" runat="server" id="createCategoryForm">
        <fieldset>

            <!-- Form Name -->
            <legend>Create organization</legend>

            <!-- Text input-->
            <div class="form-group">
                <label class="col-md-4 control-label" for="textinput">Name</label>
                <div class="col-md-4">
                    <asp:TextBox ID="TextBox1" name="textinput" placeholder="Name of the organization" class="form-control input-md" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ControlToValidate="TextBox1" ID="RegularExpressionValidator2" runat="server" ErrorMessage="The name must be between 5 and 15 symbols long." ValidationExpression="\w{5,15}"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ControlToValidate="TextBox1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="The field is required."></asp:RequiredFieldValidator>
                </div>
            </div>

            <!-- Textarea -->
            <div class="form-group">
                <label class="col-md-4 control-label" for="textarea">Description</label>
                &nbsp;<div class="col-md-4">
                    <asp:TextBox ID="TextBox3" name="textarea" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ControlToValidate="TextBox3" ID="RequiredFieldValidator2" runat="server" ErrorMessage="The field is required."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ControlToValidate="TextBox3" ID="RegularExpressionValidator1" runat="server" ErrorMessage="The description must be between 5 and 100 symbols long." ValidationExpression="\w{10,100}"></asp:RegularExpressionValidator>

                      </div>
            </div>

            <!-- File Button -->
            <div class="form-group">
                <label class="col-md-4 control-label" for="filebutton">Logo</label>
                <div class="col-md-4">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
            </div>

            <!-- Button -->
            <div class="form-group">
                <label class="col-md-4 control-label" for="singlebutton">Submit</label>
                <div class="col-md-4">
                    <asp:Button ID="Button1" name="singlebutton" CssClass="btn btn-primary" runat="server" Text="Button"/>
                </div>
            </div>

        </fieldset>
    </form>


</body>
</html>
