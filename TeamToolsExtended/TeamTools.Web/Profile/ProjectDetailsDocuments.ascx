<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectDetailsDocuments.ascx.cs" Inherits="TeamTools.Web.Profile.ProjectDetailsDocuments" %>

<div class="container">
    <div class="row">
        <div class="dual-list list-right col-md-6">
            <div class="well text-right">
                <div class="row">
                    <div class="col-md-10">
                        <div class="input-group">
                            <input type="text" class="form-control" placeholder="search" />
                        </div>
                    </div>
                    <div class="col-md-2">
                        <div class="btn-group">
                            <a class="btn btn-default selector"><i class="glyphicon glyphicon-search"></i></a>
                        </div>
                    </div>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <ul class="list-group">
                            <li class="list-group-item">Some file
                        <asp:Button runat="server" OnClick="DownloadFile_Click" ID="DownloadFile" CssClass="btn btn-default" Text="Download" /></li>
                        </ul>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="DownloadFile" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</div>
