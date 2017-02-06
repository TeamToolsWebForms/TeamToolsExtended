<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyNotes.ascx.cs" Inherits="TeamTools.Web.Profile.MyNotes" %>

<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div>
            <asp:ListView runat="server" ID="MyNotesList" ItemType="TeamTools.Logic.DTO.NoteDTO">
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

