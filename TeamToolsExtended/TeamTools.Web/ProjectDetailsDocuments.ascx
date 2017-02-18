<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectDetailsDocuments.ascx.cs" Inherits="TeamTools.Web.ProjectDetailsDocuments" %>

<asp:Panel runat="server" DefaultButton="SearchDocuments" CssClass="container">
    <div class="row">
        <div class="dual-list list-right col-md-6">
            <div>
                <asp:TextBox runat="server" ClientIDMode="Static" ID="searchDocumentsPattern" CssClass="form-control mb-2 mr-sm-2 mb-sm-0" placeholder="search" />
                <asp:Button runat="server" Text="Search" CssClass="btn btn-default selector" ID="SearchDocuments" OnClick="SearchDocuments_Click" />
            </div>
            <ul>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:GridView runat="server" ClientIDMode="Static" ID="ProjectDocuments"
                            DataKeyNames="Id"
                            ItemType="TeamTools.Logic.DTO.ProjectDocumentDTO"
                            CssClass="table table-striped table-bordered table-list"
                            AutoGenerateColumns="false" AllowPaging="true"
                            PageSize="20"
                            OnPageIndexChanging="ProjectDocuments_PageIndexChanging"
                            SelectMethod="ProjectDocuments_GetData">
                            <EmptyDataTemplate>
                                <h3 class="text-center">There are no files yet!</h3>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:BoundField HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataField="FileName" HeaderText="File" />
                                <asp:TemplateField ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:Button Text="Download" AccessKey="<%# Item.Id %>" CssClass="btn btn-default" ID="DownloadBtn" OnClick="DownloadBtn_Click" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="ProjectDocuments" />
                    </Triggers>
                </asp:UpdatePanel>
            </ul>
        </div>
    </div>
</asp:Panel>