<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrashNotes.ascx.cs" Inherits="TeamTools.Web.Profile.TrashNotes" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div>
            <asp:ListView runat="server" ID="TrashNotesList" ItemType="TeamTools.Logic.DTO.NoteDTO"
                OnSorting="TrashNotesList_Sorting">
                <LayoutTemplate>
                    <div class="btn-group pull-right">
                        <button type="button" class="btn btn-info dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Sort By
                        </button>
                        <div class="dropdown-menu">
                            <asp:Button Text="Title" runat="server" CssClass="btn btn-info" CommandName="Sort" CommandArgument="Title" />
                            <asp:Button Text="Newest" runat="server" CssClass="btn btn-info" CommandName="Sort" CommandArgument="Id" />
                        </div>
                    </div>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="col-md-3" id="note<%# Item.Id %>">
                        <div class="quote-container">
                            <i class="pin"></i>
                            <blockquote class="note yellow">
                                <div>
                                    <%#: Item.Title %>
                                    <span class="fa fa-times pull-right show-cursor" onclick="restoreNote(<%# Item.Id %>);"></span>
                                </div>
                                <p><%#: Item.Content %></p>
                            </blockquote>
                        </div>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div>
                        <h3>Currently you don't have important notes</h3>
                    </div>
                </EmptyDataTemplate>
            </asp:ListView>
            <asp:DataPager ID="DataPagerNotes" runat="server"
                PagedControlID="TrashNotesList" PageSize="6" ClientIDMode="Static">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="true"
                        ShowNextPageButton="false" ShowPreviousPageButton="false" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="true"
                        ShowNextPageButton="false" ShowPreviousPageButton="false" />
                </Fields>
            </asp:DataPager>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="DataPagerNotes" />
    </Triggers>
</asp:UpdatePanel>