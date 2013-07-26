<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyMessages.aspx.cs" Inherits="KindergartenApp.Messaging.MyMessages" MasterPageFile="../Site.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Sender.FullName" HeaderText="שולח">
            <HeaderStyle HorizontalAlign="Center" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="SendTime" HeaderText="תאריך שליחה">
            <HeaderStyle HorizontalAlign="Right" Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="Title" HeaderText="כותרת">
            <HeaderStyle HorizontalAlign="Right" Width="100px" />
            </asp:BoundField>
            <asp:HyperLinkField HeaderText="ההודעה המלאה" Text="צפה">
            <HeaderStyle HorizontalAlign="Right" Width="100px" />
            </asp:HyperLinkField>
        </Columns>
        <RowStyle HorizontalAlign="Right" />
    </asp:GridView>
    
</asp:Content>
