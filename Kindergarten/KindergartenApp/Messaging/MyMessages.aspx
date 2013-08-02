<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyMessages.aspx.cs" Inherits="KindergartenApp.Messaging.MyMessages" MasterPageFile="../Site.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    
    <asp:Label ID="NoMessages" runat="server" Text="אין הודעות להציג" Font-Size="XX-Large" ForeColor="Red" ></asp:Label>
    <table>
        <tr>
            <td dir="rtl">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Right">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="id" Visible="False" />
                    <asp:BoundField DataField="Sender.FullName" HeaderText="שולח">
                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SendTime" HeaderText="תאריך שליחה">
                    <HeaderStyle HorizontalAlign="Right" Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Title" HeaderText="כותרת"  >
                    <HeaderStyle HorizontalAlign="Right" Width="100px" />
                    </asp:BoundField >
                    <asp:HyperLinkField HeaderText="צפה בהודעה" Text="צפה" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/Messaging/ViewMessage.aspx?messageId={0}"  >
                    <HeaderStyle HorizontalAlign="Right" Width="100px" />
                    </asp:HyperLinkField>
                </Columns>

                </asp:GridView>
            </td>
         </tr>
    </table>
</asp:Content>
