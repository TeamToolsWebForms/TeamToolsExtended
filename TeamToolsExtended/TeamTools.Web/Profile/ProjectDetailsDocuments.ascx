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
                <ul>
                    <asp:GridView runat="server" ClientIDMode="Static" ID="MyProjectDocuments"
                    DataKeyNames="Id"
                    ItemType="TeamTools.Logic.DTO.ProjectDocumentDTO"
                    CssClass="table table-striped table-bordered table-list"
                    AutoGenerateColumns="false" AllowPaging="true"
                    AllowSorting="true"
                    PageSize="5"
                    OnPageIndexChanging="MyProjectDocuments_PageIndexChanging"
                    SelectMethod="MyProjectDocuments_GetData">
                    <EmptyDataTemplate>
                        <h3 class="text-center">There are no files yet!</h3>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField SortExpression="FileName" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataField="FileName" HeaderText="File" />
                        <asp:TemplateField ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:Button Text="Download" AccessKey="<%# Item.Id %>" CssClass="btn btn-default" ID="DownloadBtn" OnClick="DownloadBtn_Click" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </ul>
                <%--<asp:Repeater runat="server" ID="ProjectDocuments" ItemType="TeamTools.Logic.DTO.ProjectDocumentDTO">
                    <HeaderTemplate>
                        <ul class="list-group">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li class="list-group-item"><%#: Item.FileName %>
                            <asp:Button Text="Download" AccessKey="<%#: Item.Id %>" runat="server" ClientIDMode="Static" ID="Download" CssClass="btn btn-default" OnClick="Download_Click" />

                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>B
                    </FooterTemplate>
                </asp:Repeater>--%>
            </div>
        </div>
    </div>
</div>
