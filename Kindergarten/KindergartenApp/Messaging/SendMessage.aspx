<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="KindergartenApp.Messaging.SendMessage" MasterPageFile="../Site.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h2>שליחת הודעה</h2>
    </hgroup>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="סוג הודעה:" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="Who" RepeatDirection="Horizontal" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="שלח אל:" />
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="Where" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="כותרת:" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Title" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="הודעה:" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="Message" Height="162px" TextMode="MultiLine" Width="500px" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
