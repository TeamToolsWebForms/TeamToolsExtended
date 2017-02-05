<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyNotes.ascx.cs" Inherits="TeamTools.Web.Profile.MyNotes" %>

<div>
    <asp:ListView runat="server" ID="MyNotesList" DataSource="<%# this.Model.UserNotes %>" ItemType="TeamTools.Logic.DTO.NoteDTO">
        <ItemTemplate>
            <div class="col-md-3">
                <div class="quote-container">
                    <i class="pin"></i>
                    <blockquote class="note yellow">
                        <div><%#: Item.Title %> <span class="fa fa-certificate pull-right" onclick="setImportant(<%# Item.Id %>);"></span></div>
                        <p><%#: Item.Content %></p>
                    </blockquote>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</div>
