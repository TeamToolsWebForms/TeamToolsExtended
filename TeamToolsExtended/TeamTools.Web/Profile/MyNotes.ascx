<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyNotes.ascx.cs" Inherits="TeamTools.Web.Profile.MyNotes" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div>
            <asp:ListView runat="server" ID="MyNotesList" ItemType="TeamTools.Logic.DTO.NoteDTO"
                OnSorting="MyNotesList_Sorting">
                <LayoutTemplate>
                    <div class="btn-group pull-right">
                        <button type="button" class="btn btn-info dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Sort By
                        </button>
                        <div class="dropdown-menu">
                            <asp:Button Text="Title" runat="server" CssClass="btn btn-info" CommandName="Sort" CommandArgument="Title" />
                            <asp:Button Text="Normal" runat="server" CssClass="btn btn-info" CommandName="Sort" CommandArgument="Id" />
                        </div>
                    </div>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="col-md-3">
                        <div class="quote-container">
                            <i class="pin"></i>
                            <blockquote class="note yellow">
                                <div>
                                    <%#: Item.Title %>
                                    <span class="fa fa-times pull-right show-cursor" onclick="deleteNote(<%# Item.Id %>);"></span>
                                    <span class="fa fa-certificate pull-right show-cursor" onclick="setImportant(<%# Item.Id %>);"></span>
                                </div>
                                <p><%#: Item.Content %></p>
                            </blockquote>
                        </div>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div>
                        <h3>Currently you don't have notes</h3>
                    </div>
                </EmptyDataTemplate>
            </asp:ListView>
            <asp:DataPager ID="DataPagerNotes" runat="server"
                PagedControlID="MyNotesList" PageSize="6">
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

